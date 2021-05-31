using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using anti_scam_backend.Services;
using anti_scam_backend.Services.Email;
using anti_scam_backend.Services.Helper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Users.Command
{
    public static class ResetPassword
    {
        public class Command : IRequest<ResponseModel>
        {
            [EmailAddress]
            public string Email { get; set; }
        }
        public class Handler : IRequestHandler<Command, ResponseModel>
        {
            private IEmailService _emailService;
            private AntiScamContext _context;
            public Handler(AntiScamContext context, IEmailService emailService)
            {
                _context = context;
                _emailService = emailService;
            }
            public async Task<ResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel();
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email);
                if(user == null)
                {
                    ack.Messages.Add("Email chưa đăng ký tài khoản.");
                    return ack;
                }
                var salt = RandomString.Random(6);
                var newPassword = RandomString.Random(6);

                var hashPw = HashPasswordService.HashPassword(user, newPassword + salt);

                user.Password = hashPw;
                user.Salt = salt;

                await _context.SaveChangesAsync();

                var subject = "[Reset mật khẩu Anti Scam]";
                var message = $"<h2>Tài khoản Anti Scam của bạn được yêu cầu reset mật khẩu</h2><p>Vui lòng không cung cấp thông tin này cho bất kỳ ai</p><div>Mật khẩu mới của bạn là: <div style='font - size:20px; color: red; font - weight:bold'>{newPassword}</div></div>";

                await _emailService.SendEmailAsync(request.Email, subject, message);

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
