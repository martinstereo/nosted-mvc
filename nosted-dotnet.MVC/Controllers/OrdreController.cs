using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data.Ordre;
using nosted_dotnet.MVC.Models.Ordre;

namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        
        // private readonly IOrdreRepository _ordreRepository;


        public IActionResult Index()
        {
            var model = new FullOrdreViewModel();
            // model.OrdreList = _ordreRepository.HentAlle().Select(x => new OrdreViewModel { Id = x.Id }).ToList();
            
            return View(model);
        }


        public IActionResult Ordreskjema()
        {
            var model = new OrdreViewModel();
            return View(model);
        }


        [HttpPost]
        public IActionResult SubmitOrder(OrdreViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the form data (e.g., save to the database)
                // Redirect to a success page or take further actions
                return RedirectToAction("Index");
            }

            // If the model is not valid, return the view with validation errors and the input data
            return View("Ordreskjema", model);
        }

    }
    
}
