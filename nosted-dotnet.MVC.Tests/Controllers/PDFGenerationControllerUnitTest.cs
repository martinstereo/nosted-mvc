using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Data;
using Moq;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class PdfGenerationControllerUnitTest
    {
        //test for at PDF genereres og at den kan lage for spesifikt sjekkliste 
        [Fact]
        public void GeneratePdfForSjekkliste_ReturnsPdfFileResult()
        {
            // Arrange
            string orderType = "Sjekkliste";
            int orderId = 1;

            var sjekklisteRepositoryMock = new Mock<ISjekklisteRepository>();
            var serviceSkjemaRepositoryMock = new Mock<IServiceSkjemaRepository>();

            sjekklisteRepositoryMock.Setup(repo => repo.Get(orderId))
                .Returns(new Sjekkliste()); // mock Sjekkliste
            var controller =
                new PdfGenerationController(sjekklisteRepositoryMock.Object, serviceSkjemaRepositoryMock.Object);

            // Act
            var result = controller.GeneratePdf(orderType, orderId) as FileResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("application/pdf", result.ContentType);
            Assert.Equal("Sjekkliste.pdf", result.FileDownloadName);
        }

        //test for at PDF genereres og at den kan lage for spesifikt serviceskjema
        [Fact]
        public void GeneratePdfForServiceSkjema_ReturnsPdfFileResult()
        {
            // Arrange
            string orderType = "serviceSkjema";
            int orderId = 1;

            var sjekklisteRepositoryMock = new Mock<ISjekklisteRepository>();
            var serviceSkjemaRepositoryMock = new Mock<IServiceSkjemaRepository>();

            serviceSkjemaRepositoryMock.Setup(repo => repo.Get(orderId))
                .Returns(new ServiceSkjema()); // mock ServiceSkjema
            var controller =
                new PdfGenerationController(sjekklisteRepositoryMock.Object, serviceSkjemaRepositoryMock.Object);

            // Act
            var result = controller.GeneratePdf(orderType, orderId) as FileResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("application/pdf", result.ContentType);
            Assert.Equal("serviceSkjema.pdf", result.FileDownloadName);
        }
    }
}
