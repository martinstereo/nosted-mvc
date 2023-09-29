using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;


namespace nosted_dotnet.MVC.Controllers
{
	public class ServiceSkjemaController : Controller
	{
		public IActionResult Index(ServiceSkjemaViewModel viewModel)
		{
            var serviceData = new ServiceSkjemaViewModel
            {
                Kunde = viewModel.Kunde,
                //IsAdministrator = viewModel.IsAdministrator,
                Serienummer = viewModel.Serienummer,
                MottattDato = viewModel.MottattDato,
                Arbeidstimer = viewModel.Arbeidstimer,
                AvtaltMedKunden = viewModel.AvtaltMedKunden,
                RepBeskrivelse = viewModel.RepBeskrivelse,
                MedgåtteDeler = viewModel.MedgåtteDeler,
                OrdreNummer = viewModel.OrdreNummer,
                KundeMail = viewModel.KundeMail,
                KundeAdresse = viewModel.KundeAdresse,
                KundeTelefonNr = viewModel.KundeTelefonNr,
                Produkttype = viewModel.Produkttype,
                Årsmodell = viewModel.Årsmodell,
                ServiceRep = viewModel.ServiceRep,
                FerdigDato = viewModel.FerdigDato,
                UtskiftetDelerRetur = viewModel.UtskiftetDelerRetur,
                ForsendelsesMåte = viewModel.ForsendelsesMåte,
                SignaturKunde = viewModel.SignaturKunde,
                SignaturRep = viewModel.SignaturRep,
            };
            return View(viewModel);
        }

       
    }
}
