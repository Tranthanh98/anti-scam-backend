using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Comments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Queries get command
            CreateMap<Domain.Entities.Comment, Queries.Get.CommentModel>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.UserName));

            //create comment
            CreateMap<Command.Create.Command, Domain.Entities.Comment>();
            CreateMap<Domain.Entities.Comment, Command.Create.Command>();

            
        }
    }
}
