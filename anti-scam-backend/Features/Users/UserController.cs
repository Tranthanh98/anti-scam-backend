using anti_scam_backend.Features.Users.Command;
using anti_scam_backend.Features.Users.Queries;
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
using static anti_scam_backend.Features.Users.Queries.Detail;

namespace anti_scam_backend.Features.Users
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel<Login.AuthenticationModel>> Register ([FromBody] Register.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpPost]
        public async Task<ResponseModel<Login.AuthenticationModel>> Login([FromBody] Login.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }

        [HttpGet]
        [Authorize]
        public async Task<ResponseModel<UserProfile>> Detail()
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);

            var result = await _mediator.Send(new Detail.Query() { UserId = userId }, default);
            return result;
        }
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> Edit(Edit.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;

            var result = await _mediator.Send(command, default);
            return result;
        }

        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> ChangePassword(ChangePassword.Command command)
        {
            StringValues userId;
            Request.Headers.TryGetValue("X-UserId", out userId);
            command.UserId = userId;

            var result = await _mediator.Send(command, default);
            return result;
        }
        [HttpPost]
        public async Task<ResponseModel> ResetPassword (ResetPassword.Command command)
        {
            var result = await _mediator.Send(command, default);
            return result;
        }
    }
}
