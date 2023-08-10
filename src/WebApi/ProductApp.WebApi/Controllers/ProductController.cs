using Application.Dto;
using Application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetAllProducts;
using Application.Features.Queries.GetProductById;
using Application.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            // core içindeki entity'ye ulaşmamam gerekir bu bir problem
            // ulaşabilirim ama ulaşmasak daha iyi olur. Entity direkt açmamak için.
            // var allList = await productRepository.GetAllAsync();

            // bu kullanım yerine CQRS ve Mediatr kullanacağız.
            // var result = allList.Select(x => new ProdcutViewDto() { id = x.Id, Name = x.Name}).ToList();

            //MediatR 
            var query = new GetAllProductsQuery();

            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery() { Id = id};

            return Ok(await mediator.Send(query));
        }
    }
}
