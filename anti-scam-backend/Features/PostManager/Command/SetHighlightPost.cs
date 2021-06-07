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
    public static class SetHighlightPost
    {
        public class Command : IRequest<ResponseModel>
        {
            public Guid PostId { get; set; }
            public bool IsHighLight { get; set; }
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
                var post = await _context.Posts.FirstOrDefaultAsync(i => i.Id == request.PostId);
                if(post == null)
                {
                    ack.Messages.Add("Bài viết không tồn tại");
                    return ack;
                }
                post.IsHighlight = request.IsHighLight;
                await _context.SaveChangesAsync();

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
