using AutoMapper;
using BasicCrud.Data.Domain;
using BasicCrud.Data.Entities;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace BasicCrud.Data.Repositories
{
    public class DomainRepository<Entity, Domain> : IDomainRepository<Entity, Domain>
        where Entity : class, IEntity
        where Domain : class, IDomain
    {
        private readonly IRepository<Entity> _repository;

        public DomainRepository(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public void Create(List<Domain> domain)
        {
            var entities = Mapper.Map<List<Entity>>(domain);
            if (entities == null) return;
            _repository.Create(entities);
        }

        public int Create(Domain domain)
        {
            var entity = Mapper.Map<Entity>(domain);
            if (entity == null) return 0;
            return _repository.Create(entity);
        }

        public Domain Get(int id) => Mapper.Map<Domain>(_repository.Get(id));

        public Domain Get(Expression<Func<Domain, bool>> expression) => Mapper.Map<Domain>(_repository.Get(Mapper.Map<Expression<Func<Entity, bool>>>(expression)));
        
        public List<Domain> List(int begin, int limit) => Mapper.Map<List<Domain>>(_repository.List(begin, limit));
        
        public void Remove(Domain domain) => _repository.Remove(Mapper.Map<Entity>(domain));

        public void Remove(Expression<Func<Domain, bool>> expression) => _repository.Remove(Mapper.Map<Expression<Func<Entity, bool>>>(expression));
        
        public void Update(Domain domain) => _repository.Update(Mapper.Map<Entity>(domain));

        public List<Domain> List() => Mapper.Map<List<Domain>>(_repository.List());
    }
}
