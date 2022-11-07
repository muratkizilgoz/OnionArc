using System;
namespace Application.CQRS.Queries.ProductQueries.GetFilterProduct
{
    public class GetFilterProductQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}

