using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nosted_dotnet.MVC.Tests.Controllers
{
    public class AccountControllerUnitTest
    {
        [Fact]
        public async Task Register_ValidModel_SuccessfulRegistration()
        {
            // Arrange
            var userManagerMock = new Mock<UserManager<IdentityUser>>();
            var signInManagerMock = new Mock<SignInManager<IdentityUser>>(userManagerMock, null, null, null, null, null, null);
            var emailSenderMock = new Mock<IEmailSender>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var loggerMock = new Mock<ILoggerFactory>();

            var controller = new AccountController(userManagerMock.Object, signInManagerMock.Object, emailSenderMock.Object, loggerMock.Object, userRepositoryMock.Object);

            var model = new RegisterViewModel
            {
                Email = "admin@nosted.no",
                Password = "Test@123",
                IsAdmin = true,
            };

            // Act
            var result = await controller.Register(model);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(typeof(RedirectToActionResult), result.GetType());

        }
    }
    
}
