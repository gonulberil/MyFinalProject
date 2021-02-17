using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    //
    public  class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity>
        where TEntity:class, IEntity, new()
       where TContext:DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDisposible pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //verikaynağı ile ilişkilendir Entityi bağla 
                addedEntity.State = EntityState.Added; //ekleme oalrak durumunu set et
                context.SaveChanges(); //ekle şimdi yap

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

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) //BİR FİLTRE VEREBİLSİN AMA İSTERSE VERMEYEDEBİLİR DEFAULTU NULL YANİ
        {
            using (TContext context = new TContext())
            {
                //filtre null mı ? evet ise tümüNü getir değilse :
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();  //dbset teki tabloyu listeye çevir product tablosuna yerleş (select*from products
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
