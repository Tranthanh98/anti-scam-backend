using anti_scam_backend.Domain.Entities;
using anti_scam_backend.Features.Files.Command;
using anti_scam_backend.Features.Files.Queries;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static anti_scam_backend.Features.Files.Command.UploadFile;

namespace anti_scam_backend.Features.Files
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel<List<ResponseFile>>> UploadFile(List<IFormFile> files)
        {
            var baseUrl = Request.Host.Value;
            StringValues userId;
            HttpContext.Request.Headers.TryGetValue("UserId", out userId);
            var schema = Request.Scheme;
            var command = new UploadFile.Command()
            {
                FileModels = new List<UploadFile.FileModel>()
            };
            foreach(var file in files)
            {
                var fileModel = new UploadFile.FileModel();
                if (file.Length > 0)
                {
                    fileModel.Name = file.FileName;
                    fileModel.Ext = file.ContentType;
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        fileModel.FileByte = fileBytes;
                    }
                    command.FileModels.Add(fileModel);
                    
                }

            }
            command.BaseUrl = schema +"://"+ baseUrl;
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> DeleteFile(int id)
        {
            StringValues userId;
            HttpContext.Request.Headers.TryGetValue("UserId", out userId);
            var response = await _mediator.Send(new Delete.Command() { Id = id, UserId = userId }, default);
            return response;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> DeleteMultipleFile(List<int> listId)
        {
            var response = await _mediator.Send(new DeleteMultiple.Command() { listId = listId }, default);
            return response;
        }
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> DeleteFileUnUsage()
        {
            var response = await _mediator.Send(new DeleteFileUnUsage.Command(), default);
            return new ResponseModel() { IsSuccess = true };
        }
        [HttpGet("{id}")]
        [ResponseCache(Duration = 2592000, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> GetFileById(int id)
        {
            try
            {
                var file = await _mediator.Send(new GetFileById.Query() { Id = id }, default);
                Response.Headers.Add("Content-Disposition", DateTime.Now.ToString());

                return new FileContentResult(file, "image/jpeg");
                //return File(
                //        file, System.Net.Mime.MediaTypeNames.Application.Octet, "image"+DateTime.Now.ToString());
            }
            catch (Exception e)
            {
                return this.NotFound(e.Message.ToString());
            }
        }

    }
}
