using BasicCrud.Data.Domain;
using BasicCrud.Logic;
using BasicCrud.Webapi.Controllers.Security;
using System.Collections.Generic;
using System.Web.Http;

namespace BasicCrud.Webapi.Controllers.BaseController
{
    public abstract class BaseController<Domain> : ApiController where Domain : class, IDomain
    {
        private IAbstractLogic<Domain> _logic;

        #region [=== Constructor ===]
        public BaseController(IAbstractLogic<Domain> logic)
        {
            _logic = logic;
        }
        #endregion

        #region [=== Controller methods ===]
        [HttpGet]
        [AuthorizeTag]
        public virtual IEnumerable<Domain> List() => _logic.List();

        [HttpGet]
        [AuthorizeTag]
        public virtual IEnumerable<Domain> List(int begin, int limit) => _logic.List(begin, limit);
        
        [HttpGet]
        [AuthorizeTag]
        public virtual List<Domain> Get(int Id)
        {
            return new List<Domain>() {
                _logic.Get(Id)
            };
        }

        [HttpPost]
        [AuthorizeTag]
        public virtual int Create(Domain domain) => _logic.Create(domain);
        
        [HttpPost]
        [AuthorizeTag]
        public virtual void Update(Domain domain) => _logic.Update(domain);
        
        [HttpPost]
        [AuthorizeTag]
        public virtual void Remove(Domain domain) =>_logic.Remove(domain);
        
        #endregion
    }
}