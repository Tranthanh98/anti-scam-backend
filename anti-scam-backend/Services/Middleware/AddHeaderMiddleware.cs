using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Middleware
{
    public class AddHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userId = context.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier);
            if(userId != null)
            {
                context.Request.Headers.Add("X-UserId", userId.Value);
            }

            await _next(context);
        }
    }
}
