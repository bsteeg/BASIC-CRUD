using AutoMapper;
using BasicCrud.Data.Entities;

namespace BasicCrud.Data.Domain
{
    public class UserSessionMapping
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<UserSession, UserSessionDomain>()
            .ForMember(src => src.User, dest => dest.Ignore())
                .ReverseMap();
        }
    }
}
