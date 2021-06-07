using anti_scam_backend.Domain.Infrastructure;
using anti_scam_backend.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.SystemManager.Queries
{
    public static class GetRoles
    {
        public class Query : IRequest<ResponseModel<List<Selectable<int>>>>
        {

        }
        public class Handler : IRequestHandler<Query, ResponseModel<List<Selectable<int>>>>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel<List<Selectable<int>>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var types = (await _context.Types
                    .AsNoTracking()
                    .Include(i=> i.TypePosts)
                    .ToListAsync())
                    .Select(i => new Selectable<int>(i.Id.ToString(), i.Name) { Data = i.TypePosts.Count()}).ToList();

                return new ResponseModel<List<Selectable<int>>>()
                {
                    IsSuccess = true,
                    Data = types
                };
            }
        }
    }
}
