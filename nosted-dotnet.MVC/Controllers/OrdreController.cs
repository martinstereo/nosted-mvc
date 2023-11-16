using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace nosted_dotnet.MVC.Controllers
{
    [Authorize]
    public class OrdreController : Controller
    {
        private readonly IAdresseRepository _adresseRepository;
        private readonly IKundeRepository _kundeRepository;
        private readonly IProduktRepository _produktRepository;
        private readonly IOrdreRepository _ordreRepository;
        private readonly IServiceSkjemaRepository _serviceSkjemaRepository;
        private readonly ISjekklisteRepository _sjekklisteRepository;

        public OrdreController(IAdresseRepository adresseRepository, IKundeRepository kundeRepository,
            IProduktRepository produktRepository, IOrdreRepository ordreRepository,
            IServiceSkjemaRepository serviceSkjemaRepository, ISjekklisteRepository sjekklisteRepository)
        {
            _adresseRepository = adresseRepository;
            _produktRepository = produktRepository;
            _kundeRepository = kundeRepository;
            _ordreRepository = ordreRepository;
            _serviceSkjemaRepository = serviceSkjemaRepository;
            _sjekklisteRepository = sjekklisteRepository;
        }

        public IActionResult Index()
        {
            var ordre = _ordreRepository.GetAll();
            var model = ordre.Select(o => new OrdreIndexViewModel
            {
                OrdreId = o.Id,
                Fornavn = _kundeRepository.Get(o.KundeId)?.Navn,
                Etternavn = _kundeRepository.Get(o.KundeId)?.Etternavn,
                Type = _produktRepository.Get(o.ProduktId)?.Type,
                RegNr = _produktRepository.Get(o.ProduktId)?.RegNr,
                ServiceDato = o.ServiceDato
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new OrderFullViewModel();
            model.OrdreList = _adresseRepository.GetAll().Select(x => new OrdreViewModel
            {
                AdreseeId = x.Id,
                Postkode = x.Postkode,
                Poststed = x.Poststed,
                Gate = x.Gate
            }).ToList();
            model.OrdreList = _kundeRepository.GetAll().Select(x => new OrdreViewModel
            {
                KundeId = x.Id,
                Fornavn = x.Navn,
                Etternavn = x.Etternavn,
                TelefonNr = x.TelefonNr,
                Email = x.Email
            }).ToList();
            model.OrdreList = _produktRepository.GetAll().Select(x => new OrdreViewModel
            {
                ProduktId = x.Id,
                Model = x.Model,
                RegNr = x.RegNr,
                Type = x.Type,
                Garanti = x.Garanti,
            }).ToList();
            model.OrdreList = _ordreRepository.GetAll().Select(x => new OrdreViewModel
            {
                OrdreId = x.Id,
                ServiceDato = x.ServiceDato,
                ServiceRep = x.ServiceRep,
            }).ToList();
            return View("Create", model);
        }


        public IActionResult Post(OrderFullViewModel adresse, OrderFullViewModel kunde, OrderFullViewModel produkt,
            OrderFullViewModel ordre)
        {
            var aentity = new Adresse
            {
                Id = adresse.UpsertModel.AdreseeId,
                Postkode = adresse.UpsertModel.Postkode,
                Poststed = adresse.UpsertModel.Poststed,
                Gate = adresse.UpsertModel.Gate,
            };
            _adresseRepository.Upsert(aentity);

            var kentity = new Kunde
            {
                Id = kunde.UpsertModel.KundeId,
                Navn = kunde.UpsertModel.Fornavn,
                Etternavn = kunde.UpsertModel.Etternavn,
                Email = kunde.UpsertModel.Email,
                TelefonNr = kunde.UpsertModel.TelefonNr,
                AdresseId = aentity.Id

            };
            _kundeRepository.Upsert(kentity);

            var pentity = new Produkt
            {
                Id = produkt.UpsertModel.ProduktId,
                RegNr = produkt.UpsertModel.RegNr,
                Model = produkt.UpsertModel.Model,
                Type = produkt.UpsertModel.Type,
                Garanti = produkt.UpsertModel.Garanti,
            };
            _produktRepository.Upsert(pentity);

            var oentity = new Ordre
            {
                Id = ordre.UpsertModel.OrdreId,
                ServiceDato = ordre.UpsertModel.ServiceDato,
                ServiceRep = ordre.UpsertModel.ServiceRep,
                KundeId = kentity.Id,
                ProduktId = pentity.Id

            };
            _ordreRepository.Upsert(oentity);


            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var ordre = _ordreRepository.Get(id);
            if (ordre == null)
            {
                return NotFound();
            }

            var kunde = _kundeRepository.Get(ordre.KundeId);
            var adresse = _adresseRepository.Get(kunde.AdresseId);
            var produkt = _produktRepository.Get(ordre.ProduktId);

            var model = new OrdreDetailsViewModel
            {
                Ordre = new OrdreViewModel
                {
                    OrdreId = ordre.Id,
                    ServiceDato = ordre.ServiceDato,
                    ServiceRep = ordre.ServiceRep,
                    // Add the rest of the properties here...
                },
                Kunde = new OrdreViewModel
                {
                    KundeId = kunde.Id,
                    Fornavn = kunde.Navn,
                    Etternavn = kunde.Etternavn,
                    Email = kunde.Email,
                    TelefonNr = kunde.TelefonNr,
                    // Add the rest of the properties here...
                },
                Adresse = new OrdreViewModel
                {
                    AdreseeId = adresse.Id,
                    Postkode = adresse.Postkode,
                    Poststed = adresse.Poststed,
                    Gate = adresse.Gate,
                    // Add the rest of the properties here...
                },
                Produkt = new OrdreViewModel
                {
                    ProduktId = produkt.Id,
                    RegNr = produkt.RegNr,
                    Model = produkt.Model,
                    Type = produkt.Type,
                    Garanti = produkt.Garanti,
                    // Add the rest of the properties here...
                }
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ordre = _ordreRepository.Get(id);
            if (ordre == null)
            {
                return NotFound();
            }


            var kunde = _kundeRepository.Get(ordre.KundeId);
            var adresse = _adresseRepository.Get(kunde.AdresseId);
            var produkt = _produktRepository.Get(ordre.ProduktId);

            var model = new OrdreEditViewModel
            {
                Ordre = new OrdreViewModel
                {
                    OrdreId = ordre.Id,
                    ServiceDato = ordre.ServiceDato,
                    ServiceRep = ordre.ServiceRep,
                    // Add the rest of the properties here...

                    KundeId = kunde.Id,
                    Fornavn = kunde.Navn,
                    Etternavn = kunde.Etternavn,
                    Email = kunde.Email,
                    TelefonNr = kunde.TelefonNr,
                    // Add the rest of the properties here...

                    AdreseeId = adresse.Id,
                    Postkode = adresse.Postkode,
                    Poststed = adresse.Poststed,
                    Gate = adresse.Gate,
                    // Add the rest of the properties here...

                    ProduktId = produkt.Id,
                    RegNr = produkt.RegNr,
                    Model = produkt.Model,
                    Type = produkt.Type,
                    Garanti = produkt.Garanti,
                    // Add the rest of the properties here...
                }
            };

            return View(model);
        }



        public IActionResult Delete(int id)
        {
            var ordre = _ordreRepository.Get(id);
            if (ordre == null)
            {
                return NotFound();
            }

            return View(ordre); // Pass the order to the delete confirmation view
        }



        [HttpPost]

        public IActionResult DeleteConfirmed(int id)
        {
            var ordre = _ordreRepository.Get(id);
            if (ordre == null)
            {
                return NotFound();
            }

            // Perform the deletion of the order
            _ordreRepository.Delete(id);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(OrdreEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ordre = new Ordre
                {
                    Id = model.Ordre.OrdreId,
                    ServiceDato = model.Ordre.ServiceDato,
                    ServiceRep = model.Ordre.ServiceRep,
                    //KundeId = model.Kunde.KundeId,
                    //ProduktId = model.Produkt.ProduktId
                };
                _ordreRepository.Upsert(ordre);

                var kunde = new Kunde
                {
                    Id = model.Ordre.KundeId,
                    Navn = model.Ordre.Fornavn,
                    Etternavn = model.Ordre.Etternavn,
                    Email = model.Ordre.Email,
                    TelefonNr = model.Ordre.TelefonNr,
                    //AdresseId = model.Adresse.AdreseeId
                };
                _kundeRepository.Upsert(kunde);

                var adresse = new Adresse
                {
                    Id = model.Ordre.AdreseeId,
                    Postkode = model.Ordre.Postkode,
                    Poststed = model.Ordre.Poststed,
                    Gate = model.Ordre.Gate
                };
                _adresseRepository.Upsert(adresse);

                var produkt = new Produkt
                {
                    Id = model.Ordre.ProduktId,
                    RegNr = model.Ordre.RegNr,
                    Model = model.Ordre.Model,
                    Type = model.Ordre.Type,
                    Garanti = model.Ordre.Garanti,
                };
                _produktRepository.Upsert(produkt);

                return RedirectToAction("Index", "Ordre");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // Service Skjema
        public IActionResult CreateServiceSkjema(int id)
        {
            // Try to get the existing ServiceSkjema for the order
            var serviceSkjema = _serviceSkjemaRepository.GetByOrderId(id);

            if (serviceSkjema == null)
            {
                // If there's no existing ServiceSkjema for the order, create a new one
                serviceSkjema = new ServiceSkjema
                {
                    OrdreId = id
                };
                _serviceSkjemaRepository.Upsert(serviceSkjema);
            }

            // Redirect to the ServiceSkjema index page with the ServiceSkjema id
            return RedirectToAction("Upsert", "ServiceSkjema", new { id = serviceSkjema.Id });
        }

        public IActionResult CreateSjekkliste(int id)
        {
            // Try to get the existing ServiceSkjema for the order
            var sjekkliste = _sjekklisteRepository.GetByOrderId(id);

            if (sjekkliste == null)
            {
                // If there's no existing ServiceSkjema for the order, create a new one
                sjekkliste = new Sjekkliste
                {
                    OrdreId = id
                };
                _sjekklisteRepository.Upsert(sjekkliste);
            }

            // Redirect to the ServiceSkjema index page with the ServiceSkjema id
            return RedirectToAction("Upsert", "Sjekkliste", new { id = sjekkliste.Id });
        }
    }
}
    
