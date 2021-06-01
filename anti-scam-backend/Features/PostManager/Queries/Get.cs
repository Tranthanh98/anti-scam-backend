using anti_scam_backend.Domain.Entities;
using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Model;
using anti_scam_backend.Services.Helper;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.PostManager.Queries
{
    public static class Get
    {
        public class SearchModel : Pagination
        {
            public int TypeId { get; set; }
            public int StatusId { get; set; }
            public int KindOfId { get; set; }
            public string SearchText { get; set; }
        }

        public class Query : IRequest<ResponseModel<Pagination<PostModel>>>
        {
            public SearchModel SearchModel { get; set; }
        }

        public class PostModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public Guid? CreatedById { get; set; }
            public string CreatedByName { get; set; }

            public DateTimeOffset? CreatedDate { get; set; }
            public List<TypePost> TypePosts { get; set; }
            public EStatusPost? Status { get; set; }
            public string StatusName { get; set; }
            public EKindOf? KindOf { get; set; }
            public string KindOfName { get; set; }
            public Guid? AcceptedById { get; set; }
            public string AcceptedByName { get; set; }
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
                    .Include(i => i.User)
                    .Include(i => i.Accepted)
                    .Include(i => i.TypePosts)
                    .ThenInclude(i => i.Type)
                    .AsEnumerable();

                if (request.SearchModel.TypeId != default)
                {
                    posts = posts.Where(i => i.TypePosts.Select(i => i.TypeId).Contains(request.SearchModel.TypeId));
                }

                if (request.SearchModel.KindOfId != default)
                {
                    posts = posts.Where(i => i.KindOf == (EKindOf)request.SearchModel.KindOfId);
                }
                if (request.SearchModel.StatusId != default)
                {
                    posts = posts.Where(i => i.Status == (EStatusPost)request.SearchModel.StatusId);
                }

                if (!String.IsNullOrEmpty(request.SearchModel.SearchText))
                {
                    var str = StringHelper.RemoveVietNameTone(request.SearchModel.SearchText.ToLower());
                    posts = posts.Where(i=> StringHelper.RemoveVietNameTone(i.Title.ToLower()).Contains(str)||
                                            i.User.Email.ToLower().Contains(str)
                    );
                }

                var data = posts.Skip(request.SearchModel.Skip()).Take(request.SearchModel.PageSize).ToList();

                var result = _mapper.Map<List<PostModel>>(data);

                var ack = new ResponseModel<Pagination<PostModel>>()
                {
                    IsSuccess = true,
                    Data = new Pagination<PostModel>()
                    {
                        CurrentPage = request.SearchModel.CurrentPage,
                        Total = posts.Count(),
                        Data = result
                    }
                };

                return ack;
            }
        }

    }
}
