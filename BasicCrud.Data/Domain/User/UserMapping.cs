using AutoMapper;
using BasicCrud.Data.Entities;

namespace BasicCrud.Data.Domain
{
    public class UserMapping
    {
        public static void Initialize(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<User, UserDomain>()
                .ForMember(src => src.Password, dest => dest.Ignore())
            .ReverseMap();
        }
    }
}
