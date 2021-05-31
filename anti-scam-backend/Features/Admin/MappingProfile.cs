using anti_scam_backend.Domain.Entities;
using anti_scam_backend.Features.Admin.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Admin
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //login
            CreateMap<User, Login.UserModel>()
                    .ForMember(des => des.TotalPosts, opt => opt.MapFrom(src => src.Posts.Count()))
                    .ForMember(des => des.IsAuth, opt => opt.MapFrom(src => src.IsActive));

                //Detail query
                //CreateMap<User, Detail.UserProfile>()
                //    .ForMember(d => d.TotalPosts, o => o.MapFrom(s => s.Posts.Count));
        }
    }
}
