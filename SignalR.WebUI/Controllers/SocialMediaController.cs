using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
