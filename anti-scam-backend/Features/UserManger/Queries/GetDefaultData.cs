using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Model;
using anti_scam_backend.Services.Helper;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.UserManger.Queries
{
    public static class GetDefaultData
    {
        public class DefaultModel
        {
            public List<Selectable> AdminRoles { get; set; }
            public List<Selectable> AdminStatus { get; set; }

        }
        public class Query : BaseCommandQuery<ResponseModel<DefaultModel>>
        {

        }
        public class Handler : IRequestHandler<Query, ResponseModel<DefaultModel>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<DefaultModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var adminRoles = (await _context.Roles.ToListAsync()).Select(i => new Selectable(i.Id.ToString(), i.Description)).ToList();
                var adminStatus = EnumHelper.GetSelectableOptions<EStatusAdmin>();

                adminRoles.Add(new Selectable("0", "Tất cả"));
                adminStatus.Add(new Selectable("0", "Tất cả"));


                return new ResponseModel<DefaultModel>()
                {
                    IsSuccess = true,
                    Data = new DefaultModel()
                    {
                        AdminRoles = adminRoles,
                        AdminStatus = adminStatus
                    }
                };
            }
        }
    }
}
