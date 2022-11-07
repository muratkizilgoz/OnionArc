using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<BaseResponseModel>
    {
        public int Id { get; set; }
    }
}

