using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BasicCrud.Data.Repositories
{
    public interface IDomainRepository<Entity, Domain>
        where Entity : class, IEntity
        where Domain : class, IDomain
    {
        void Create(List<Domain> domain);
        int Create(Domain domain);
        void Remove(Domain domain);
        void Remove(Expression<Func<Domain, bool>> expression);
        void Update(Domain domain);
        Domain Get(int id);
        Domain Get(Expression<Func<Domain, bool>> expression);
        List<Domain> List(int begin, int limit);
        List<Domain> List();
    }
}
