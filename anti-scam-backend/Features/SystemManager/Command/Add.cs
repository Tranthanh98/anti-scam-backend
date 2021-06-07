using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using anti_scam_backend.Services.Email;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.SystemManager.Command
{
    public static class Add
    {
        public class Command : BaseCommandQuery<ResponseModel>
        {
            [FromBody]
            public string Name { get; set; }
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
                    ack.Messages.Add("UserId không hợp lệ");
                    return ack;
                }
                var user = await _context.Users.FirstOrDefaultAsync(i => i.Id == userId);
                if (user == null)
                {
                    ack.Messages.Add("UserId không hợp lệ");
                    return ack;
                }
                var type = new Domain.Entities.Type()
                {
                    Name = request.Name
                };

                _context.Types.Add(type);

                await _context.SaveChangesAsync();

                if (user.Email != "antiscam.contact@gmail.com")
                {
                    var subject = "[AntiScam - Thông báo thêm thể loại báo cáo]";
                    var message = $"<h2>User {user.Email} đã thêm một thể loại báo cáo</h2><div>Thể loại được thêm là: <div style='font - size:20px; color: red; font - weight:bold'>{request.Name}</div></div>";

                    await _emailService.SendEmailAsync("antiscam.contact@gmail.com", subject, message);

                }

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
