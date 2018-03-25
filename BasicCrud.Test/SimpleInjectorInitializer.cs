using BasicCrud.Data.Context;
using BasicCrud.Data.Domain;
using BasicCrud.Data.Repositories;
using BasicCrud.Logic;
using BasicCrud.Logic.Security;
using SimpleInjector;

namespace BasicCrud.Test
{
    public static class SimpleInjectorInitializer
    {
        public static Container Initialize()
        {
            var container = new Container();
            container.Options.DefaultLifestyle = Lifestyle.Singleton;
            
            container.Register<DataContext>();
            container.Options.AllowOverridingRegistrations = true;

            // Reg Logic 
            container.Register<IAbstractLogic<UserDomain>, UserLogic>();
            container.Register<IAbstractLogic<UserSessionDomain>, SessionManager>();

            // Generic repo domain and entity 
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register(typeof(IDomainRepository<,>), typeof(DomainRepository<,>));
            container.Verify();
            
            return container;
        }
    }
}
