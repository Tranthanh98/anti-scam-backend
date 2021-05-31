using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using anti_scam_backend.Services.Helper;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Posts.Queries
{
    public static class Get
    {
        public class PostModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTimeOffset? CreatedDate { get; set; }
            public int? ReviewNumber { get; set; }
            public string Link { get; set; }
            public List<Domain.Entities.TypePost> TypePosts { get; set; }
            public string KindOfName { get; set; }
            public int KindOf { get; set; }
            public string Writer { get; set; }
            public int TotalComment { get; set; }

        }
        public class SearchModel : Pagination
        {
            public string SearchText { get; set; }
            public int TypeId { get; set; }
            public int SortType { get; set; }
            public int KindOfValue { get; set; }
        }
        public class Query : BaseCommandQuery<ResponseModel<Pagination<PostModel>>>
        {
            [FromBody]
            public SearchModel SearchModel { get; set; }

        }
        public class Handler : IRequestHandler<Query, ResponseModel<Pagination<PostModel>>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<Pagination<PostModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var posts = _context.Posts
                    .AsNoTracking()
                    .Where(i=> (int)i.KindOf == request.SearchModel.KindOfValue)
                    .Include(i=> i.User)
                    .Include(i=> i.Comments)
                    .Include(i => i.TypePosts)
                    .ThenInclude(i => i.Type)
                    .AsEnumerable();

                if (request.SearchModel.TypeId != default)
                {
                    posts = posts.Where(i => i.TypePosts.Select(i => i.TypeId).Contains(request.SearchModel.TypeId));
                }
                if (!String.IsNullOrEmpty(request.SearchModel.SearchText))
                {
                    var requestSearchText = StringHelper.RemoveVietNameTone(request.SearchModel.SearchText);
                    posts = posts.Where(
                        i => StringHelper.RemoveVietNameTone(i.Title).Contains(requestSearchText) ||
                        i.TypePosts.Select(m => StringHelper.RemoveVietNameTone(m.Object)).Any(c => c.Contains(requestSearchText)));
                }
                
                var data = posts.Skip(request.SearchModel.Skip()).Take(request.SearchModel.PageSize).ToList();

                if((int)request.SearchModel.SortType == (int)SortOrder.Ascending)
                {
                    data = data.OrderBy(i => i.CreatedDate).ToList();
                }
                else if((int)request.SearchModel.SortType == (int)SortOrder.Descending)
                {
                    data = data.OrderByDescending(i => i.CreatedDate).ToList();
                }

                var result = _mapper.Map<List<PostModel>>(data);

                return new ResponseModel<Pagination<PostModel>>()
                {
                    IsSuccess = true,
                    Data = new Pagination<PostModel>()
                    {
                        CurrentPage = request.SearchModel.CurrentPage,
                        Total = posts.Count(),
                        Data = result,
                    }
                };
                
            }
        }
    }
}
