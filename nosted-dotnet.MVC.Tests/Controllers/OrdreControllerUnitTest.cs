using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using nosted_dotnet.MVC.Repositories;
using System.Drawing;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class OrdreControllerUnitTest
    {

        [Fact]
        public void IndexReturnsViewWithOrders() 
        {
            // Arrange
            var mockOrdreRepo = new Mock<IOrdreRepository>();
            var mockAdresseRepo = new Mock<IAdresseRepository>();
            var mockKundeRepo = new Mock<IKundeRepository>();
            var mockProduktRepo = new Mock<IProduktRepository>();
            var mockServiceSkjemaRepo = new Mock<IServiceSkjemaRepository>();
            var mockSjekklisteRepo = new Mock<ISjekklisteRepository>();

            mockOrdreRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Ordre> { new Ordre(), new Ordre() });
            mockAdresseRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Adresse> { new Adresse() { Gate = "Universitetsgata 1", Postkode = 2231, Poststed = "Kristiansand" }, new Adresse() { Gate = "Universitetsgata 1", Postkode = 2231, Poststed = "Kristiansand" } });
            mockKundeRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Kunde> { new Kunde(), new Kunde() });
            mockProduktRepo.Setup(Repositories => Repositories.GetAll()).Returns(new List<Produkt> { new Produkt(), new Produkt() });
            mockServiceSkjemaRepo.Setup(repo => repo.GetAllServiceSchemas()).Returns(new List<ServiceSkjema> { new ServiceSkjema(), new ServiceSkjema() });
            mockSjekklisteRepo.Setup(repo => repo.GetAllSjekklister()).Returns(new List<Sjekkliste> { new Sjekkliste(), new Sjekkliste() });

            var controller = new OrdreController(mockAdresseRepo.Object, mockKundeRepo.Object, mockProduktRepo.Object, mockOrdreRepo.Object, mockServiceSkjemaRepo.Object, mockSjekklisteRepo.Object);

            // Act
            var result = controller.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);

        }

    }
}
