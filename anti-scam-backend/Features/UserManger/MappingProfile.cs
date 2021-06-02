using anti_scam_backend.Features.UserManger.Queries;
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
        }
    }
}
