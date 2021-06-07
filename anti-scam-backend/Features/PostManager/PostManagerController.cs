using anti_scam_backend.Features.PostManager.Command;
using anti_scam_backend.Features.PostManager.Queries;
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
using static anti_scam_backend.Features.PostManager.Queries.DetailPost;
using static anti_scam_backend.Features.PostManager.Queries.Get;

namespace anti_scam_backend.Features.PostManager
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class PostManagerController : ControllerBase
    {
        private IMediator _mediator;
        public PostManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel<Queries.GetDefaultData.PostManageModel>> GetDefaultData()
        {
            var result = await _mediator.Send(new Queries.GetDefaultData.Query(), default);
            return result;
        }
        [HttpPost]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel<Pagination<PostModel>>> GetData(Get.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel<DetailPostManager>> DetailPost(Guid id)
        {
            var baseUrl = Request.Host.Value;
            var schema = Request.Scheme;
            var url = schema + "://" + baseUrl;
            var result = await _mediator.Send(new DetailPost.Query() { PostId = id, BaseUrl = url }, default);
            return result;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel> Accept (Guid id)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);

            var result = await _mediator.Send(new Accept.Command() { PostId = id, UserId = userId });
            return result;
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel> Disabled(Guid id)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);

            var result = await _mediator.Send(new Disabled.Command() { PostId = id, UserId = userId });
            return result;
        }
        [HttpPost]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel> Create(Create.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "ContentManger")]
        public async Task<ResponseModel> SetHighlight(SetHighlightPost.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
    }
}
