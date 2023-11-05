using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Models.Sjekkliste;
using System.Collections.Generic;
using nosted_dotnet.MVC.Data;

namespace nosted_dotnet.MVC.Controllers
{
    public class SjekklisteOversiktController : Controller
    {
        private readonly ISjekklisteRepository _sjekklisteRepository;

        public SjekklisteOversiktController(ISjekklisteRepository sjekklisteRepository)
        {
            _sjekklisteRepository = sjekklisteRepository;
        }

        public IActionResult Index()
        {
            // Retrieve a list of Sjekkliste from the repository
            var sjekkliste = _sjekklisteRepository.GetAllSjekklister();

            // Pass the list to a view to display the overview
            return View(sjekkliste);
        }
    }
}