using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<BaseResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

