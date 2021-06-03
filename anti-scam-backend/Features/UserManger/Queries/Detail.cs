using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.UserManger.Queries
{
    public static class Detail
    {
        public class AdminDetail
        {
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public DateTimeOffset? JoinedDate { get; set; }
            public string Email { get; set; }
            public int TotalPostsReport { get; set; }
            public int TotalPostsReputation { get; set; }

            public bool IsActive { get; set; }
            public List<int> AdminRoles { get; set; }
        }
        public class Query : IRequest<ResponseModel<AdminDetail>>
        {
            [FromBody]
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ResponseModel<AdminDetail>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<AdminDetail>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<AdminDetail>();
                if(request.UserId == default)
                {
                    ack.Messages.Add("UserId không đúng.");
                    return ack;
                }
                var user = await _context.Users.AsNoTracking()
                    .Where(i => i.Id == request.UserId)
                    .Include(i => i.Posts)
                    .Include(i => i.RoleAdmins)
                    .ThenInclude(i => i.Role)
                    .FirstOrDefaultAsync();

                if(user == null)
                {
                    ack.Messages.Add("User không tồn tại");
                    return ack;
                }

                var result = _mapper.Map<AdminDetail>(user);

                ack.Data = result;
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
