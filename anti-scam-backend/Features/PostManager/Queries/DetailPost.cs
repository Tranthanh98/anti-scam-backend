using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Features.Posts.Queries;
using anti_scam_backend.Model;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.PostManager.Queries
{
    public static class DetailPost
    {
        public class DetailPostManager : Detail.DetailPost
        {
            public EStatusPost Status { get; set; }
            public string StatusName { get; set; }
            public Guid? AcceptedById { get; set; }
            public string AcceptedByName { get; set; }
        }
        public class Query : IRequest<ResponseModel<DetailPostManager>>
        {
            [FromBody]
            public Guid PostId { get; set; }
            public string BaseUrl { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<DetailPostManager>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<DetailPostManager>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<DetailPostManager>();
                var post = await _context.Posts
                    .AsNoTracking()
                    .Where(i => i.Id == request.PostId)
                    .Include(i => i.User)
                    .Include(i=> i.Accepted)
                    .Include(i => i.Images)
                    .Include(i => i.TypePosts)
                    .ThenInclude(i => i.Type)
                    .FirstOrDefaultAsync();

                if (post == null)
                {
                    ack.Messages.Add("Bài viết không tồn tại.");
                    return ack;
                }
                var data = _mapper.Map<DetailPostManager>(post);

                var imageList = post.Images.Select(i => request.BaseUrl + "/api/file/getfilebyid/" + i.Id).ToList();

                data.ImageList = imageList;

                ack.Data = data;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
