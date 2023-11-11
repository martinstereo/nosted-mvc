using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Repositories;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class OrdreControllerUnitTest
    {
        private IAdresseRepository mockAdresseRepository;
        private IKundeRepository mockKundeRepository;
        private IProduktRepository mockProduktRepository;
        private IOrdreRepository mockOrdreRepository;
        private IServiceSkjemaRepository mockServiceSkjemaRepository;
        private ISjekklisteRepository mockSjekklisteRepository;

        private OrdreController GetUnitUnderTest()
        {
            return new OrdreController(mockAdresseRepository, mockKundeRepository, mockProduktRepository, mockOrdreRepository, mockServiceSkjemaRepository, mockSjekklisteRepository);
        }

        [Fact]
        public void IndexReturnsViewWithOrders() 
        {
            // Arrange
            var OrdreControllerUnderTest = GetUnitUnderTest();

            var ordre = mockOrdreRepository.GetAll();
            var model = ordre.Select(o => new OrdreIndexViewModel
            {
                OrdreId = o.Id,
                Fornavn = mockKundeRepository.Get(o.KundeId).Navn,
                Etternavn = mockKundeRepository.Get(o.KundeId).Etternavn,
                Type = mockProduktRepository.Get(o.ProduktId).Type,
                RegNr = mockProduktRepository.Get(o.ProduktId).RegNr,
                ServiceDato = o.ServiceDato
            }).ToList();

            // Act
            var result = OrdreControllerUnderTest.Index() as ViewResult;

            //Assert
            Assert.IsType<OrdreIndexViewModel>(result.Model);
        }

    }
}
