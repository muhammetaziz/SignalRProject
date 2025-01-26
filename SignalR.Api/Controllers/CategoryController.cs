using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListCategory()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto categoryDto)
        {
            Category category = new()
            {
                Name = categoryDto.Name,
                Status = categoryDto.Status
            };

            if (ModelState.IsValid)
            {
                _categoryService.TAdd(category);
                return Ok("Kategori eklendi");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value != null)
            {
                _categoryService.TDelete(value);
                return Ok("Kategori silindi");
            }
            return BadRequest("Kategori bulunamadı");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategory)
        {
            Category category = new()
            {
                CategoryID = updateCategory.CategoryID,
                Name = updateCategory.Name,
                Status = updateCategory.Status
            };
            if (ModelState.IsValid)
            {
                _categoryService.TUpdate(category);
                return Ok("Kategori güncellendi");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Kategori bulunamadı");

        }
    }
}


