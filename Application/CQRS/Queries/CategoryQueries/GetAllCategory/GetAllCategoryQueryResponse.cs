using System;
namespace Application.CQRS.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

