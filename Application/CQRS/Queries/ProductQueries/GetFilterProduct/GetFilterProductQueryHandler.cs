using System;
using Application.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.ProductQueries.GetFilterProduct
{
    public class GetFilterProductQueryHandler : IRequestHandler<GetFilterProductQueryRequest, ICollection<GetFilterProductQueryResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetFilterProductQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ICollection<GetFilterProductQueryResponse>> Handle(GetFilterProductQueryRequest request, CancellationToken cancellationToken)
        {
            var orderedEnum = (ProductOrderEnum)request.Order;
            var query = _applicationDbContext.Products
                .AsNoTracking();
            if (request.CategoryId != 0) query = query.Where(x => x.CategoryId == request.CategoryId);

            var products = await query
                .Select(x => new GetFilterProductQueryResponse
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
            if (orderedEnum == Domain.Enums.ProductOrderEnum.priceLowToHigh)
                return products.OrderBy(x => x.Price).ToList();
            else if (orderedEnum == Domain.Enums.ProductOrderEnum.priceHighToLow)
                return products.OrderByDescending(x => x.Price).ToList();
            else
                return products;
        }
    }
}

