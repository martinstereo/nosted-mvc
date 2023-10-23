using Microsoft.AspNetCore.Mvc;

using nosted_dotnet.MVC.Models.Ordre;


namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        private List<OrdreRad> OrderDataTable = new();
        
        public IActionResult Index()
        {
            return View(OrderDataTable);
        }

        //HTTP post etc
        [HttpPost]
        public IActionResult AddRow(OrdreRad row)
        {
            // Add the submitted row to the table
            OrderDataTable.Add(row);

            // Redirect back to the index page

            return View("Index", OrderDataTable);
        }


    }
    
}
