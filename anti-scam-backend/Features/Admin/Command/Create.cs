using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Admin.Command
{
    public static class Create
    {
        public class Command : IRequest<ResponseModel>
        {
            [FromBody]
            public string Email { get; set; }
            [FromBody]
            public string Password { get; set; }
            [FromBody]
            public string ConfirmPassword { get; set; }
            [FromBody]
            public string UserName { get; set; }

        }
    }
}
