using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Models.LoggIn;


namespace nosted_dotnet.MVC.Controllers;

public class LogInController : Controller
{
    // Action for å vise innloggingssiden
    public IActionResult Index()
    {
        return View();
    }

    // Action for å behandle innloggingsforespørselen (uferdig, har ikke autentisering eller noe)
    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Legg til logikk for å validere brukerens legitimasjon her
            // For eksempel, sjekk mot en database eller en autentiseringsmekanisme.
            // Hvis legitimasjonen er vellykket, kan du omdirigere brukeren til en annen side.
        }

        // Hvis legitimasjonen mislykkes, vis feilmeldinger
        ModelState.AddModelError(string.Empty, "Ugyldig brukernavn eller passord.");
        return View(model);
    }
}
