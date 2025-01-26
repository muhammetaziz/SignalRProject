using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListDiscount()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscount)
        {
            Discount discount = new()
            {
                Title = createDiscount.Title,
                Amount = createDiscount.Amount,
                Description = createDiscount.Description,
                ImageURL = createDiscount.ImageURL,
            };
            if (ModelState.IsValid)
            {
                _discountService.TAdd(discount);
                return Ok("İndirim eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value != null)
            {
                _discountService.TDelete(value);
                return Ok("İndirim silindi.");
            }
            return BadRequest("İndirim bilgisi bulunamadı");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscount)
        {
            Discount discount = new()
            {

                DiscountID = updateDiscount.DiscountID,
                Title = updateDiscount.Title,
                Amount = updateDiscount.Amount,
                Description = updateDiscount.Description,
                ImageURL = updateDiscount.ImageURL,
            };
            if (ModelState.IsValid)
            {
                _discountService.TUpdate(discount);
                return Ok("İndirim güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetDiscount")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("İndirim bilgisi bulunamadı.");
        }
    }
}
