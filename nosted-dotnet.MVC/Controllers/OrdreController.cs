using Microsoft.AspNetCore.Mvc;

using nosted_dotnet.MVC.Models.Ordre;


namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NyOrdre()
        {
            return View();
        }

    }
}
    
