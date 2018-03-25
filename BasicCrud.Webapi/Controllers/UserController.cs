using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Repositories;
using BasicCrud.Logic;
using BasicCrud.Logic.Enums;
using BasicCrud.Webapi.Controllers.BaseController;
using System.Web.Http;

namespace BasicCrud.Webapi.Controllers
{
    public class UserController : BaseController<UserDomain>
    {
        private UserLogic _logic;

        public UserController(IAbstractLogic<UserDomain> abstractuserLogic,
                              IDomainRepository<User, UserDomain> userdomainrepo,
                              IDomainRepository<UserSession, UserSessionDomain> usersessiondomainrepo) : base(abstractuserLogic)
        {
            _logic = new UserLogic(userdomainrepo, usersessiondomainrepo);
        }

        [HttpPost]
        public UserSessionDomain Verify(UserDomain domain) => _logic.VerifyCredentials(domain.Username,domain.Password);

        [HttpPost]
        public override int Create(UserDomain domain)
        {
            return _logic.Register(domain) == CreateUserStatus.userCreated ? 1 : 0;
        } 
     }
}