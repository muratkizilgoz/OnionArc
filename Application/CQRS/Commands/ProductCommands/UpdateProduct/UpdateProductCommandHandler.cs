using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Quantity = request.Quantity;
            product.Price = request.Price;
            product.CategoryId = request.CategoryId;

            _applicationDbContext.Products.Update(product);

            var res = await _applicationDbContext.SaveChangesAsync();

            return ResponseUtil.ResponseResult(res);
        }
    }
}

