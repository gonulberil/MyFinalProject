using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet yaptığımız için data accessin içinde entity framework yazabiliriz
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                //ürünlerle kategorileri join yap
                var result = from p in context.Products
                             join c in context.Categories
                             //neye göre join yap
                             on p.CategoryId equals c.CategoryId
                             //hangi kolonları istiyorsun
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };

                return result.ToList();
            }
            
        }
    }
}
