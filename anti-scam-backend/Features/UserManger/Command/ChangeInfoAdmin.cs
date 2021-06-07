using anti_scam_backend.Domain.Infrastructure;
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

namespace anti_scam_backend.Features.UserManger.Command
{
    public static class ChangeInfoAdmin
    {
        public class Command : BaseCommandQuery<ResponseModel>
        {
            [FromBody]
            public Guid Id { get; set; }
            [FromBody]
            public string UserName { get; set; }
            [FromBody]
            public DateTimeOffset? JoinedDate { get; set; }
            [FromBody]
            public string Email { get; set; }
            [FromBody]
            public int TotalPostsReport { get; set; }
            [FromBody]
            public int TotalPostsReputation { get; set; }
            [FromBody]
            public bool IsActive { get; set; }
            [FromBody]
            public List<int> AdminRoles { get; set; }
            [FromBody]
            public string Password { get; set; }
        }

        public class Handler : IRequestHandler<Command, ResponseModel>
        {
            private AntiScamContext _context;
            private IEmailService _emailService;
            public Handler(AntiScamContext context, IEmailService emailService)
            {
                _context = context;
                _emailService = emailService;
            }
            public async Task<ResponseModel> Handle(Command request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel();

                Guid userId;
                Guid.TryParse(request.UserId, out userId);
                if (userId == default)
                {
                    ack.Messages.Add("Bạn không có quyền tạo admin");
                    return ack;
                }
                var editer = await _context.Users.FirstOrDefaultAsync(i => i.Id == userId, cancellationToken);
                if(editer == null)
                {
                    ack.Messages.Add("Bạn không có quyền tạo admin");
                    return ack;
                }
                var user = await _context.Users.Include(i => i.RoleAdmins).FirstOrDefaultAsync(i=> i.Id == request.Id, cancellationToken);

                if(user == null)
                {
                    ack.Messages.Add("Người dùng không tồn tại");
                    return ack;
                }
                if(user.Email == "antiscam.contact@gmail.com" && editer.Email != "antiscam.contact@gmail.com")
                {
                    ack.Messages.Add("Không có quyền thay đổi mật khẩu cho admin này");
                    return ack;
                }
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.IsActive = request.IsActive;
                user.CreateBy = editer.Email;
                if (!String.IsNullOrEmpty(request.Password))
                {
                    var salt = RandomString.Random(6);
                    var codeValidate = RandomString.Random(6, "01234567890123456789");

                    var hashPw = HashPasswordService.HashPassword(new Domain.Entities.User(), request.Password + salt);

                    user.Salt = salt;
                    user.Password = hashPw;
                    await _context.SaveChangesAsync(cancellationToken);

                    if (editer.Email != "antiscam.contact@gmail.com")
                    {
                        var subject = "[AntiScam - Thông báo thay đổi mật khẩu admin]";
                        var message = $"<h2>User {editer.Email} đã thay đổi mật khẩu cho admin {user.Email}</h2><div>Mật khẩu mới được thay đổi là: <div style='font - size:20px; color: red; font - weight:bold'>{request.Password}</div></div>";

                        await _emailService.SendEmailAsync("antiscam.contact@gmail.com", subject, message);

                    }
                }
                else
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
