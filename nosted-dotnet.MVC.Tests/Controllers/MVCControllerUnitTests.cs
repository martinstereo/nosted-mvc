using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace nosted_dotnet.MVC.Tests.Controllers;

public class MvcControllerUnitTests
{
    
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger.Object);
            
            var result = controller.Index() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(logger.Object);
            
            var result = controller.Privacy() as ViewResult;
            
            Assert.NotNull(result);
        }
    }
    
    
    public class BrukerControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new BrukerController();
            
            var result = controller.Index() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsViewResultWithModel()
        {
            var controller = new BrukerController();
            
            var result = controller.Index() as ViewResult;
            var model = result?.Model as List<BrukerRad>;
            
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(0, model.Count);
        }
    }
    
    
    public class CheckListControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new CheckListController();
            
            var result = controller.Index() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsViewResultWithModel()
        {
            var controller = new CheckListController();
            
            var result = controller.Index() as ViewResult;
            var model = result?.Model as CheckListViewModel;
            
            Assert.NotNull(result);
            Assert.NotNull(model);
        }
    }
    
    
    
    public class OrdreControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new OrdreController();
            
            var result = controller.Index() as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsViewResultWithModel()
        {
            var controller = new OrdreController();
            
            var result = controller.Index() as ViewResult;
            var model = result?.Model as List<OrdreRad>;
            
            Assert.NotNull(result);
            Assert.NotNull(model);
        }
    }


    public class ServiceSkjemaControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            var controller = new ServiceSkjemaController(null);
            
            var result = controller.Index(null, null, null, null, null, null, null, null, null, null, null, null, 0,
                null, null, null, null, null) as ViewResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_ReturnsViewResultWithModel()
        {
            var controller = new ServiceSkjemaController(null);
            
            var result = controller.Index(null, null, null, null, null, null, null, null, null, null, null, null, 0,
                null, null, null, null, null) as ViewResult;
            var model = result?.Model as ServiceSkjemaViewModel;
            
            Assert.NotNull(result);
            Assert.NotNull(model);
        }
    }
}