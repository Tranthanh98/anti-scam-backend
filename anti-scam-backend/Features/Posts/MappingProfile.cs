using anti_scam_backend.Domain.Model;
using anti_scam_backend.Features.Posts.Queries;
using anti_scam_backend.Services.Helper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace anti_scam_backend.Features.Posts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Posts, Get.PostModel>()
                .ForMember(des => des.KindOfName, opt => opt.MapFrom(i => EnumHelper.GetDescription((EKindOf)i.KindOf)))
                .ForMember(des => des.Writer, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(des => des.ReviewNumber, opt => opt.MapFrom(src => src.View))
                .ForMember(des => des.KindOf, o => o.MapFrom(s => (int)s.KindOf))
                .ForMember(des => des.TotalComment, o => o.MapFrom(s => s.Comments.Count()));
        }
    }
}
