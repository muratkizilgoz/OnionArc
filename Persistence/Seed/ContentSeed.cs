using System;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Seed
{
    public static class ContentSeed
    {
        public static async Task CategoriesSeed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Category 1",
                        Description = "Category 1 Description",
                        IsActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Category 2",
                        Description = "Category 2 Description",
                        IsActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                    }
                };

                await applicationDbContext.AddRangeAsync(categories);
                await applicationDbContext.SaveChangesAsync();
            }
        }

        public static async Task ProductSeed(ApplicationDbContext applicationDbContext)
        {
            if (!applicationDbContext.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Product 1",
                        Description = "Product 1 Description",
                        IsActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Quantity = 22,
                        Price = Convert.ToDecimal("100.22"),
                        CategoryId = 1

                    },
                    new Product
                    {
                        Name = "Product 2",
                        Description = "Product 2 Description",
                        IsActive = true,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        Quantity = 54,
                        Price = Convert.ToDecimal("55.56"),
                        CategoryId = 2

                    }
                };

                await applicationDbContext.AddRangeAsync(products);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}

