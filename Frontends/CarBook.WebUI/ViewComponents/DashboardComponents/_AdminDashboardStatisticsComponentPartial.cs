using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // for progress bar - test using
            Random rndm = new Random();
            var client = _httpClientFactory.CreateClient();

            #region Statistic-carCount
            var responseMessage1 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarCount/");
            if (responseMessage1.IsSuccessStatusCode)
            {
                int carCountRandom = rndm.Next(0, 101);
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData1);
                ViewBag.carCount = values1.carCount;
                ViewBag.carCountRandom = carCountRandom;
                //return View(values1);
            }
            #endregion

            #region Statistic-locationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7210/api/Statictics/GetLocationCount/");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int locationCountRandom = rndm.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.locationCount = values2.locationCount;
                ViewBag.locationCountRandom = locationCountRandom;
            }
            #endregion

            #region Statistic-brandCount
            var responseMessage4 = await client.GetAsync("https://localhost:7210/api/Statictics/GetBrandCount/");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int brandCountRandom = rndm.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.brandCount = values4.brandCount;
                ViewBag.brandCountRandom = brandCountRandom;
            }
            #endregion

            #region Statistic-avgRentPriceForDaily
            var responseMessage5 = await client.GetAsync("https://localhost:7210/api/Statictics/GetAvgRentPriceForDaily/");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int avgRentPriceForDailyRandom = rndm.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.avgRentPriceForDaily = values5.avgRentPriceForDaily.ToString("0.00");
                ViewBag.avgRentPriceForDailyRandom = avgRentPriceForDailyRandom;
            }
            #endregion

            return View();
        }
    }
}
