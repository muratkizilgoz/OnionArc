using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            category.IsActive = false;

            _applicationDbContext.Categories.Update(category);

            var res = await _applicationDbContext.SaveChangesAsync();


            return ResponseUtil.ResponseResult(res);
        }
    }
}

