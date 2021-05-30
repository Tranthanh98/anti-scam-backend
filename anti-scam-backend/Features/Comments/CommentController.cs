using anti_scam_backend.Features.Comments.Queries;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Comments
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel<Pagination<Queries.Get.CommentModel>>> GetComment(Queries.Get.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<ResponseModel<Get.CommentModel>> Create(Command.Create.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            Guid u;
            Guid.TryParse(userId, out u);
            command.UserId = u;
            var result = await _mediator.Send(command, default);
            return result;
        }
    }
}
