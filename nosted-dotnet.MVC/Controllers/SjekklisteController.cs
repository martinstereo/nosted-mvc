using nosted_dotnet.MVC.Models.Sjekkliste;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;
using System.Linq;

namespace nosted_dotnet.MVC.Controllers
{
    public class SjekklisteController : Controller
    {
        private readonly ISjekklisteRepository _sjekklisteRepository;

        public SjekklisteController(ISjekklisteRepository sjekklisteRepository)
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
        
        //skal være knytta til ordre? så når en ny ordre blir laget blir en sjekkliste laget
        public IActionResult Create(int ordreId)
        {
            var sjekkliste = new Sjekkliste
            {
                OrdreId = ordreId
            };
            _sjekklisteRepository.Create(sjekkliste);

            return RedirectToAction("Upsert", new { id = sjekkliste.Id });
        }

        // For editing or creating a checklist
        public IActionResult Upsert(int id)
        {
            var sjekkliste = _sjekklisteRepository.Get(id);
            if (sjekkliste == null)
            {
                return NotFound();
            }

            var model = new SjekklisteViewModel
            {
               Id = sjekkliste.Id,
                ClutchLameller = sjekkliste.ClutchLameller,
                BremserBP = sjekkliste.BremserBP,
                TrommelLager = sjekkliste.TrommelLager,
                Kjedestrammer = sjekkliste.Kjedestrammer,
                Wire = sjekkliste.Wire,
                PinionLager = sjekkliste.PinionLager,
                KjedehjulKile = sjekkliste.KjedehjulKile,
                SylinderLekasje = sjekkliste.SylinderLekasje,
                Slanger = sjekkliste.Slanger,
                HydraulikkblokkTest = sjekkliste.HydraulikkblokkTest,
                OljeskifteTank = sjekkliste.OljeskifteTank,
                OljeskifteGirboks = sjekkliste.OljeskifteGirboks,
                RingsylinderTetninger = sjekkliste.RingsylinderTetninger,
                BremsesylinderTetninger = sjekkliste.BremsesylinderTetninger,
                Ledningsnett = sjekkliste.Ledningsnett,
                Radio = sjekkliste.Radio,
                Knappekasse = sjekkliste.Knappekasse,
                TrykkSetting = sjekkliste.TrykkSetting ?? 0,
                //FunksjonsTestKommentar = sjekkliste.FunksjonsTestKommentar,
                TrekKraft = sjekkliste.TrekKraft ?? 0,
                BremseKraft = sjekkliste.BremseKraft ?? 0,
                Resultat = sjekkliste.Resultat,
                MechanicComment = sjekkliste.MechanicComment,
                OrdreId = sjekkliste.OrdreId
            };

            return View(model);
        }

        // POST action for handling form submissions when creating or updating a checklist
        [HttpPost]
        public IActionResult Upsert(SjekklisteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log the error message
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }

                // If there are validation errors, redisplay the form
                return View(model);
            }

            // Map properties from SjekklisteViewModel to Sjekkliste
            var sjekkliste = new Sjekkliste
            {
                Id = model.Id,
                ClutchLameller = model.ClutchLameller,
                BremserBP = model.BremserBP,
                TrommelLager = model.TrommelLager,
                Kjedestrammer = model.Kjedestrammer,
                Wire = model.Wire,
                PinionLager = model.PinionLager,
                KjedehjulKile = model.KjedehjulKile,
                SylinderLekasje = model.SylinderLekasje,
                Slanger = model.Slanger,
                HydraulikkblokkTest = model.HydraulikkblokkTest,
                OljeskifteTank = model.OljeskifteTank,
                OljeskifteGirboks = model.OljeskifteGirboks,
                RingsylinderTetninger = model.RingsylinderTetninger,
                BremsesylinderTetninger = model.BremsesylinderTetninger,
                Ledningsnett = model.Ledningsnett,
                Radio = model.Radio,
                Knappekasse = model.Knappekasse,
                TrykkSetting = model.TrykkSetting,
                //FunksjonsTestKommentar = model.FunksjonsTestKommentar,
                TrekKraft = model.TrekKraft,
                BremseKraft = model.BremseKraft,
                Resultat = model.Resultat,
                MechanicComment = model.MechanicComment,
                OrdreId = model.OrdreId
                // Map other properties from SjekklisteViewModel to Sjekkliste
            };

            _sjekklisteRepository.Update(sjekkliste);

            return RedirectToAction("Index", "Ordre");
        }
    }
}
