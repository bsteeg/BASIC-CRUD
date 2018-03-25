using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Repositories;
using BasicCrud.Logic.Security;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BasicCrud.Webapi.Controllers.Security
{
    public class AuthorizeTag : AuthorizeAttribute
    {
        private readonly SessionManager _sessionManager;
        private readonly IRepository<UserSession> _sessionRepo;
        private readonly IDomainRepository<UserSession, UserSessionDomain> _sessionDomainRepo;

        public AuthorizeTag()
        {
            _sessionRepo = new Repository<UserSession>();
            _sessionDomainRepo = new DomainRepository<UserSession, UserSessionDomain>(_sessionRepo);
            _sessionManager = new SessionManager(_sessionDomainRepo);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if(actionContext.Request.Headers.Authorization != null)
                return _sessionManager.Verify(actionContext.Request.Headers.Authorization.ToString());
            return false;
        }
    }
}