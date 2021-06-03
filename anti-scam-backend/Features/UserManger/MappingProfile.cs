using anti_scam_backend.Features.UserManger.Queries;
using anti_scam_backend.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.UserManger
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Get user
            CreateMap<Domain.Entities.User, Get.UserManagerModel>();

            //detail
            CreateMap<Domain.Entities.User, Detail.AdminDetail>()
                .ForMember(d => d.TotalPostsReport, o => o.MapFrom(s => s.Posts.Where(i => i.KindOf == Domain.Model.EKindOf.Cheat).Count()))
                .ForMember(d => d.TotalPostsReputation, o => o.MapFrom(s => s.Posts.Where(i => i.KindOf == Domain.Model.EKindOf.Reputation).Count()))
                .ForMember(d=>d.AdminRoles, o=> o.MapFrom(s=> s.RoleAdmins.Select(i=>i.RoldId)));

        }
    }
}
