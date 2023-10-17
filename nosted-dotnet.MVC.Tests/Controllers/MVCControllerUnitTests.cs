using nosted-dotnet.MVC.Controllers;
using nosted-dotnet.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace nosted_dotnet.MVC.Tests.Controllers
{
  public class MVCControllerUnitTests {

    // Test that the Index action in HomeController returns a ViewResult.
    [Fact]
    public void IndexReturnsViewResult()
    {
        var fakeLogger = new FakeLogger<HomeController>();
        var controller = new HomeController(fakeLogger);

        var result = controller.Index() as ViewResult;

        Assert.NotNull(result);
        Assert.Empty(fakeLogger.LogMessages); // Ensure no logging occurred
    }

    // Test that the Error action in HomeController returns a ViewResult
    // with an ErrorViewModel as its model. It also ensures that no logging occurred during the test.
    [Fact]
    public void ErrorReturnsViewResultWithModel()
    {
        var fakeLogger = new FakeLogger<HomeController>();
        var controller = new HomeController(fakeLogger);

        var result = controller.Error() as ViewResult;

        Assert.NotNull(result);
        Assert.IsType<ErrorViewModel>(result.Model);
        Assert.Empty(fakeLogger.LogMessages);
    }

//checklist unitester

    // Test that the Index action in CheckListController returns a ViewResult
    [Fact]
    public void IndexReturnsViewResultWithModel()
    {
        var fakeLogger = new FakeLogger<CheckListController>();
        var controller = new CheckListController();

        var result = controller.Index() as ViewResult;

        Assert.NotNull(result);
        Assert.IsType<CheckListViewModel>(result.Model);
        Assert.Empty(fakeLogger.LogMessages);
    }

    // Test that the Index action in CheckListController, when provided with a model,
    // returns a RedirectToActionResult that redirects to the "Index" action.
    [Fact]
    public void IndexPostHandlesData()
    {
        var fakeLogger = new FakeLogger<CheckListController>();
        var controller = new CheckListController();

        var result = controller.Index(new CheckListViewModel()) as IActionResult;

        Assert.IsType<RedirectToActionResult>(result);
        var redirectResult = result as RedirectToActionResult;
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Empty(fakeLogger.LogMessages);
    }
  }
}

