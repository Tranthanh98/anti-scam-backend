using anti_scam_backend.Features.Posts.Command;
using anti_scam_backend.Features.Posts.Queries;
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
using static anti_scam_backend.Features.Posts.Queries.Search;

namespace anti_scam_backend.Features.Posts
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> CreatePost(Create.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpPost]
        public async Task<ResponseModel<Pagination<Queries.Get.PostModel>>> GetPosts(Queries.Get.Query query)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            query.UserId = userId;
            var result = await _mediator.Send(query, default);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ResponseModel<Queries.Detail.DetailPost>> Detail(Guid id)
        {
            var baseUrl = Request.Host.Value;
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);

            var schema = Request.Scheme;
            var result = await _mediator.Send(new Queries.Detail.Query() { BaseUrl = schema + "://" + baseUrl, PostId = id });
            return result;
        }

        [HttpGet("{searchText}")]
        public async Task<ResponseModel<List<SearchResponseModel>>> Search(string searchText)
        {
            var result = await _mediator.Send(new Search.Query() { SearchText = searchText }, default);
            return result;
        }
    }
}
