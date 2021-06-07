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
    public static class Delete
    {
        public class Command : BaseCommandQuery<ResponseModel>
        {
            [FromBody]
            public int Id { get; set; }
            public int IdReplace { get; set; }
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

                var type = await _context.Types.FirstOrDefaultAsync(i => i.Id == request.Id);
                if (type == null)
                {
                    ack.Messages.Add("Thể loại không hợp lệ");
                    return ack;
                }
                

                var typeReplace = await _context.Types.FirstOrDefaultAsync(i => i.Id == request.IdReplace);
                if(typeReplace == null)
                {
                    ack.Messages.Add("Thể loại thay thế không hợp lệ");
                    return ack;
                }
                if(type.Id == typeReplace.Id)
                {
                    ack.Messages.Add("Không thể thay thế bằng thể loại bạn chọn xóa");
                    return ack;
                }

                var allTypePosts = _context.TypePosts.Where(i => i.TypeId == request.Id);
                await allTypePosts.ForEachAsync(i =>
                {
                    i.TypeId = request.IdReplace;
                });

                _context.Types.Remove(type);

                await _context.SaveChangesAsync();

                if (user.Email != "antiscam.contact@gmail.com")
                {
                    var subject = "[AntiScam - Thông báo xóa thể loại báo cáo]";
                    var message = $"<h2>User {user.Email} đã xóa thể loại báo cáo {type.Name}</h2>" +
                        $"<div>Các bài viết của thể loại được xóa sẽ chuyển sang thể loại {typeReplace.Name}</div>";

                    await _emailService.SendEmailAsync("antiscam.contact@gmail.com", subject, message);

                }

                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
