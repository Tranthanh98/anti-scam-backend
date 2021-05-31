using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Features.Users.Queries;
using anti_scam_backend.Model;
using anti_scam_backend.Services;
using anti_scam_backend.Services.Email;
using anti_scam_backend.Services.Helper;
using AutoMapper;
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
    public static class Register
    {

        public class Command : IRequest<ResponseModel<Login.AuthenticationModel>>
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
        public class Handler : IRequestHandler<Command, ResponseModel<Login.AuthenticationModel>>
        {
            private IEmailService _emailService;
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IEmailService emailService, IMapper mapper)
            {
                _context = context;
                _emailService = emailService;
                _mapper = mapper;
            }
            public async Task<ResponseModel<Login.AuthenticationModel>> Handle(Command request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<Login.AuthenticationModel>();
                var checkAccount = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email);
                if (checkAccount != null)
                {
                    ack.Messages.Add("Email đã đăng ký tài khoản");
                    return ack;
                }
                if (request.Password.Length < 6)
                {
                    ack.Messages.Add("Password phải có độ dài hơn 6");
                    return ack;
                }
                if (!request.Password.Equals(request.ConfirmPassword))
                {
                    ack.Messages.Add("Mật khẩu nhập lại không khớp");
                    return ack;
                }

                var salt = RandomString.Random(6);
                var codeValidate = RandomString.Random(6, "01234567890123456789");

                var hashPw = HashPasswordService.HashPassword(new Domain.Entities.User(), request.Password + salt);
                var user = new Domain.Entities.User()
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    IsActive = true,
                    JoinedDate = DateTimeOffset.UtcNow,
                    Password = hashPw,
                    Salt = salt,
                    UserName = request.UserName,
                    CodeValidate = codeValidate,
                    IsAdmin = false
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                //var subject = "[Xác thực tài khoản AntiScam]";
                //var message = $"<h2>Mã xác thực tài khoản AntiScam VietNam</h2><p>Vui lòng không cung cấp mà này cho bất kỳ ai</p><div>Mã xác thực tài khoản của bạn là: <div style='font - size:20px; color: red; font - weight:bold'>{codeValidate}</div></div>";

                //await _emailService.SendEmailAsync(request.Email, subject, message);

                var token = TokenService.CreateToken(user);

                var userMapper = _mapper.Map<Login.UserModel>(user);

                ack.Data = new Login.AuthenticationModel()
                {
                    Token = token,
                    User = userMapper
                };

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
