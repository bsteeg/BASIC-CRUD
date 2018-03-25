using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using BasicCrud.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BasicCrud.Logic
{
    public abstract class AbstractLogic<Entity, Domain> : IAbstractLogic<Domain>
        where Domain : class, IDomain
        where Entity : class, IEntity
    {
        private readonly IDomainRepository<Entity, Domain> _domainRepository;

        public AbstractLogic(IDomainRepository<Entity, Domain> domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public int Create(Domain domain) => _domainRepository.Create(domain);
        
        public Domain Get(int id) => _domainRepository.Get(id);
        
        public IEnumerable<Domain> List(int begin, int limit) => _domainRepository.List(begin, limit);
        
        public void Remove(Domain domain) => _domainRepository.Remove(domain);
        
        public void Update(Domain domain) => _domainRepository.Update(domain);

        public Domain Get(Expression<Func<Domain, bool>> expression) => _domainRepository.Get(expression);

        public void Remove(Expression<Func<Domain, bool>> expression) => _domainRepository.Remove(expression);

        public IEnumerable<Domain> List() => _domainRepository.List();
    }
}