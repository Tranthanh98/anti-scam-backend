using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Default
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultPageController : ControllerBase
    {
        private IMediator _mediator;
        public DefaultPageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("{kindOf}")]
        public async Task<ResponseModel<Default.Queries.DefaultReport.DefaultReportModel>> GetReportDefaultData(int kindOf)
        {
            var result = await _mediator.Send(new Default.Queries.DefaultReport.Query() { KindOf = kindOf}, default);
            return result;
        }
    }
}
