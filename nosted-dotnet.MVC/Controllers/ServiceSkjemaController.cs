using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace nosted_dotnet.MVC.Controllers
{
    public class ServiceSkjemaController : Controller
    {

        // Dette er handlingsmetoden for å vise skjemaet
        public IActionResult Index(string Kunde, string MotattDato, string KundeMail, string KundeAdresse,
            string KundeTelefonNr, string Serienummer, string Produkttype,
            string Årsmodell, string ServiceRep, string OrdreNummer,
            string AvtaltMedKunden, string RepBeskrivelse, string MedgåtteDeler,
            decimal Arbeidstimer, string FerdigDato, string UtskiftetDelerRetur,
            string ForsendelsesMåte, string SignaturKunde, string SignaturRep)
        {
        
            var viewModel = new ServiceSkjemaViewModel
            {
                Kunde = Kunde,
                MotattDato = string.IsNullOrEmpty(MotattDato) ? DateTime.Today : DateTime.Parse(MotattDato).Date,
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
                FerdigDato = string.IsNullOrEmpty(FerdigDato) ? DateTime.Today : DateTime.Parse(FerdigDato).Date,
                UtskiftetDelerRetur = UtskiftetDelerRetur,
                ForsendelsesMåte = ForsendelsesMåte,
                SignaturKunde = SignaturKunde,
                SignaturRep = SignaturRep
            };

            // Du kan nå bruke visningsmodellen til å utføre videre handlinger eller vise en visning.
            return View(viewModel);
        }

        // Dette er handlingsmetoden for å håndtere innsendt skjemadata
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ServiceSkjemaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Returnerer ingen videre kobling. Definer hvor den skal omdirigere.
                return BadRequest("Ikke en gyldig modell");
            }

            // Få tilgang til skjemadata via modellobjektet
            string Kunde = viewModel.Kunde;

            // Logg skjemadata
            Debug.WriteLine($"Kunde: {Kunde}");

            // Omdiriger til en bekreftelsesside eller tilbake til skjemasiden etter å ha behandlet dataene.
            return RedirectToAction("Index");
        }
    }
}
