using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
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

        // Dette er handlingsmetoden for å vise skjemaet
        public IActionResult Index(string Kunde, string MotattDato, string KundeMail, string KundeAdresse,
                                  string KundeTelefonNr, string Serienummer, string Produkttype,
                                  string Årsmodell, string ServiceRep, string OrdreNummer,
                                  string AvtaltMedKunden, string RepBeskrivelse, string MedgåtteDeler,
                                  decimal Arbeidstimer, string FerdigDato, string UtskiftetDelerRetur,
                                  string ForsendelsesMåte, string SignaturKunde, string SignaturRep)
        {
            // Hent alle offentlige egenskaper (properties) til denne kontrolleren
            PropertyInfo[] properties = this.GetType().GetProperties();

            // Gå gjennom egenskapene og krypter dem hvis de er strenger
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = (string)property.GetValue(this);
                    if (value != null)
                    {
                        property.SetValue(this, _htmlEncoder.Encode(value));
                    }
                }
            }

            // Opprett en visningsmodell (view model) med de krypterte verdiene
            var viewModel = new ServiceSkjemaViewModel
            {
                //Kunde = Kunde,
                //MotattDato = string.IsNullOrEmpty(MotattDato) ? DateTime.Now : DateTime.Parse(MotattDato),
                //KundeMail = KundeMail,
                //KundeAdresse = KundeAdresse,
                //KundeTelefonNr = KundeTelefonNr,
                //Serienummer = Serienummer,
                //Produkttype = Produkttype,
                //Årsmodell = Årsmodell,
                //ServiceRep = ServiceRep,
                OrdreNummer = OrdreNummer,
                //AvtaltMedKunden = AvtaltMedKunden,
                RepBeskrivelse = RepBeskrivelse,
                MedgåtteDeler = MedgåtteDeler,
                Arbeidstimer = Arbeidstimer,
                FerdigDato = string.IsNullOrEmpty(FerdigDato) ? DateTime.Now : DateTime.Parse(FerdigDato),
                UtskiftetDelerRetur = UtskiftetDelerRetur,
                ForsendelsesMåte = ForsendelsesMåte,
                //SignaturKunde = SignaturKunde,
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
            //string Kunde = viewModel.Kunde;

            // Logg skjemadata
            //Debug.WriteLine($"Kunde: {Kunde}");

            // Omdiriger til en bekreftelsesside eller tilbake til skjemasiden etter å ha behandlet dataene.
            return RedirectToAction("Index");
        }
    }
}
