using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Default.Queries
{
    public static class DefaultReport
    {
        public class DefaultReportModel
        {
            public List<Selectable> Types { get; set; }
        }
        public class Query : IRequest<ResponseModel<DefaultReportModel>>
        {

        }
        public class Handler : IRequestHandler<Query, ResponseModel<DefaultReportModel>>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel<DefaultReportModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var types = await _context.Types.ToListAsync(cancellationToken);
                var ack = new ResponseModel<DefaultReportModel>();

                ack.Data = new DefaultReportModel()
                {
                    Types = types.Select(i => new Selectable(i.Id.ToString(), i.Name)).ToList()
                };
                ack.Data.Types.Add(new Selectable("0", "Tất cả"));
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
