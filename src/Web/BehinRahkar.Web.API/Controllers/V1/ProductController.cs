using BehinRahkar.Application.Contracts.Services.Product;
using BehinRahkar.Web.API.Models.Mapping;
using BehinRahkar.Web.API.Models.Request.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BehinRahkar.Web.API.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// This API Create New Product.
        /// </summary>
        /// <remarks>
        /// Remarks Description
        /// </remarks>
        /// <response code="200">The prouduct was successfully created.</response>
        /// <response code="400">
        /// product name, code would be null or empty/
        /// if file was uploded, file name would be empty/
        /// product code would be duplicated/
        /// price would be less than or equal zero
        /// </response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestModel model)
        {
            await _productService.CreateProductAsync(model.ToDto());
            return Ok();
        }
    }
}
