using System;
using Application.Models.Common;
using MediatR;

namespace Application.CQRS.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<BaseResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

