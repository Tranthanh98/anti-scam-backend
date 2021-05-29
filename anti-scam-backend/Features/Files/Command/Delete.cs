using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Files.Command
{
    public static class Delete
    {
        public class Command : IRequest<ResponseModel>
        {
            [FromBody]
            public int Id { get; set; }
            [FromHeader(Name = "UserId")]
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
                Guid createdby;
                Guid.TryParse(request.UserId, out createdby);

                var response = new ResponseModel();
                var file = await _context.FileAttachments
                                .Include(i => i.FileAttachmentData)
                                .Where(i => i.Id == request.Id)
                                .FirstOrDefaultAsync();
                if (file == null)
                {
                    response.Messages.Add("File không tồn tại");
                    return response;
                }
                
                if(file.CreatedBy != createdby)
                {
                    response.Messages.Add("Bạn không có quyền xóa file này");
                    return response;
                }
                _context.FileAttachments.Remove(file);
                await _context.SaveChangesAsync();
                return new ResponseModel()
                {
                    IsSuccess = true
                };
            }
        }
    }
}
