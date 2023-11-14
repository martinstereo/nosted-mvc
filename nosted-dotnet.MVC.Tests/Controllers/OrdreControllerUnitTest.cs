﻿using Microsoft.AspNetCore.Mvc;
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
            var controllerUnderTest = GetUnitUnderTest();


            //Act
            var result = controllerUnderTest.Post(
                new Adresse
                    {
                        Gate = "Universitetsveien 2",
                        Postkode = 5543,
                        Poststed = "Oslo"

                    }
                
                )
        }

    }
}
