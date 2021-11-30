using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    //class : referans tip olabilir.
    //IEntity : IEntity veya IEntity implemente eden bir nesne olabilir.
    //new() : new'lenebilir olmalıdır.(Yani IEntity new'lenemyeceginden artik cagrilamaz sadece nesneler cagrilir.)
    public interface IEntityRepository<T> where T:class, IEntity, new() 
    {
        //tabloların tutulduğu Repodur. 

        List<T> GetAll(Expression<Func<T, bool>> filter = null); 
        //GetAll'a normalde filtreler Linq sorgulariyla getirilir. Bunlar delege denen yapılardır. bu sekilde kullanilirlar.
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
