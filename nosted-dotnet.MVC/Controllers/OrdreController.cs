using bacit_dotnet.MVC.Controllers;
using bacit_dotnet.MVC.Models.CheckList;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Models.ArbeidsDokument;
using nosted_dotnet.MVC.Models.ServiceSkjema;

namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        public IActionResult Index()
        {




            var model = new OrdreViewModel
            {
                OrdreNummer = 123123,
                DatoMottatt = new DateTime(2019, 5, 8),
                ProduktType = "vinsj",
                ServiceSkjema = new ServiceSkjemaController(),
                Sjekkliste = new CheckListController(),
                InnenDato = new DateTime(2019, 6, 1),
                ErFerdig = true,
            };
                   
            return View(model);
        }
    }
}
