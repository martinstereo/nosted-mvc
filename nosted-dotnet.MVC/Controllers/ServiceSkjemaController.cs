using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using Microsoft.AspNetCore.Authorization;

namespace nosted_dotnet.MVC.Controllers
{
    [Authorize]
    public class ServiceSkjemaController : Controller
    {
        private readonly IServiceSkjemaRepository _serviceSkjemaRepository;

        public ServiceSkjemaController(IServiceSkjemaRepository serviceSkjemaRepository)
        {
            _serviceSkjemaRepository = serviceSkjemaRepository;
        }

        public IActionResult Index()
        {
            var serviceSkjema = _serviceSkjemaRepository.GetAllServiceSchemas();
            
            return View(serviceSkjema);
        }
        
        // Oppretter et nytt ServiceSkjema basert på OrdreId
        public IActionResult Create(int ordreId)
        {
            var serviceSkjema = new ServiceSkjema
            {
                OrdreId = ordreId
            };
            _serviceSkjemaRepository.Upsert(serviceSkjema);

            return RedirectToAction("Upsert", new { id = serviceSkjema.Id });
        }

        // Viser eller oppdaterer et ServiceSkjema basert på Id
        public IActionResult Upsert(int id)
        {
            var serviceSkjema = _serviceSkjemaRepository.Get(id);
            if (serviceSkjema == null)
            {
                return NotFound();
            }

            var model = new ServiceSkjemaViewModel
            {
                Id = serviceSkjema.Id,
                AvtaltKunde = serviceSkjema.AvtaltKunde,
                DelerBrukt = serviceSkjema.DelerBrukt,
                DelerSkiftet = serviceSkjema.DelerSkiftet,
                RepBeskrivelse = serviceSkjema.RepBeskrivelse,
                UtførtAv = serviceSkjema.UtfortAv,
                ArbeidsTimer = serviceSkjema.ArbeidsTimer,
                OrdreId = serviceSkjema.OrdreId
            };

            return View(model);
        }
        
        // POST-handling for å lagre oppdateringer av ServiceSkjema
        [HttpPost]
        public IActionResult Upsert(ServiceSkjemaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
                }
                
                return View(model);
            }

            var serviceSkjema = new ServiceSkjema
            {
                Id = model.Id,
                AvtaltKunde = model.AvtaltKunde,
                DelerBrukt = model.DelerBrukt,
                DelerSkiftet = model.DelerSkiftet,
                RepBeskrivelse = model.RepBeskrivelse,
                UtfortAv = model.UtførtAv,
                ArbeidsTimer = model.ArbeidsTimer,
                OrdreId = model.OrdreId
            };
            _serviceSkjemaRepository.Upsert(serviceSkjema);
            return RedirectToAction("Index", "Ordre");
        }
        
    }
}
