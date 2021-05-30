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

namespace anti_scam_backend.Features.Comments.Queries
{
    public static class Get
    {
        public class CommentModel
        {
            public string UserName { get; set; }
            public int Id { get; set; }
            public DateTimeOffset? CreatedDate { get; set; }
            public string Content { get; set; }
            public Guid? PostId { get; set; }
        }
        public class Query : IRequest<ResponseModel<Pagination<CommentModel>>>
        {
            [FromBody]
            public Guid PostId { get; set; }
            [FromBody]
            public int CurrentPage { get; set; }
        }
        public class Handler : IRequestHandler<Query, ResponseModel<Pagination<CommentModel>>>
        {
            private AntiScamContext _context;
            private IMapper _mapper;
            public Handler(AntiScamContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ResponseModel<Pagination<CommentModel>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var comments = await _context.Comments
                    .AsNoTracking()
                    .Include(i=> i.User)
                    .Where(i => i.PostId == request.PostId)
                    .ToListAsync(cancellationToken);

                var data = _mapper.Map<List<CommentModel>>(comments);
                return new ResponseModel<Pagination<CommentModel>>()
                {
                    IsSuccess = true,
                    Data = new Pagination<CommentModel>()
                    {
                        CurrentPage = request.CurrentPage,
                        Total = data.Count(),
                        Data = data
                    }
                };
            }
        }
    }
}
