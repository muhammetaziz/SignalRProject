﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.DTOs.TestimonialDtos;
using System.Text;

namespace SignalR.WebUI.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7115/api/Testimonial");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responceMessage = await client.PostAsync("https://localhost:7115/api/Testimonial", stringContent);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
