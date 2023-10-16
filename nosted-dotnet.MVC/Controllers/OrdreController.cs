using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;

using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Models.ServiceSkjema;


namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        private List<OrdreRad> OrderDataTable = new();

        public IActionResult Index()
        {
            return View(OrderDataTable);
        }

        public IActionResult Create()
        {
            var model = new OrdreSkjema();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(OrdreSkjema model)
        {
            if (ModelState.IsValid)
            {
                // Behandle den gyldige modellen her (lagre den i databasen, osv.)
                // ...
                return RedirectToAction("Suksess"); // Redirect til en suksessside etter opprettelse
            }

            // Hvis modellen ikke er gyldig, vis skjemaet igjen med feilmeldinger
            return View(model);
        }
    }
}
    
