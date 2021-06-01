using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.PostManager.Command
{
    public static class Accept
    {
        public class Command : BaseCommandQuery<ResponseModel>
        {
            public Guid PostId { get; set; }
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
                var ack = new ResponseModel();
                Guid userId;
                Guid.TryParse(request.UserId, out userId);
                if(userId == default)
                {
                    ack.Messages.Add("Người dùng không hợp lệ");
                    return ack;
                }

                var checkUser = await _context.Users.AnyAsync(i => i.Id == userId);
                if (!checkUser)
                {
                    ack.Messages.Add("Người dùng không có trong hệ thống");
                    return ack;
                }
                var post = await _context.Posts.FirstOrDefaultAsync(i => i.Id == request.PostId);
                if(post == null)
                {
                    ack.Messages.Add("Bài viết không tồn tại");
                    return ack;
                }
                post.AcceptedById = userId;
                post.AcceptedDate = DateTimeOffset.UtcNow;
                post.Status = Domain.Model.EStatusPost.Accepted;

                await _context.SaveChangesAsync();

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
