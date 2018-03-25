using BasicCrud.Data.Context;
using BasicCrud.Data.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace BasicCrud.Data.Repositories
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity
    {
        public void Create(List<Entity> entities)
        {
            using (var context = new DataContext())
            {
                foreach (var entity in entities) context.GetDbSet<Entity>().Add(entity);
                context.SaveChanges();
            }
        }

        public int Create(Entity entity)
        {
            using (var context = new DataContext())
            {
                context.GetDbSet<Entity>().Add(entity);
                context.SaveChanges();
                return entity.Id;
            }
        }

        public Entity Get(int id)
        {
            using (var context = new DataContext())
            {
                return context.GetDbSet<Entity>().Where(q => q.Id == id).SingleOrDefault();
            }
        }

        public Entity Get(Expression<Func<Entity, bool>> expression)
        {
            using (var context = new DataContext())
            {
                return context.GetDbSet<Entity>().Where(expression).FirstOrDefault();
            }
        }

        public List<Entity> List(int begin, int limit)
        {
            using (var context = new DataContext())
            {
                return context.GetDbSet<Entity>().OrderBy(q => q.Id).Skip(begin).Take(limit).ToList();
            }
        }

        public List<Entity> List()
        {
            using (var context = new DataContext())
            {
                return context.GetDbSet<Entity>().ToList();
            }
        }

        public void Remove(Entity entity)
        {
            using (var context = new DataContext())
            {
                context.GetDbSet<Entity>().Attach(entity);
                context.GetDbSet<Entity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public void Remove(Expression<Func<Entity, bool>> expression)
        {
            using (var context = new DataContext())
            {
                var entities = context.GetDbSet<Entity>().Where(expression).ToList();

                foreach(var entity in entities)
                {
                    context.GetDbSet<Entity>().Attach(entity);
                    context.GetDbSet<Entity>().Remove(entity);
                }

                context.SaveChanges();
            }
        }

        public void Update(Entity entity)
        {
            using (var context = new DataContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
