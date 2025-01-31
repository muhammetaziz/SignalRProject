using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.DTOs.ProductDtos;
using System.Text;

namespace SignalR.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync("https://localhost:7115/api/Product/GetProductWithCategory");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.DeleteAsync($"https://localhost:7115/api/Product/{id}");
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProduct);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responceMessage = await client.PostAsync("https://localhost:7115/api/Product", stringContent);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responceMessage = await client.GetAsync($"https://localhost:7115/api/Product/{id}");
            if (responceMessage.IsSuccessStatusCode)
            {
                var jsonData = await responceMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(value);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProduct);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responceMessage = await client.PutAsync("https://localhost:7115/api/Product", stringContent);
            if (responceMessage.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
