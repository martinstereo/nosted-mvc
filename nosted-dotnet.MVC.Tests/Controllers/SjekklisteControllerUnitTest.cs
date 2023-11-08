using Moq;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Models.Sjekkliste;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Tests.Controllers;

public class SjekklisteControllerUnitTest
{

    [Fact]
    public void Index_ActionExecutes_ReturnsViewWithSjekklisteList()
    {
        // Arrange
        var mockRepo = new Mock<ISjekklisteRepository>();
        var sjekklisteList = new List<Sjekkliste> { new Sjekkliste(), new Sjekkliste() };
        mockRepo.Setup(repo => repo.GetAllSjekklister()).Returns(sjekklisteList);
        var controller = new SjekklisteController(mockRepo.Object);

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<List<Sjekkliste>>(viewResult.Model);
        Assert.Equal(sjekklisteList, model);
    }


    [Fact]
    public void Create_ActionExecutes_RedirectsToUpsertView()
    {
        // Arrange
        var mockRepo = new Mock<ISjekklisteRepository>();
        var controller = new SjekklisteController(mockRepo.Object);
        int testOrdreId = 1;

        // Act
        var result = controller.Create(testOrdreId);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Upsert", redirectToActionResult.ActionName);
    }

    [Fact]
    public void Upsert_ActionExecutes_ReturnsViewForValidId()
    {
        // Arrange
        int testId = 1;
        var sjekkliste = new Sjekkliste { Id = testId };
        var mockRepo = new Mock<ISjekklisteRepository>();
        mockRepo.Setup(repo => repo.Get(testId)).Returns(sjekkliste);
        var controller = new SjekklisteController(mockRepo.Object);

        // Act
        var result = controller.Upsert(testId);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsType<SjekklisteViewModel>(viewResult.Model);
        Assert.Equal(testId, model.Id);
    }

    [Fact]
    public void Upsert_ActionExecutes_RedirectsToIndexView()
    {
        // Arrange
        var sjekklisteViewModel = new SjekklisteViewModel { Id = 1 };
        var mockRepo = new Mock<ISjekklisteRepository>();
        var controller = new SjekklisteController(mockRepo.Object);

        // Act
        var result = controller.Upsert(sjekklisteViewModel);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
        Assert.Equal("Ordre", redirectToActionResult.ControllerName);
    }
}