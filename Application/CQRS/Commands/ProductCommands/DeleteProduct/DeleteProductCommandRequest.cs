using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.ProductCommands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<BaseResponseModel>
    {
        public int Id { get; set; }
    }
}

