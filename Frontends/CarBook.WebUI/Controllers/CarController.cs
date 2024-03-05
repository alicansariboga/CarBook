using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            // viewbags
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            //consume
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode) //200 code
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Araca Ait Teknik Özellik Ve Aksesuarlar";
            ViewBag.carid = id;
            return View();
        }
    }
}
