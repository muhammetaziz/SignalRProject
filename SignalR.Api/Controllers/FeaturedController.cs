using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeaturedController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListFeature()
        {
            var result =_mapper.Map<List<ResultFeatureDto>> (_featureService.TGetListAll());
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            Feature feature = new()
            {
                Title1 = createFeatureDto.Title1,
                Description1 = createFeatureDto.Description1,
                Title2 = createFeatureDto.Title2,
                Description2 = createFeatureDto.Description2,
                Title3 = createFeatureDto.Title3,
                Description3 = createFeatureDto.Description3,
                ImageURL = createFeatureDto.ImageURL
            };
            if (ModelState.IsValid)
            {
                _featureService.TAdd(feature);
                return Ok("Öne çıkanlar eklendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetById(id);
            if (value != null)
            {
                _featureService.TDelete(value);
                return Ok("Öne çıkanlar silindi.");
            }
            return BadRequest("Öne çıkanlar bilgisi bulunamadı");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            Feature feature = new()
            {
                FeatureID = updateFeatureDto.FeatureID,
                Title1 = updateFeatureDto.Title1,
                Description1 = updateFeatureDto.Description1,
                Title2 = updateFeatureDto.Title2,
                Description2 = updateFeatureDto.Description2,
                Title3 = updateFeatureDto.Title3,
                Description3 = updateFeatureDto.Description3,
                ImageURL = updateFeatureDto.ImageURL
            };
            if (ModelState.IsValid)
            {
                _featureService.TUpdate(feature);
                return Ok("Öne çıkanlar güncellendi.");
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var value = _featureService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Öne çıkanlar bilgisi bulunamadı.");
        }
    }
}
