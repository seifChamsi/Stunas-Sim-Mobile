using AutoMapper;
using StunasMobile.Core;
using StunasMobile.Entities.Entitites;

namespace StunasMobile.api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Mobile, MobileModelView>().ReverseMap();
            CreateMap<Mobile, UpdateMobileModelView>().ReverseMap();
            CreateMap<User,SignupModelView>().ReverseMap();
        }
    }
}