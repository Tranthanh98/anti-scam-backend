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

namespace anti_scam_backend.Features.UserManger.Command
{
    public static class Create
    {
        public class Command : BaseCommandQuery<ResponseModel>
        {
            [FromBody]
            public string Email { get; set; }
            [FromBody]
            public string Password { get; set; }
            [FromBody]
            public string UserName { get; set; }
            [FromBody]
            public List<int> AdminRoles { get; set; }
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
                if (userId == default)
                {
                    ack.Messages.Add("Bạn không có quyền tạo admin");
                    return ack;
                }
                var user = await _context.Users
                    .Include(i => i.RoleAdmins)
                    .FirstOrDefaultAsync(i => i.Id == userId);
                if (user == null)
                {
                    ack.Messages.Add("Bạn không có quyền tạo admin");
                    return ack;
                }

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

                if (user.IsAdmin && (bool)user.IsActive && user.RoleAdmins.Any(i=> i.RoldId == 1))
                {
                    var salt = RandomString.Random(6);
                    var codeValidate = RandomString.Random(6, "01234567890123456789");

                    var hashPw = HashPasswordService.HashPassword(new Domain.Entities.User(), request.Password + salt);

                    var userAdmin = new Domain.Entities.User()
                    {
                        Id = Guid.NewGuid(),
                        IsActive = true,
                        IsAdmin = true,
                        Email = request.Email,
                        UserName = request.UserName,
                        JoinedDate = DateTimeOffset.UtcNow,
                        Password = hashPw,
                        RoleAdmins = request.AdminRoles.Select(i => new Domain.Entities.RoleAdmin() { RoldId = i }).ToList(),
                        Salt = salt,
                        CreateBy = user.Email,
                    };
                    _context.Add(userAdmin);
                    await _context.SaveChangesAsync();

                    return new ResponseModel() { IsSuccess = true };
                }
                return new ResponseModel() { IsSuccess = false};
            }
        }
    }
}
