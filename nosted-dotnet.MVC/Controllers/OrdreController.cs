﻿using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Entities;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Repositories;


namespace nosted_dotnet.MVC.Controllers
{
    public class OrdreController : Controller
    {
        private readonly IAdresseRepository _adresseRepository;
        private readonly IKundeRepository _kundeRepository;
        private readonly IProduktRepository _produktRepository;
        private readonly IOrdreRepository _ordreRepository;
        private readonly IServiceSkjemaRepository _serviceSkjemaRepository;
        
        public OrdreController(IAdresseRepository adresseRepository, IKundeRepository kundeRepository, IProduktRepository produktRepository, IOrdreRepository ordreRepository, IServiceSkjemaRepository serviceSkjemaRepository)
        {
            _adresseRepository = adresseRepository;
            _produktRepository = produktRepository;
            _kundeRepository = kundeRepository;
            _ordreRepository = ordreRepository;
            _serviceSkjemaRepository = serviceSkjemaRepository;
        }

        public IActionResult Index()
        {
            var ordre = _ordreRepository.GetAll();
            var model = ordre.Select(o => new OrdreIndexViewModel
            {
                OrdreId = o.Id,
                Fornavn = _kundeRepository.Get(o.KundeId).Navn,
                Etternavn = _kundeRepository.Get(o.KundeId).Etternavn,
                Type = _produktRepository.Get(o.ProduktId).Type,
                RegNr = _produktRepository.Get(o.ProduktId).RegNr,
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
                Gate = x.Gate }).ToList();
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
                Type = x.Type
            }).ToList();
            model.OrdreList = _ordreRepository.GetAll().Select(x => new OrdreViewModel
            {
                OrdreId = x.Id, 
                ServiceDato = x.ServiceDato, 
                ServiceRep = x.ServiceRep
            }).ToList();
            return View("Create",model);
        }

        
        public IActionResult Post(OrderFullViewModel adresse, OrderFullViewModel kunde, OrderFullViewModel produkt, OrderFullViewModel ordre)
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
            
            return Create();
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
                    // Add the rest of the properties here...
                }
            };

            return View(model);
        }
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
                },
                Kunde = new OrdreViewModel()
                {
                    //KundeId = kunde.Id,
                    Fornavn = kunde.Navn,
                    Etternavn = kunde.Etternavn,
                    Email = kunde.Email,
                    TelefonNr = kunde.TelefonNr,
                    // Add the rest of the properties here...
                },
                Adresse = new OrdreViewModel()
                {
                    //AdreseeId = adresse.Id,
                    Postkode = adresse.Postkode,
                    Poststed = adresse.Poststed,
                    Gate = adresse.Gate,
                    // Add the rest of the properties here...
                },
                Produkt = new OrdreViewModel()
                {
                    //ProduktId = produkt.Id,
                    RegNr = produkt.RegNr,
                    Model = produkt.Model,
                    Type = produkt.Type,
                    // Add the rest of the properties here...
                }
            };

            return View(model);
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
                    Id = model.Kunde.KundeId,
                    Navn = model.Kunde.Fornavn,
                    Etternavn = model.Kunde.Etternavn,
                    Email = model.Kunde.Email,
                    TelefonNr = model.Kunde.TelefonNr,
                    //AdresseId = model.Adresse.AdreseeId
                };
                _kundeRepository.Upsert(kunde);

                var adresse = new Adresse
                {
                    Id = model.Adresse.AdreseeId,
                    Postkode = model.Adresse.Postkode,
                    Poststed = model.Adresse.Poststed,
                    Gate = model.Adresse.Gate
                };
                _adresseRepository.Upsert(adresse);

                var produkt = new Produkt
                {
                    //Id = model.Produkt.ProduktId,
                    RegNr = model.Produkt.RegNr,
                    Model = model.Produkt.Model,
                    Type = model.Produkt.Type
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

        

        [HttpPost]
        public IActionResult Create(OrderFullViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Behandle den gyldige modellen her (lagre den i databasen, osv.)
                // ...
                return RedirectToAction("Suksess"); // Redirect til en suksessside etter opprettelse
            }

            // Hvis modellen ikke er gyldig, vis skjemaet igjen med feilmeldinger
            return View(model);
        }
    }
}
    
