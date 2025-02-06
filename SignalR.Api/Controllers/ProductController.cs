using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListProduct()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }

        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory()
        {
            var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductWithCategory());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProduct)
        {
            Product product = new()
            {
                CategoryID = createProduct.CategoryID,
                ProductName = createProduct.ProductName,
                Price = createProduct.Price,
                Description = createProduct.Description,
                ImageURL = createProduct.ImageURL,
                ProductStatus = createProduct.ProductStatus,
            };
            if (ModelState.IsValid)
            {
                _productService.TAdd(product);
                return Ok("Ürün eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            if (ModelState.IsValid)
            {
                _productService.TDelete(value);
                return Ok("Ürün silindi.");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProduct)
        {
            Product product = new()
            {
                CategoryID = updateProduct.CategoryID,
                ProductID = updateProduct.ProductID,
                ProductName = updateProduct.ProductName,
                Price = updateProduct.Price,
                Description = updateProduct.Description,
                ImageURL = updateProduct.ImageURL,
                ProductStatus = updateProduct.ProductStatus,
            };
            if (ModelState.IsValid)
            {
                _productService.TUpdate(product);
                return Ok("Ürün güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
    }
}
