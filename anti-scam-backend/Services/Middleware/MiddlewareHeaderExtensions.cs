using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Services.Middleware
{
    public static class MiddlewareHeaderExtensions
    {
        public static IApplicationBuilder UseMiddlewareHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AddHeaderMiddleware>();
        }
    }
}
