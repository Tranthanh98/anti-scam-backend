using anti_scam_backend.Domain.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Files.Queries
{
    public static class GetFileById
    {
        public class Query : IRequest<byte[]>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, byte[]>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }

            public async Task<byte[]> Handle(Query request, CancellationToken cancellationToken)
            {
                var file = await _context.FileAttachments
                    .Include(i => i.FileAttachmentData)
                    .FirstOrDefaultAsync(i => i.Id == request.Id);
                if (file != null)
                {
                    return file.FileAttachmentData.Data;
                }
                else
                {
                    throw new Exception("file not found.");
                }
            }
        }
    }
}
