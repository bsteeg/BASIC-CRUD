using BasicCrud.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BasicCrud.Logic
{
    public interface IAbstractLogic<Domain> where Domain : class, IDomain
    {
        int Create(Domain domain);
        void Remove(Domain domain);
        void Remove(Expression<Func<Domain,bool>> expression);
        void Update(Domain domain);
        Domain Get(int id);
        Domain Get(Expression<Func<Domain, bool>> expression);
        IEnumerable<Domain> List(int begin, int limit);
        IEnumerable<Domain> List();
    }
}
