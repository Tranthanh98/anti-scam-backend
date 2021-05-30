using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Users.Queries
{
    public static class Detail
    {
        public class UserProfile
        {
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public DateTimeOffset? JoinedDate { get; set; }
            public string Email { get; set; }
            public int TotalPosts { get; set; }
        }
        public class Query : IRequest<ResponseModel<UserProfile>>
        {
            public string UserId { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<UserProfile>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<UserProfile>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<UserProfile>();
                Guid userId;
                Guid.TryParse(request.UserId, out userId);
                if(userId == default)
                {
                    ack.Messages.Add("Tài khoản không tồn tại");
                    return ack;
                }
                var user = await _context.Users
                    .AsNoTracking()
                    .Include(i=> i.Posts)
                    .FirstOrDefaultAsync(i => i.Id == userId, cancellationToken);
                if(user == null)
                {
                    ack.Messages.Add("Tài khoản không tồn tại");
                    return ack;
                }
                var data = _mapper.Map<UserProfile>(user);
                ack.Data = data;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
