using AutoMapper;
using BasicCrud.Data.Domain;

namespace BasicCrud.Data.Mappers
{
    public static class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                UserMapping.Initialize(cfg);
                UserSessionMapping.Initialize(cfg);
            });
        }
    }
}
