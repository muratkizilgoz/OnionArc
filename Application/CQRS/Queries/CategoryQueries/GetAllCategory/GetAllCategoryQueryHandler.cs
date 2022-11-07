using System;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, ICollection<GetAllCategoryQueryResponse>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetAllCategoryQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ICollection<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _applicationDbContext.Categories
                .AsNoTracking()
                .Where(x => x.IsActive)
                .Select(x => new GetAllCategoryQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                })
                .ToListAsync();
            return categories;
        }
    }
}

