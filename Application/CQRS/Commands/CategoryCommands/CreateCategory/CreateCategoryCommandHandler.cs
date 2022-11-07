using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using Domain.Entities;
using MediatR;

namespace Application.CQRS.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = true
            };

            await _applicationDbContext.Categories.AddAsync(category);

            var result = await _applicationDbContext.SaveChangesAsync();

            return ResponseUtil.ResponseResult(result);
        }
    }
}

