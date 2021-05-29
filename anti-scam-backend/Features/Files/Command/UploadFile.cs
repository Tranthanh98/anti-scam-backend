using anti_scam_backend.Domain.Entities;
using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Files.Command
{
    public class UploadFile
    {
        public class ResponseFile
        {
            public string Url { get; set; }
            public string Name { get; set; }
            public int FileId { get; set; }
        }
        public class FileModel
        {
            public byte[] FileByte { get; set; }
            public string Name { get; set; }
            public string Ext { get; set; }
        }
        public class Command : IRequest<ResponseModel<List<ResponseFile>>>
        {
            public List<FileModel> FileModels { get; set; }
            public string BaseUrl { get; set; }
            [FromHeader(Name = "UserId")]
            public string UserId { get; set; }

        }
        public class Handler : IRequestHandler<Command, ResponseModel<List<ResponseFile>>>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel<List<ResponseFile>>> Handle(Command request, CancellationToken cancellationToken)
            {
                Guid createdby;
                Guid.TryParse(request.UserId, out createdby);
                
                var files = request.FileModels.Select(i => new FileAttachment()
                {
                    Name = i.Name,
                    CreatedDate = DateTime.Now,
                    Ext = i.Ext,
                    FileAttachmentData = new FileAttachmentData()
                    {
                        Data = i.FileByte
                    },
                    CreatedBy = createdby
                }).ToList();

                await _context.FileAttachments.AddRangeAsync(files);
                await _context.SaveChangesAsync();

                var fileResponses = files.Select(i => new ResponseFile()
                {
                    FileId = i.Id,
                    Name = i.Name,
                    Url = request.BaseUrl + "/api/file/getfilebyid/" + i.Id
                }).ToList();
                return new ResponseModel<List<ResponseFile>>()
                {
                    IsSuccess = true,
                    Data = fileResponses
                };
            }
        }
    }
}
