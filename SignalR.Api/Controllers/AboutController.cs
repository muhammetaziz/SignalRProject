using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;

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
        public IActionResult AboutList()
        {
            var values=_aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public  IActionResult CreateAbout(CreateAboutDto createAbout)
        {
            if (ModelState.IsValid)
            {
                _aboutService.TAdd(createAbout);
                return Created("", createAbout);
            }
        }
            
    }
}
