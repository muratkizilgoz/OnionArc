using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Commands.CategoryCommands.CreateCategory;
using Application.CQRS.Commands.CategoryCommands.DeleteCategory;
using Application.CQRS.Commands.CategoryCommands.UpdateCategory;
using Application.CQRS.Queries.CategoryQueries.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _mediator.Send(new GetAllCategoryQueryRequest());
            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCategoryCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommandRequest request)
        {
            var res = await _mediator.Send(request);
            if (res.Status) return Ok(res.Message);
            return BadRequest(res.Message);
        }
    }
}

