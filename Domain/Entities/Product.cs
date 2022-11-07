using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Product:BaseEntity
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

