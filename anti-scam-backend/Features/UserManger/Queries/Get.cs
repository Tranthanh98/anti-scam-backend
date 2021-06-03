using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Model;
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

namespace anti_scam_backend.Features.UserManger.Queries
{
    public static class Get
    {
        public class UserManagerModel
        {
            public Guid Id { get; set; }
            public string UserName { get; set; }
            public DateTimeOffset? JoinedDate { get; set; }
            public string Email { get; set; }
            public bool? IsActive { get; set; }
            public string CodeValidate { get; set; }
            public bool IsAdmin { get; set; }
        }
        public class Query : Pagination, IRequest<ResponseModel<Pagination<UserManagerModel>>>
        {
            [FromBody]
            public string SearchText { get; set; }
            [FromBody]
            public EStatusAdmin StatusId { get; set; }
            [FromBody]
            public int RoleId { get; set; }
            [FromBody]
            public bool IsAdmin { get; set; }
        }

        public class Handler : IRequestHandler<Query, ResponseModel<Pagination<UserManagerModel>>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<Pagination<UserManagerModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = _context.Users
                    .AsNoTracking()
                    .Where(i=> i.IsAdmin == request.IsAdmin)
                    .Include(i=>i.RoleAdmins)
                    .ThenInclude(i=> i.Role)
                    .OrderByDescending(i=> i.JoinedDate)
                    .AsEnumerable();
                if(request.StatusId != EStatusAdmin.Undefined)
                {
                    if(request.StatusId == EStatusAdmin.Acitve)
                    {
                        users = users.Where(i => i.IsActive != null && (bool)i.IsActive == true);
                    }
                    else
                    {
                        users = users.Where(i => (bool)i.IsActive == false);
                    }
                }
                
                if(request.RoleId != default)
                {
                    users = users.Where(i => i.RoleAdmins.Select(i => i.RoldId).Contains(request.RoleId));
                }
                if (!String.IsNullOrEmpty(request.SearchText))
                {
                    var str = StringHelper.RemoveVietNameTone(request.SearchText);
                    users = users.Where(i => i.Email.Contains(str) || 
                                            StringHelper.RemoveVietNameTone(i.UserName).Contains(str)||
                                            i.Id.ToString().ToLower().Contains(str));
                }

                if(request.PageSize == default)
                {
                    request.PageSize = 10;
                }

                var data = users.Skip(request.Skip()).Take(request.PageSize).ToList();

                var result = _mapper.Map<List<UserManagerModel>>(data);

                return new ResponseModel<Pagination<UserManagerModel>>()
                {
                    IsSuccess = true,
                    Data = new Pagination<UserManagerModel>()
                    {
                        CurrentPage = request.CurrentPage,
                        Data = result,
                        PageSize = request.PageSize,
                        Total = users.Count()
                    }
                };
            }
        }
    }
}
