using anti_scam_backend.Features.PostManager.Queries;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
