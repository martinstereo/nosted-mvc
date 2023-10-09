using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;

using nosted_dotnet.MVC.Models.Bruker;
using nosted_dotnet.MVC.Models.ServiceSkjema;


namespace nosted_dotnet.MVC.Controllers
{
    public class BrukerController : Controller
    {
        private List<BrukerRad> BrukerDataTable = new();
        
        public IActionResult Index()
        {
            return View(BrukerDataTable);
        }

        //HTTP post etc
        [HttpPost]
        public IActionResult AddRow(BrukerRad row)
        {
            // Add the submitted row to the table
            BrukerDataTable.Add(row);

            // Redirect back to the index page

            return View("Index", BrukerDataTable);
        }


    }
    
}
