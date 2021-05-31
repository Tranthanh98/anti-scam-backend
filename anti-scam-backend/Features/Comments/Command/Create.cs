using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Features.Comments.Queries;
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

namespace anti_scam_backend.Features.Comments.Command
{
    public static class Create
    {
        public class Command : IRequest<ResponseModel<Get.CommentModel>>
        {
            public Guid UserId { get; set; }
            [FromBody]
            public Guid PostId { get; set; }
            [FromBody]
            public string Content { get; set; }
            public DateTimeOffset? CreatedDate { get { return DateTimeOffset.UtcNow; } private set { } }

        }
        public class Handler : IRequestHandler<Command, ResponseModel<Get.CommentModel>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<Get.CommentModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.UserId == default)
                {
                    return new ResponseModel<Get.CommentModel>()
                    {
                        IsSuccess = false,
                        Messages = new List<string>() { "Người dùng không hợp lệ" }
                    };
                }
                if(String.IsNullOrEmpty(request.Content))
                {
                    return new ResponseModel<Get.CommentModel>()
                    {
                        IsSuccess = false,
                        Messages = new List<string>() { "Bình luận không được để trống" }
                    };
                }
                //add comment
                var comment = _mapper.Map<Domain.Entities.Comment>(request);
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                //get comment return fe
                var getComment = await _context.Comments
                    .AsNoTracking()
                    .Include(i=> i.User)
                    .FirstOrDefaultAsync(i => i.Id == comment.Id);
                return new ResponseModel<Get.CommentModel>()
                {
                    IsSuccess = true,
                    Data = _mapper.Map<Get.CommentModel>(getComment)
                };
            }
        }
    }
}
