using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using nosted_dotnet.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nosted_dotnet.MVC.Tests.Controllers
{

    public class HomeControllerUnitTest
    {
        [Fact]
        public void IndexReturnsCorrectContent()
        {
            // Arrange
            var fakeLogger = new Mock<ILogger<HomeController>>();
            fakeLogger.Setup(x => x.IsEnabled(It.IsAny<LogLevel>())).Returns(true);

            var unitUnderTest = new HomeController(fakeLogger.Object);

            // Act
            var result = unitUnderTest.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Same("Index", result.ViewName);
        }
    }

    public class FakeLogger<T> : ILogger<T>
    {

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {

        }
    }
}
