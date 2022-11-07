using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Category:BaseEntity
    {
        public ICollection<Product> Products { get; set; }
    }
}

