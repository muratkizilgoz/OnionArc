using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.Commands.ProductCommands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProductHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                Price = request.Price,
                Quantity = request.Quantity,
                CategoryId = request.CategoryId
            };

            await _applicationDbContext.Products.AddAsync(product);

            var res = await _applicationDbContext.SaveChangesAsync();

            return ResponseUtil.ResponseResult(res);
        }
    }
}

