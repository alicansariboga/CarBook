using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureCarIdComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCarFeatureCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[Route("Index/{id}")]
		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carid = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7210/api/CarFeatures?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				// situation code of 200 / passed
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
