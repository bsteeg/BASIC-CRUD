using BasicCrud.Data.Context;
using BasicCrud.Data.Domain;
using BasicCrud.Data.Repositories;
using BasicCrud.Logic;
using BasicCrud.Logic.Security;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;

namespace BasicCrud.Webapi
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            
            container.Register<DataContext>();
            container.Options.AllowOverridingRegistrations = true;

            // Reg Logic 
            container.Register<IAbstractLogic<UserDomain>, UserLogic>();
            container.Register<IAbstractLogic<UserSessionDomain>, SessionManager>();

            // Generic repo domain and entity 
            container.Register(typeof(IRepository<>), typeof(Repository<>));
            container.Register(typeof(IDomainRepository<,>), typeof(DomainRepository<,>));
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}