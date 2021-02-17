using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

//Core katmanı diğer katmanlardan referans almaz!!!!

namespace Core.DataAccess
{
    //generic constraint
    //class demek referans tip olabilir demek int yazılmaz yani herhangi bir class, 
    //yazamaz hepsinin ortak özelliği IEntity olması virgülle onu belirttik referans tipi oldğunu 
    //IEntity:IEntity olabiilir veya IEntity implemente eden bir nesne olabilir.ama soyut nesne şuan işimi görmüyor o yüzden new dedik yani newlenebilir olmalı IEntity interface olduğu için newlenemez.
    //constructor demek new bloğuydu
    public interface IEntityRepository<T> where T:class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
