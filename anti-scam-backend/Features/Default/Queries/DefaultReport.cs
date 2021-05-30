using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Domain.Model;
using anti_scam_backend.Model;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static anti_scam_backend.Features.Posts.Queries.Get;

namespace anti_scam_backend.Features.Default.Queries
{
    public static class DefaultReport
    {
        public class DefaultReportModel
        {
            public List<Selectable> Types { get; set; }
            public List<PostModel> NewestPosts { get; set; }
           

        }
        public class Query : IRequest<ResponseModel<DefaultReportModel>>
        {
            public int KindOf { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<DefaultReportModel>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<DefaultReportModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var types = await _context.Types.ToListAsync(cancellationToken);
                var newestPosts = await _context.Posts.Where(i=> i.KindOf == (EKindOf)request.KindOf && (bool)i.IsHighlight).ToListAsync(cancellationToken);

                if(newestPosts.Count == 0)
                {
                    newestPosts = await _context.Posts.Where(i => i.KindOf == (EKindOf)request.KindOf).OrderBy(i=> i.CreatedDate).Take(5).ToListAsync(cancellationToken);
                }
                var ack = new ResponseModel<DefaultReportModel>();

                ack.Data = new DefaultReportModel()
                {
                    Types = types.Select(i => new Selectable(i.Id.ToString(), i.Name)).ToList(),
                    NewestPosts = _mapper.Map<List<PostModel>>(newestPosts)
                };
                ack.Data.Types.Add(new Selectable("0", "Tất cả"));
                ack.IsSuccess = true;
                return ack;
            }
        }
    }
}
