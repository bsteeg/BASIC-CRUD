using BasicCrud.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BasicCrud.Data.Repositories
{
    public interface IRepository <Entity> where Entity : class, IEntity
    {
        void Create(List<Entity> entities);
        int Create(Entity entity);
        void Remove(Entity entity);
        void Remove(Expression<Func<Entity, bool>> expression);
        void Update(Entity entity);
        Entity Get(int id);
        Entity Get(Expression<Func<Entity, bool>> expression);
        List<Entity> List(int begin, int limit);
        List<Entity> List();
    }
}
