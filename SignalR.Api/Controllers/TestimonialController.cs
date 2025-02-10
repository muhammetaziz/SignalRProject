using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListTestimonial()
        {
            var value = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonial)
        {
            Testimonial testimonial = new()
            {
                Comment = createTestimonial.Comment,
                Name = createTestimonial.Name,
                Status = createTestimonial.Status,
                Title = createTestimonial.Title,
                ImageURL = createTestimonial.ImageURL,
            };
            if (ModelState.IsValid)
            {
                _testimonialService.TAdd(testimonial);
                return Ok("Yorum eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value != null)
            {
                _testimonialService.TDelete(value);
                return Ok("Yorum silindi.");
            }
            return BadRequest("Yorum bulunamadı.");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonial)
        {
            Testimonial testimonial = new()
            {
                TestimonialID = updateTestimonial.TestimonialID,
                Comment = updateTestimonial.Comment,
                Name = updateTestimonial.Name,
                Status = updateTestimonial.Status,
                Title = updateTestimonial.Title,
                ImageURL = updateTestimonial.ImageURL,
            };
            if (ModelState.IsValid)
            {
                _testimonialService.TUpdate(testimonial);
                return Ok("Yorum güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var value = _testimonialService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Yorum bulunamadı.");
        }
    }
}
