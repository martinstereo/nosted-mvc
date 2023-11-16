using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nosted_dotnet.MVC.Controllers
{
    [Authorize]
    public class Utstyrsbehandling : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
