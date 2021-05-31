using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Admin
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ResponseModel<Queries.Login.AuthenticationModel>> Login(Queries.Login.Query query)
        {
            var result = await _mediator.Send(query, default);
            return result;
        }
        
    }
}
