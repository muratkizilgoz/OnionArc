using System;
using MediatR;

namespace Application.CQRS.Queries.ProductQueries.GetAllProduct
{
    public class GetAllProductQueryRequest:IRequest<ICollection<GetAllProductQueryResponse>>
    {
    }
}

