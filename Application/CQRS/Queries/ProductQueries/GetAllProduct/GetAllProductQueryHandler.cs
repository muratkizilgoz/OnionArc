using System;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.ProductQueries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, ICollection<GetAllProductQueryResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllProductQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ICollection<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _applicationDbContext.Products
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new GetAllProductQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    CategoryId = x.CategoryId,
                    CategoryName = x.Category.Name
                })
                .ToListAsync();

            return products;
        }
    }
}

