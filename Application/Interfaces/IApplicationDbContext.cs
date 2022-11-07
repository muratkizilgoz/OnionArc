using System;
using Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();

    }
}

