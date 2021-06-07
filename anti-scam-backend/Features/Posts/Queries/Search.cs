using anti_scam_backend.Domain.Infrastructure;
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

namespace anti_scam_backend.Features.Posts.Queries
{
    public static class Search
    {
        public class SearchResponseModel : Get.PostModel
        {

        }
        public class Query : IRequest<ResponseModel<List<SearchResponseModel>>>
        {
            public string SearchText { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<List<SearchResponseModel>>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<List<SearchResponseModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<List<SearchResponseModel>>();

                if (!String.IsNullOrEmpty(request.SearchText))
                {
                    var posts = _context.Posts
                        .AsNoTracking()
                        .Where(i=> i.Status == Domain.Model.EStatusPost.Accepted)
                        .Include(i => i.User)
                        .Include(i => i.Comments)
                        .Include(i => i.TypePosts)
                        .ThenInclude(i => i.Type)
                        .OrderByDescending(i => i.CreatedDate)
                        .AsEnumerable();

                    var requestSearchText = StringHelper.RemoveVietNameTone(request.SearchText.ToLower());
                    posts = posts.Where(
                        i => StringHelper.RemoveVietNameTone(i.Title.ToLower()).Contains(requestSearchText) ||
                        i.TypePosts.Select(m => StringHelper.RemoveVietNameTone(m.Object.ToLower())).Any(c => c.Contains(requestSearchText)));

                    if(posts.Count() > 0)
                    {
                        posts = posts.Take(6);
                    }

                    var data = posts.ToList();

                    var result = _mapper.Map<List<SearchResponseModel>>(data);

                    ack.Data = result;
                    ack.IsSuccess = true;
                    return ack;
                }

                ack.Data = new List<SearchResponseModel>();
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
