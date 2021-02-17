using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //constructor eklendi ampülden

            if (product.ProductName.Length < 2)
            {
                //magic strings -- stringleri ayrı ayrı yazmak
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new  SuccessResult("Ürün eklendi.");
        }

        //sadece 1 metodda 1 liste döndürebilirsin 1 den fazla döndürmek istersen encapsulation kullanılacak.
        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları
            //Yetkisi var mı?
            if(DateTime.Now.Hour==14)
            {
                return new ErrorResult();
            }


            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler listelendi.");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
                
        }

        public IDataResult<Product> GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

    
    }
}
