using anti_scam_backend.Domain.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Files.Command
{
    public static class DeleteFileUnUsage
    {
        public class Command : IRequest
        {

        }
        public class Handler : IRequestHandler<Command>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var allFileUnUsage = _context.FileAttachments.Include(i => i.FileAttachmentData)
                    .Where(i => i.PostId == null);
                _context.FileAttachments.RemoveRange(allFileUnUsage);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}
