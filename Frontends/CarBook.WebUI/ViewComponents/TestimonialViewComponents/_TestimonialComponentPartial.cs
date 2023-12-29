using CarBook.Dto.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.TestimonialViewComponents
{
	public class _TestimonialComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		// getting veri. so it should be async
		public async Task<IViewComponentResult> InvokeAsync()
		{
			//consume

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7210/api/Testimonials");
			if(responseMessage.IsSuccessStatusCode) //200 code
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
