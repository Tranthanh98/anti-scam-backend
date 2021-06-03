using anti_scam_backend.Features.UserManger.Command;
using anti_scam_backend.Features.UserManger.Queries;
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
using static anti_scam_backend.Features.UserManger.Queries.Get;
using static anti_scam_backend.Features.UserManger.Queries.GetDefaultData;

namespace anti_scam_backend.Features.UserManger
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class UserManagerController : ControllerBase
    {
        private IMediator _mediator;
        public UserManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel<DefaultModel>> GetDefault()
        {
            var result = await _mediator.Send(new GetDefaultData.Query(), default);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel<Pagination<UserManagerModel>>> Get(Get.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }
        [HttpPost]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel> Create(Create.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel> DetailAdmin(Guid id)
        {
            var result = await _mediator.Send(new Detail.Query() { UserId = id}, default);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel> ChangeInforAdmin(ChangeInfoAdmin.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }
    }
}
