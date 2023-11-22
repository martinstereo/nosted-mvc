using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace nosted_dotnet.MVC.Controllers;

[Authorize(Roles = "Administrator")]
public class RapportController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
