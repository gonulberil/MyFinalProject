using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
       
        IDataResult<List<Product>> GetAll(); //hem mesaj hem liste hem de döndürüceği şeyi içerir. içine data konulur.
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        //liste döndürür
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        //tek başına ürün döndürür ürünün detayına bastığımızda sayfada o ürüne ait bilgiler gelir.
        IDataResult<Product> GetById(int productId);

        //bir şey dönmüyor (void) data yok o yüzden IDataResult konmadı
        IResult Add(Product product);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
    }
}
