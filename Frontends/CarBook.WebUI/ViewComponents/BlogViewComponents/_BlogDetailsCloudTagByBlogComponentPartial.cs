using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCloudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsCloudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // getting veri. so it should be async
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //consume

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7210/api/Blogs/" + id);
            if (responseMessage.IsSuccessStatusCode) //200 code
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
