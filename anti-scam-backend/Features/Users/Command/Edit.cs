using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Users.Command
{
    public static class Edit
    {
        public class Command : IRequest<ResponseModel>
        {
            [FromBody]
            public string NewUserName { get; set; }
            public string UserId { get; set; }
        }
        public class Handler : IRequestHandler<Command, ResponseModel>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel();
                Guid userId;
                Guid.TryParse(request.UserId, out userId);
                if(userId == default)
                {
                    ack.Messages.Add("User Id không đúng.");
                    return ack;
                }
                if (String.IsNullOrEmpty(request.NewUserName))
                {
                    ack.Messages.Add("Tên không được để trống.");
                    return ack;

                }
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == userId);
                if(user == null)
                {
                    ack.Messages.Add("Tài khoản không tồn tại.");
                    return ack;
                }
                user.UserName = request.NewUserName;
                await _context.SaveChangesAsync();

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
