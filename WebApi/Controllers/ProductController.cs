using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.CategoryCommands.CreateCategory;
using Application.CQRS.Commands.CategoryCommands.DeleteCategory;
using Application.CQRS.Commands.CategoryCommands.UpdateCategory;
using Application.CQRS.Commands.ProductCommands.CreateProduct;
using Application.CQRS.Commands.ProductCommands.DeleteProduct;
using Application.CQRS.Commands.ProductCommands.UpdateProduct;
using Application.CQRS.Queries.CategoryQueries.GetAllCategory;
using Application.CQRS.Queries.ProductQueries.GetAllProduct;
using Application.CQRS.Queries.ProductQueries.GetFilterProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(products);
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> Filter([FromBody] GetFilterProductQueryRequest request)
        {
            var products = await _mediator.Send(request);
            return Ok(products);
        }

        [HttpPost]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProductCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}

