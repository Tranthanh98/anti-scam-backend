using anti_scam_backend.Domain.Model;
using anti_scam_backend.Features.PostManager.Queries;
using anti_scam_backend.Services.Helper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.PostManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //get post manager
            CreateMap<Domain.Entities.Posts, Get.PostModel>()
                .ForMember(d => d.StatusName, o => o.MapFrom(s => EnumHelper.GetDescription((EStatusPost)s.Status)))
                .ForMember(d => d.KindOfName, o => o.MapFrom(s => EnumHelper.GetDescription((EKindOf)s.KindOf)))
                .ForMember(d => d.AcceptedByName, o => o.MapFrom(s => s.Accepted.UserName))
                .ForMember(d => d.CreatedByName, o => o.MapFrom(s => s.User.Email));

            //detail post
            CreateMap<Domain.Entities.Posts, DetailPost.DetailPostManager>()
                .ForMember(des => des.KindOfName, opt => opt.MapFrom(i => EnumHelper.GetDescription((EKindOf)i.KindOf)))
                .ForMember(des => des.Writer, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(des => des.KindOf, o => o.MapFrom(s => (int)s.KindOf))
                .ForMember(d => d.AcceptedByName, o=> o.MapFrom(s=> s.Accepted.Email))
                .ForMember(d=>d.StatusName, o=> o.MapFrom(s=> EnumHelper.GetDescription(s.Status)));

        }
    }
}
