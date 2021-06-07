using anti_scam_backend.Features.SystemManager.Command;
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

namespace anti_scam_backend.Features.SystemManager
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SystemManagerController : ControllerBase
    {
        private IMediator _mediator;
        public SystemManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel<List<Selectable<int>>>> GetRoles()
        {
            var result = await _mediator.Send(new Queries.GetRoles.Query(), default);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel> Add(Add.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }

        [HttpPost]
        [Authorize(Roles = "SystemManager")]
        public async Task<ResponseModel> Delete(Delete.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;
            var result = await _mediator.Send(command, default);
            return result;
        }
    }
}
