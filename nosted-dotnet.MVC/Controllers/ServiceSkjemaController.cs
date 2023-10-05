using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Encodings.Web;

//In the GET request, it receives query string parameters,
//encodes them to prevent XSS attacks, and displays them in a view model.
//In the POST request, it receives form data, performs validation,
//and logs the data before redirecting to another page.

namespace nosted_dotnet.MVC.Controllers
{

    public class ServiceSkjemaController : Controller
    {
        private readonly HtmlEncoder _htmlEncoder;

        public ServiceSkjemaController(HtmlEncoder htmlEncoder)
        {
            _htmlEncoder = htmlEncoder;
        }

        public IActionResult Index(string Kunde, string MotattDato, string KundeMail, string KundeAdresse,
                                  string KundeTelefonNr, string Serienummer, string Produkttype,
                                  string Årsmodell, string ServiceRep, string OrdreNummer,
                                  string AvtaltMedKunden, string RepBeskrivelse, string MedgåtteDeler,
                                  decimal Arbeidstimer, string FerdigDato, string UtskiftetDelerRetur,
                                  string ForsendelsesMåte, string SignaturKunde, string SignaturRep)
        {
            // You can access and use the query string parameters here
            // For example, you can pass them to a service, save them to a database, or perform any other logic.

            
            // Sjekker og encoder de motatte query string parameterene
            //ved å utføre disse nullsjekkene før vi kaller _htmlEncoder.Encode,
            //unngår vi ArgumentNullException og trygt kryptere query string parameterene
            Kunde = Kunde != null ? _htmlEncoder.Encode(Kunde) : null;
            KundeMail = KundeMail != null ? _htmlEncoder.Encode(KundeMail) : null;
            KundeAdresse = KundeAdresse != null ? _htmlEncoder.Encode(KundeAdresse) : null;
            KundeTelefonNr = KundeTelefonNr != null ? _htmlEncoder.Encode(KundeTelefonNr) : null;
            Serienummer = Serienummer != null ? _htmlEncoder.Encode(Serienummer) : null;
            Produkttype = Produkttype != null ? _htmlEncoder.Encode(Produkttype) : null;
            Årsmodell = Årsmodell != null ? _htmlEncoder.Encode(Årsmodell) : null;
            ServiceRep = ServiceRep != null ? _htmlEncoder.Encode(ServiceRep) : null;
            OrdreNummer = OrdreNummer != null ? _htmlEncoder.Encode(OrdreNummer) : null;
            AvtaltMedKunden = AvtaltMedKunden != null ? _htmlEncoder.Encode(AvtaltMedKunden) : null;
            RepBeskrivelse = RepBeskrivelse != null ? _htmlEncoder.Encode(RepBeskrivelse) : null;
            MedgåtteDeler = MedgåtteDeler != null ? _htmlEncoder.Encode(MedgåtteDeler) : null;
            UtskiftetDelerRetur = UtskiftetDelerRetur != null ? _htmlEncoder.Encode(UtskiftetDelerRetur) : null;
            ForsendelsesMåte = ForsendelsesMåte != null ? _htmlEncoder.Encode(ForsendelsesMåte) : null;
            SignaturKunde = SignaturKunde != null ? _htmlEncoder.Encode(SignaturKunde) : null;
            SignaturRep = SignaturRep != null ? _htmlEncoder.Encode(SignaturRep) : null;


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
        [ValidateAntiForgeryToken]
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
