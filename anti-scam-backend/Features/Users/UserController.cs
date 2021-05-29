using anti_scam_backend.Features.Users.Command;
using anti_scam_backend.Features.Users.Queries;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
