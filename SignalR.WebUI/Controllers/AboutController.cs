using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.DTOs.AboutDtos;

namespace SignalR.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task < IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7115/api/About");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
