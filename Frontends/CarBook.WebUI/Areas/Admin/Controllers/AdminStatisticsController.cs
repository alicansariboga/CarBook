using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region Statistic-blogCount
            var responseMessage3 = await client.GetAsync("https://localhost:7210/api/Statictics/GetBlogCount/");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int blogCountRandom = rndm.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.blogCount = values3.blogCount;
                ViewBag.blogCountRandom = blogCountRandom;
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

            #region Statistic-avgRentPriceForWeekly
            var responseMessage6 = await client.GetAsync("https://localhost:7210/api/Statictics/GetAvgRentPriceForWeekly/");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int avgRentPriceForWeeklyRandom = rndm.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.avgRentPriceForWeekly = values6.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.avgRentPriceForWeeklyRandom = avgRentPriceForWeeklyRandom;
            }
            #endregion

            #region Statistic-avgRentPriceForMonthly
            var responseMessage7 = await client.GetAsync("https://localhost:7210/api/Statictics/GetAvgRentPriceForMonthly/");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int avgRentPriceForMonthlyRandom = rndm.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.avgRentPriceForMonthly = values7.avgRentPriceForMonthly.ToString("0.00");
                ViewBag.avgRentPriceForMonthlyRandom = avgRentPriceForMonthlyRandom;
            }
            #endregion

            #region Statistic-carCountByTransmissionIsAuto
            var responseMessage8 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarCountByTransmissionIsAuto/");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int carCountByTransmissionIsAutoRandom = rndm.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.carCountByTransmissionIsAuto = values8.carCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
            }
            #endregion

            #region Statistic-brandNameByMaxCar
            var responseMessage9 = await client.GetAsync("https://localhost:7210/api/Statictics/GetBrandNameByMaxCar/");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int brandNameByMaxCarRandom = rndm.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.brandNameByMaxCar = values9.brandNameByMaxCar;
                ViewBag.brandNameByMaxCarRandom = brandNameByMaxCarRandom;
            }
            #endregion

            #region Statistic-blogTitleByMaxBlogComment
            var responseMessage10 = await client.GetAsync("https://localhost:7210/api/Statictics/GetBlogTitleByMaxBlogComment/");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int blogTitleByMaxBlogCommentRandom = rndm.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.blogTitleByMaxBlogComment = values10.blogTitleByMaxBlogComment;
                ViewBag.blogTitleByMaxBlogCommentRandom = blogTitleByMaxBlogCommentRandom;
            }
            #endregion

            #region Statistic-carCountByKmLT1000
            var responseMessage11 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarCountByKmLT1000/");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int carCountByKmLT1000Random = rndm.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.carCountByKmLT1000 = values11.carCountByKmLT1000;
                ViewBag.carCountByKmLT1000Random = carCountByKmLT1000Random;
            }
            #endregion

            #region Statistic-carCountByFuelGasolineAndDiesel
            var responseMessage12 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarCountByFuelGasolineOrDiesel/");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselROrom = rndm.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByFuelGasolineOrDiesel = values12.carCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselROrom = carCountByFuelGasolineOrDieselROrom;
            }
            #endregion

            #region Statistic-carCountByFuelElectric
            var responseMessage13 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarCountByFuelElectric/");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = rndm.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.carCountByFuelElectric = values13.carCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            #endregion

            #region Statistic-authorCount
            var responseMessage14 = await client.GetAsync("https://localhost:7210/api/Statictics/GetAuthorCount/");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int authorCountRandom = rndm.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.authorCount = values14.authorCount;
                ViewBag.authorCountRandom = authorCountRandom;
            }
            #endregion

            #region Statistic-carBrandAndModelByRentPriceDailyMax
            var responseMessage15 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarBrandAndModelByRentPriceDailyMax/");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMaxRandom = rndm.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModelByRentPriceDailyMax = values15.carBrandAndModelByRentPriceDailyMax;
                ViewBag.carBrandAndModelByRentPriceDailyMaxRandom = carBrandAndModelByRentPriceDailyMaxRandom;
            }
            #endregion

            #region Statistic-carBrandAndModelByRentPriceDailyMin
            var responseMessage16 = await client.GetAsync("https://localhost:7210/api/Statictics/GetCarBrandAndModelByRentPriceDailyMin/");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int carBrandAndModelByRentPriceDailyMinRandom = rndm.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.carBrandAndModelByRentPriceDailyMin = values16.carBrandAndModelByRentPriceDailyMin;
                ViewBag.carBrandAndModelByRentPriceDailyMinRandom = carBrandAndModelByRentPriceDailyMinRandom;
            }
            #endregion

            return View();
        }
    }
}
