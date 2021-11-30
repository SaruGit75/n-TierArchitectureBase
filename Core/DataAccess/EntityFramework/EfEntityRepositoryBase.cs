using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //evrensel classimiz
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposible pattern implemantation of c#(using bittigi anda garbage collector tarafindan new'lenen sey bellekten toplanir.
            using (TContext context = new TContext())
            {//using ile daha performansli bir yapi olusur. Ayrilan alani en sonunda toplar.

                var addedEntity = context.Entry(entity); //Entry -> veri kaynaginia git. Disaridan gonderilen nesneyi ona eslestir.
                addedEntity.State = EntityState.Added; //Aldik. Simdi bununla ne yapmasi gerektigini belirtiyoruz.
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                // arka planda "select * from" table calisir
                //filter null'mı bak. Degilse filtreli getir. null ise filtresiz getir.
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
