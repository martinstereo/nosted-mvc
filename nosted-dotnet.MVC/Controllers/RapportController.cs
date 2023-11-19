using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nosted_dotnet.MVC.Controllers;

[Authorize(Roles = "Administrator")]
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
