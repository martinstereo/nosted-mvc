using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Repositories;
using NuGet.Protocol.Core.Types;
using System.Linq.Expressions;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class OrdreControllerUnitTest
    {
        private Mock<IOrdreRepository> mockOrdreRepo;
        private Mock<IAdresseRepository> mockAdresseRepo;
        private Mock<IKundeRepository> mockKundeRepo;
        private Mock<IProduktRepository> mockProduktRepo;
        private Mock<IServiceSkjemaRepository> mockServiceSkjemaRepo;
        private Mock<ISjekklisteRepository> mockSjekklisteRepo;

        private void SetupFakeContext()
        {
            mockOrdreRepo = new Mock<IOrdreRepository>();
            mockAdresseRepo = new Mock<IAdresseRepository>();
            mockKundeRepo = new Mock<IKundeRepository>();
            mockProduktRepo = new Mock<IProduktRepository>();
            mockServiceSkjemaRepo = new Mock<IServiceSkjemaRepository>();
            mockSjekklisteRepo = new Mock<ISjekklisteRepository>();

            mockOrdreRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Ordre> { new Ordre(), new Ordre() });
            mockAdresseRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Adresse> { new Adresse() { Gate = "Universitetsgata 1", Postkode = 2231, Poststed = "Kristiansand" }, new Adresse() { Gate = "Universitetsgata 1", Postkode = 2231, Poststed = "Kristiansand" } });
            mockKundeRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Kunde> { new Kunde(), new Kunde() });
            mockProduktRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Produkt> { new Produkt(), new Produkt() });
            mockServiceSkjemaRepo.Setup(repo => repo.GetAllServiceSchemas()).Returns(new List<ServiceSkjema> { new ServiceSkjema(), new ServiceSkjema() });
            mockSjekklisteRepo.Setup(repo => repo.GetAllSjekklister()).Returns(new List<Sjekkliste> { new Sjekkliste(), new Sjekkliste() });
        }

        private OrdreController GetUnitUnderTest()
        {
            SetupFakeContext();
            return new OrdreController(mockAdresseRepo.Object, mockKundeRepo.Object, mockProduktRepo.Object, mockOrdreRepo.Object, mockServiceSkjemaRepo.Object, mockSjekklisteRepo.Object);

        }

        [Fact]
        public void IndexReturnsViewWithOrders() 
        {
            // Arrange
            var controllerUnderTest = GetUnitUnderTest();
            
            // Act
            var result = controllerUnderTest.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.IsType <List<OrdreIndexViewModel>>(result.Model);
            Assert.Equal(2, (result.Model as List<OrdreIndexViewModel>).Count);
        }

        [Fact]
        public void PostSendsCorrectValuesToRepository()
        {
            //Arrange
            SetupFakeContext();
            var controller = GetUnitUnderTest();

            // Capture the argument using Callback during setup
            Ordre capturedOrder = null;
            mockOrdreRepo.Setup(repo => repo.Upsert(It.IsAny<Ordre>()))
                .Callback<Ordre>(ordre => capturedOrder = ordre);

            Adresse capturedAdresse = null;
            mockAdresseRepo.Setup(repo => repo.Upsert(It.IsAny<Adresse>()))
                .Callback<Adresse>(adresse => capturedAdresse = adresse);

            Kunde capturedKunde = null;
            mockKundeRepo.Setup(repo => repo.Upsert(It.IsAny<Kunde>()))
                .Callback<Kunde>(kunde => capturedKunde = kunde);

            Produkt capturedProdukt = null;
            mockProduktRepo.Setup(repo => repo.Upsert(It.IsAny<Produkt>()))
                .Callback<Produkt>(produkt => capturedProdukt = produkt);

            //Act
            controller.Post(
                new OrderFullViewModel
                {
                    UpsertModel = new OrdreViewModel
                    {
                        AdreseeId = 1,
                        Postkode = 1234,
                        Poststed = "Mandal",
                        Gate = "Mandalsgata 1"
                    }
                },
                new OrderFullViewModel
                {
                    UpsertModel = new OrdreViewModel
                    {
                        KundeId = 1,
                        Fornavn = "Per",
                        Etternavn = "Gunnar",
                        TelefonNr = "12345678",
                        Email = "pgunnar@nosted.com",
                    }
                },
                new OrderFullViewModel
                {
                    UpsertModel = new OrdreViewModel
                    {
                        ProduktId = 1,
                        RegNr = "DD12345",
                        Type = "Vinsj",
                        Model = "2023FF",
                        Garanti = "Nei",
                    }
                },
                new OrderFullViewModel
                {
                    UpsertModel = new OrdreViewModel
                    {
                        OrdreId = 1,
                        ServiceDato = new DateTime(2022, 1, 1),
                        ServiceRep = "Reperasjon"
                    }
                }
                ) ;

            //Assert
                //  This is telling Moq to verify that a specific method on the mocked object has been called with specific arguments.
                //  specifies that the Upsert-method on the repository should be called with any instance of X as an argument
            mockOrdreRepo.Verify(repo => repo.Upsert(It.IsAny<Ordre>()), Times.AtLeastOnce);  
            mockAdresseRepo.Verify(repo => repo.Upsert(It.IsAny<Adresse>()), Times.AtLeastOnce);
            mockKundeRepo.Verify(repo => repo.Upsert(It.IsAny<Kunde>()), Times.AtLeastOnce);
            mockProduktRepo.Verify(repo => repo.Upsert(It.IsAny<Produkt>()), Times.AtLeastOnce);

            Assert.NotNull(capturedOrder);
            Assert.Equal(1, capturedOrder.Id);
            
            Assert.NotNull(capturedAdresse);
            Assert.Equal(1, capturedAdresse.Id);

            Assert.NotNull(capturedKunde);
            Assert.Equal(1, capturedKunde.Id);
            
            Assert.NotNull(capturedProdukt);
            Assert.Equal(1, capturedProdukt.Id);

        }

    }
}
