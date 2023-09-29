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

        [HttpPost]
        public ActionResult SaveChecklist (CheckListViewModel viewModel) 
        { 
        
            if (ModelState.IsValid)
            {
                // Save checklist to database


                return RedirectToAction("Index", "Ordre");
            }

            // If the model state is not valid, return to the checklist creation page with errors
            return View("CreateChecklist", viewModel);

        }

    }
    
}
