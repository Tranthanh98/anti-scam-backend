using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Files.Command
{
    public static class DeleteMultiple
    {
        public class Command : IRequest<ResponseModel>
        {
            public List<int> listId { get; set; }
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
                var response = new ResponseModel();
                var files = _context.FileAttachments
                                .Include(i => i.FileAttachmentData)
                                .Where(i => request.listId.Contains(i.Id));
                _context.FileAttachments.RemoveRange(files);
                await _context.SaveChangesAsync();
                return new ResponseModel()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
