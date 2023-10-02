using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;

using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Models.ServiceSkjema;


namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        public IActionResult Index()
        {
            var model = new OrdreViewModel();
            return View(model);
        }

        //HTTP post etc

    }
    
}
