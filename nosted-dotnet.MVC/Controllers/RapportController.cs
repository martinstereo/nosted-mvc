using Microsoft.AspNetCore.Mvc;

namespace nosted_dotnet.MVC.Controllers;

public class RapportController : Controller
{
    // Action method for the Rapport view
    public ActionResult Index()
    {
        // Your logic here
        // You can fetch data, perform calculations, etc.

        // Return the Rapport view
        return View();
    }
}
