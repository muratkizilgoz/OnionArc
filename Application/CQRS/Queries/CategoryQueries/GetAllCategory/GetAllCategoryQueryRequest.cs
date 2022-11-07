using System;
using MediatR;

namespace Application.CQRS.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryRequest:IRequest<ICollection<GetAllCategoryQueryResponse>>
    {
    }
}

