using Application.Dto;
using Application.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            // core içindeki entity'ye ulaşmamam gerekir bu bir problem
            //ulaşabilirim ama ulaşmasak daha iyi olur. Entity direkt açmamak için.
            var allList = await productRepository.GetAllAsync();

            // bu kullanım yerine CQRS ve Mediatr kullanacağız.
            var result = allList.Select(x => new ProdcutViewDto() { id = x.Id, Name = x.Name}).ToList();

            return Ok(result);
        }
    }
}
