using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPoco.Linq;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7210/api/CarPricings/GetCarPricingWithTimePeriodList");
            if (responseMessage.IsSuccessStatusCode) //200 code
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);

                var priceChanges = new Dictionary<int, (decimal weeklyAmount, decimal monthlyAmount)>();

                var index = -1;
                for (int i = 0; i < values.Count; i++)
                {
                    index++;
                    var prices = values[i];
                    decimal weeklyAmount1 = prices.dailyAmount * 7;
                    decimal monthlyAmount1 = prices.weeklyAmount * 4;

                    priceChanges.Add(i, (weeklyAmount1, monthlyAmount1));
                    ViewBag.i = index;
                }

                ViewBag.PriceChanges = priceChanges;

                return View(values);
            }
            return View();
        }
    }
}
