using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
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
        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDtos)
        {
            foreach(var item in resultCarFeatureByCarIdDtos)
            {
                if(item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(resultCarFeatureByCarIdDtos);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    await client.PutAsync("https://localhost:7210/api/CarFeature/", stringContent);
                    return RedirectToAction("Index", "AdminCar");
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    var jsonData = JsonConvert.SerializeObject(resultCarFeatureByCarIdDtos);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    await client.PutAsync("https://localhost:7210/api/CarFeature/", stringContent);
                    return RedirectToAction("Index", "AdminCar");
                }
            }
            return View();
        } 
    }
}
