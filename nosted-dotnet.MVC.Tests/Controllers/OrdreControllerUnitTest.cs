using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Repositories;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class OrdreControllerUnitTest
    {
        // private IAdresseRepository mockAdresseRepository;
        private IKundeRepository mockKundeRepository;
        private IProduktRepository mockProduktRepository;
        private IOrdreRepository mockOrdreRepository;
        private IServiceSkjemaRepository mockServiceSkjemaRepository;
        private ISjekklisteRepository mockSjekklisteRepository;

        private void InitializeFakes()
        {
            mockKundeRepository = new Mock<IKundeRepository>().Object;
            mockProduktRepository = new Mock<IProduktRepository>().Object;
            mockOrdreRepository = new Mock<IOrdreRepository>().Object;
            mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>().Object;
            mockSjekklisteRepository = new Mock<ISjekklisteRepository>().Object;
        }

        private OrdreController GetUnitUnderTest()
        {
            InitializeFakes();
            return new OrdreController(mockKundeRepository, mockProduktRepository, mockOrdreRepository, mockServiceSkjemaRepository, mockSjekklisteRepository)
            {

            };
        }

        [Fact]
        public void IndexReturnsViewWithOrders() 
        {
            // Arrange
            var OrdreControllerUnderTest = GetUnitUnderTest();


            // Act

            var result = OrdreControllerUnderTest.Index() as ViewResult;
            
            //Assert



        }

    }
}
