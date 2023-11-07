using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.Diagnostics;
using Xunit;

namespace nosted_dotnet.MVC.Tests
{
    public class ServiceSkjemaControllerTests
    {
     

        // 1. Test for the Upsert (GET) action
        [Fact]
        public void Upsert_Get_ReturnsView()
        {
            // Arrange
            int serviceSkjemaId = 1; // Provide a valid serviceSkjemaId
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




        // 2. Test for the Upsert (POST) action with valid model
        [Fact]
        public void Upsert_Post_ValidModel_ReturnsRedirectToAction()
        {
            // Arrange
            var model = new ServiceSkjemaViewModel(); // Provide a valid model
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);

            // Act
            var result = controller.Upsert(model) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Ordre", result.ControllerName);
        }




        // 3. Test for the Upsert (POST) action with invalid model
        [Fact]
        public void Upsert_Post_InvalidModel_ReturnsViewWithErrors()
        {
            // Arrange
            var model = new ServiceSkjemaViewModel(); // Provide an invalid model
            var mockServiceSkjemaRepository = new Mock<IServiceSkjemaRepository>();
            var controller = new ServiceSkjemaController(mockServiceSkjemaRepository.Object);
            controller.ModelState.AddModelError("Property", "Error Message");

            // Act
            var result = controller.Upsert(model) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(result.ViewData.ModelState.ErrorCount > 0);
        }

        // Additional tests for edge cases and other scenarios can be added here.
    }
}
