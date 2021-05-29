using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace anti_scam_backend.Model
{
    public class BaseCommandQuery<T> : IRequest<T>
    {
        [FromHeader(Name = ClaimTypes.NameIdentifier)]
        public string UserId { get; set; }
    }
}
