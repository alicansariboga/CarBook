using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    public class MaintanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
