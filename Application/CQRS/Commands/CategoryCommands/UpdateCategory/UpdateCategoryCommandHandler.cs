using System;
using Application.Interfaces;
using Application.Models.Common;
using Application.Util;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, BaseResponseModel>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<BaseResponseModel> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var model = await _applicationDbContext.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

            model.Name = request.Name;
            model.Description = request.Description;

            _applicationDbContext.Categories.Update(model);

            var res = await _applicationDbContext.SaveChangesAsync();

            return ResponseUtil.ResponseResult(res);

        }
    }
}

