using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<BaseResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

