using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using anti_scam_backend.Services;
using anti_scam_backend.Services.Helper;
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
    public static class ChangePassword
    {
        public class Command : IRequest<ResponseModel>
        {
            [FromBody]
            public string OldPassword { get; set; }
            [FromBody]
            public string NewPassword { get; set; }
            [FromBody]
            public string ConfirmPassword { get; set; }
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

                var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == userId);
                if (user == null)
                {
                    ack.Messages.Add("Tài khoản không tồn tại.");
                    return ack;
                }
                if(request.NewPassword != request.ConfirmPassword)
                {
                    ack.Messages.Add("Mật khẩu nhập lại không đúng.");
                    return ack;
                }
                var checkOldPass = HashPasswordService.VerifyPassword(user, request.OldPassword);
                if (!checkOldPass)
                {
                    ack.Messages.Add("Mật khẩu cũ không đúng.");
                    return ack;
                }
                var salt = RandomString.Random(6);

                var hashPw = HashPasswordService.HashPassword(user, request.NewPassword + salt);

                user.Password = hashPw;
                user.Salt = salt;

                await _context.SaveChangesAsync();

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
