using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.ServiceSkjema;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class ServiceSkjemaControllerTests
    {

        
        // Sjekker om indexmetoden i ServiceSkjemaController returnerer et view fylt med en liste over ServiceSkjemaer
        [Fact]
        public void Index_ReturnsViewWithServiceSchemas()
        {
            // Arrange
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);

            // Mocking GetAllServiceSchemas to return a list of ServiceSkjema
            mockServiceSkjemaRepository.Setup(repo => repo.GetAllServiceSchemas())
                .Returns(new List<ServiceSkjema> { new ServiceSkjema(), new ServiceSkjema() });

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ServiceSkjema>>(result.Model);
            Assert.Equal(2, (result.Model as List<ServiceSkjema>).Count);
        }

        
        // Sikrer at Create-metoden i ServiceSkjemaController videresender til Upsert-handlingen.
        [Fact]
        public void Create_RedirectsToUpsert()
        {
            // Arrange
            int ordreId = 1; // Define a sample ordreId
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);

            // Act
            var result = controller.Create(ordreId) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Upsert", result.ActionName);
            Assert.Null(result.ControllerName); // Assert no specific controller name is set
        }

        

        // Bekrefter om Upsert-handlingen (GET) i ServiceSkjemaController returnerer en visning, og forventer et ServiceSkjema-objekt.
        [Fact]
        public void Upsert_Get_ReturnsView()
        {
            // Arrange
            int serviceSkjemaId = 1;
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);

            // Mock the Get method of the repository to return a ServiceSkjema
            mockServiceSkjemaRepository.Setup(repo => repo.Get(serviceSkjemaId))
                .Returns(new ServiceSkjema());

            // Act
            var result = controller.Upsert(serviceSkjemaId) as ViewResult;

            // Assert
            Assert.NotNull(result);
        }




        // Sjekker om Upsert-handlingen (POST) i ServiceSkjemaController med en gyldig modell videresender til "Index"-handlingen i "Ordre"-kontrolleren.
        [Fact]
        public void Upsert_Post_ValidModel_ReturnsRedirectToAction()
        {
            // Arrange
            var model = new ServiceSkjemaViewModel(); // gir en valid model
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);

            // Act
            var result = controller.Upsert(model) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Ordre", result.ControllerName);
        }




        // Bekrefter at Upsert-handlingen (POST) i ServiceSkjemaController med en ugyldig modell returnerer en visning som inneholder valideringsfeil.
        [Fact]
        public void Upsert_Post_InvalidModel_ReturnsViewWithErrors()
        {
            // Arrange
            var model = new ServiceSkjemaViewModel(); // gir en invalid model
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);
            controller.ModelState.AddModelError("Property", "Error Message");

            // Act
            var result = controller.Upsert(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ViewData.ModelState.ErrorCount > 0);
        }
        
    }
}