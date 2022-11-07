using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<BaseResponseModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

