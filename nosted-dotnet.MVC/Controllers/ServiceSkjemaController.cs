using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;


namespace nosted_dotnet.MVC.Controllers
{

    public class ServiceSkjemaController : Controller
    {
        public IActionResult Index(string Kunde, string MotattDato, string KundeMail, string KundeAdresse,
                                  string KundeTelefonNr, string Serienummer, string Produkttype,
                                  string Årsmodell, string ServiceRep, string OrdreNummer,
                                  string AvtaltMedKunden, string RepBeskrivelse, string MedgåtteDeler,
                                  decimal Arbeidstimer, string FerdigDato, string UtskiftetDelerRetur,
                                  string ForsendelsesMåte, string SignaturKunde, string SignaturRep)
        {
            // You can access and use the query string parameters here
            // For example, you can pass them to a service, save them to a database, or perform any other logic.

   
            var viewModel = new ServiceSkjemaViewModel
            {
                Kunde = Kunde,
                MotattDato = string.IsNullOrEmpty(MotattDato) ? DateTime.Now : DateTime.Parse(MotattDato),
                KundeMail = KundeMail,
                KundeAdresse = KundeAdresse,
                KundeTelefonNr = KundeTelefonNr,
                Serienummer = Serienummer,
                Produkttype = Produkttype,
                Årsmodell = Årsmodell,
                ServiceRep = ServiceRep,
                OrdreNummer = OrdreNummer,
                AvtaltMedKunden = AvtaltMedKunden,
                RepBeskrivelse = RepBeskrivelse,
                MedgåtteDeler = MedgåtteDeler,
                Arbeidstimer = Arbeidstimer, 
                FerdigDato = string.IsNullOrEmpty(FerdigDato) ? DateTime.Now : DateTime.Parse(FerdigDato),
                UtskiftetDelerRetur = UtskiftetDelerRetur,
                ForsendelsesMåte = ForsendelsesMåte,
                SignaturKunde = SignaturKunde,
                SignaturRep = SignaturRep
            };

            // You can now use the viewModel to perform further actions or render a view.
            return View(viewModel);
        }
        [HttpPost]

        public IActionResult Index(ServiceSkjemaViewModel viewModel)
        {
           
            if (!ModelState.IsValid)
            {
                //Does not redirect to anything. Define where it should redirect.
                return BadRequest("Not a valid model");
            }

            // Access the form data via the model object
            string Kunde = viewModel.Kunde;
           

            // Log the form data
            Debug.WriteLine($"Kunde: {Kunde}");
            

            // Redirect to a confirmation page or back to the form page after handling the data.
            return RedirectToAction("Index");
        }


    }
}
