using anti_scam_backend.Domain.Entities;
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

namespace anti_scam_backend.Features.PostManager.Queries
{
    public static class GetDefaultData
    {
        public class PostManageModel
        {
            public List<Selectable> TypeOptions { get; set; }
            public List<Selectable> StatusOptions { get; set; }
        }

        
        public class Query : IRequest<ResponseModel<PostManageModel>>
        {
        }
        public class Handler : IRequestHandler<Query, ResponseModel<PostManageModel>>
        {
            private AntiScamContext _context;
            public Handler(AntiScamContext context)
            {
                _context = context;
            }
            public async Task<ResponseModel<PostManageModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var typesOptions =
                    (await _context.Types
                        .AsNoTracking()
                        .ToListAsync())
                        .Select(i => new Selectable(i.Id.ToString(), i.Name)).ToList();
                typesOptions.Add(new Selectable("0", "Tất cả"));

                var statusOptions = EnumHelper.GetSelectableOptions<EStatusPost>();
                statusOptions.Add(new Selectable("0", "Tất cả"));

                var ack = new ResponseModel<PostManageModel>()
                {
                    IsSuccess = true,
                    Data = new PostManageModel()
                    {
                        StatusOptions = statusOptions,
                        TypeOptions = typesOptions,
                    }
                };

                return ack;
            }
        }
    }
}
