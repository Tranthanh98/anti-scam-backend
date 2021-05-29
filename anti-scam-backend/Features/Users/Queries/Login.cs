using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using anti_scam_backend.Services;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Users.Queries
{
    public static class Login
    {
        public class UserModel
        {
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public DateTimeOffset? JoinedDate { get; set; }
            public string Email { get; set; }
            public bool? IsAuth { get; set; }
            public int TotalPosts { get; set; }
            public string ImageAvatar { get; set; }
        }
        public class AuthenticationModel
        {
            public UserModel User { get; set; }
            public string Token { get; set; }
        }
        public class Query : IRequest<ResponseModel<AuthenticationModel>>
        {
            [FromBody]
            public string Email { get; set; }
            [FromBody]
            public string Password { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<AuthenticationModel>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<AuthenticationModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ack = new ResponseModel<AuthenticationModel>();
                var user = await _context.Users.Include(i=> i.Posts).FirstOrDefaultAsync(i => i.Email == request.Email);
                if(user == null)
                {
                    ack.Messages.Add("Email không tồn tại.");
                    return ack;
                }
                var validate = HashPasswordService.VerifyPassword(user, request.Password);
                if (!validate)
                {
                    ack.Messages.Add("Mật khẩu không đúng.");
                    return ack;
                }

                var token = TokenService.CreateToken(user);
                var result = _mapper.Map<UserModel>(user);

                ack.Data = new AuthenticationModel()
                {
                    User = result,
                    Token = token
                };
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
