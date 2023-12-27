using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        // consume Api
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // client for request
            var responseMessage = await client.GetAsync("https://localhost:7210/api/Abouts");
            if (responseMessage.IsSuccessStatusCode) // 200 codes=successfully process
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //api den gelen veriyi okuma
                var value = JsonConvert.DeserializeObject<List<string>>(jsonData); //read=DeserializeObject // write=SerializedObject\
                // api den gelen deger ile View tarafindanki degerin eslesmesi gerekir. bunun icin yine viewModel/DTO olusturulur.
            }
            return View();
        }
    }
}
