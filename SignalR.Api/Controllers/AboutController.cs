using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAbout)
        {
            About about = new About
            {
                Description = createAbout.Description,
                ImageURL = createAbout.ImageURL,
                Title = createAbout.Title

            };
            if (ModelState.IsValid)
            {
                _aboutService.TAdd(about);
                return Ok("Hakkımda kısmı eklendi");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value != null)
            {
                _aboutService.TDelete(value);
                return Ok("Hakkımda kısmı silindi");
            }
            return BadRequest("Hakkımda kısmı bulunamadı");
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAbout)
        {
            About about = new About
            {
                AboutID=updateAbout.AboutID,
                Description = updateAbout.Description,
                ImageURL = updateAbout.ImageURL,
                Title = updateAbout.Title

            };
            if (ModelState.IsValid)
            {
                _aboutService.TUpdate(about);
                return Ok("Hakkımda kısmı güncellendi");
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetById(id);
            if (value != null)
            {
                return Ok(value);
            }
            return BadRequest("Hakkımda kısmı bulunamadı");
        }
    }
}
