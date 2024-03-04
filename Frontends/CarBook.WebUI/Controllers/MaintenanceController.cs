using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class MaintenanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
