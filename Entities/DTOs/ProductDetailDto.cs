using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //bir tabloya karşılık gelmiyor o yüzden IEntity implemente etmez
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
