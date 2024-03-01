using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                // situation code of 200 / passed
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                ViewBag.ValueControl = values.Count;
                return View(values);
            }
            return View();
        }
        [Route("Index/{id}")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach(var item in resultCarFeatureByCarIdDtos)
            {
                if(item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7210/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID );
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7210/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            // return View();
            return RedirectToAction("Index", "AdminCar");
        }
        [Route("CreateFeatureByCarID")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarID()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                // situation code of 200 / passed
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                ViewBag.ValueControl = values.Count;
                return View(values);
            }
            return View();
        }
    }
}
