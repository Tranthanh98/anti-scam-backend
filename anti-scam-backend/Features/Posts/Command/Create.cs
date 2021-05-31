using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Model;
using anti_scam_backend.Services.Helper;
using anti_scam_backend.Services.Middleware;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Posts.Command
{
    public static class Create
    {
        public class TypePostModel
        {
            public int TypeId { get; set; }
            public string Object { get; set; }
        }
        public class Command : IRequest<ResponseModel>
        {
            [FromBody]
            public string Title { get; set; }
            [FromBody]
            public string Description { get; set; }
            [FromBody]
            public int KindOf { get; set; }
            [FromBody]
            public List<TypePostModel> TypePostList { get; set; }
            [FromBody]
            public List<int> ImageIds { get; set; }
            [FromHeader(Name = "X-UserId")]
            public string UserId { get; set; }
        }
        public class Handler : IRequestHandler<Command, ResponseModel>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                Guid userId;
                Guid.TryParse(request.UserId, out userId);
                var link = PostHelper.CreateLinkPost(request.Title);
                var post = new Domain.Entities.Posts()
                {
                    Id = Guid.NewGuid(),
                    CreatedById = userId,
                    CreatedDate = DateTimeOffset.UtcNow,
                    Description = request.Description,
                    IsActive = false,
                    KindOf = (EKindOf)request.KindOf,
                    Link = link,
                    Title = request.Title,
                    View = 0,
                    TypePosts = request.TypePostList.Select(i => new Domain.Entities.TypePost()
                    {
                        Object = i.Object,
                        TypeId = i.TypeId,
                    }).ToList(),
                    IsHighlight = false
                };
                var imgList = _context.FileAttachments.Where(i => i.CreatedBy == userId && request.ImageIds.Contains(i.Id));

                post.Images = imgList.ToList();
                _context.Posts.Add(post);

                await _context.SaveChangesAsync();

                return new ResponseModel()
                {
                    IsSuccess = true
                };
                
            }
        }
    }
}
