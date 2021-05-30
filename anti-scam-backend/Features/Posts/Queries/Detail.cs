using anti_scam_backend.Domain.Infrastructure;
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

namespace anti_scam_backend.Features.Posts.Queries
{
    public static class Detail
    {
        public class DetailPost : Get.PostModel
        {
            public List<string> ImageList { get; set; }
        }
        public class Query : IRequest<ResponseModel<DetailPost>>
        {
            [FromBody]
            public Guid PostId { get; set; }
            public string BaseUrl { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<DetailPost>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<DetailPost>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<DetailPost>();
                var post = await _context.Posts
                    .Where(i => i.Id == request.PostId)
                    .Include(i => i.User)
                    .Include(i => i.Comments)
                    .Include(i => i.Images)
                    .Include(i => i.TypePosts)
                    .ThenInclude(i => i.Type)
                    .FirstOrDefaultAsync();
                if(post == null)
                {
                    ack.Messages.Add("Bài viết này không tồn tại");
                    return ack;
                }
                var data = _mapper.Map<DetailPost>(post);

                post.View = post.View + 1;
                await _context.SaveChangesAsync();

                var imageList = post.Images.Select(i => request.BaseUrl + "/api/file/getfilebyid/" + i.Id).ToList();

                data.ImageList = imageList;
                ack.Data = data;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
