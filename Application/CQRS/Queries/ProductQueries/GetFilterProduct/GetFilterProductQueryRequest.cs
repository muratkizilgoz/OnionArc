using System;
using Domain.Enums;
using MediatR;

namespace Application.CQRS.Queries.ProductQueries.GetFilterProduct
{
    public class GetFilterProductQueryRequest : IRequest<ICollection<GetFilterProductQueryResponse>>
    {
        public int CategoryId { get; set; }
        public int Order { get; set; }
    }
}

