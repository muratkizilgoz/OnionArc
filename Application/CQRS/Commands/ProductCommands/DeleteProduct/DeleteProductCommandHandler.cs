using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteProductCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = await _applicationDbContext.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            product.IsActive = false;

            _applicationDbContext.Products.Update(product);

            var res = await _applicationDbContext.SaveChangesAsync();

            return ResponseUtil.ResponseResult(res);
        }
    }
}

