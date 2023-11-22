using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Users;

namespace nosted_dotnet.MVC.Tests.Controllers;


public class UsersControllerUnitTest
{
    private Mock<IUserRepository> userRepositoryMock;

    private void SetupFakeContext()
    {
        userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUsers()).Returns(
        new List<UserEntity> {
            new UserEntity()
            {
                Id = 1,
                Navn = "Admin",
                Email = "admin@nosted.no"
            },
            new UserEntity()
            {
                Id = 2,
                Navn = "Ansatt",
                Email = "ansatt@nosted.no"
            }
        });
    }

    [Fact]
    public void Index_ReturnsViewWithUserViewModels()
    {
        // Arrange
        SetupFakeContext();
        var controller = new UsersController(userRepositoryMock.Object);

        // Act
        var result = controller.Index("admin@nosted.no") as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ViewResult>(result);
    }

    
    [Fact]
    public void Save_WithValidModel_RedirectsToIndex()
    {
        // Arrange
        SetupFakeContext();
        var controller = new UsersController(userRepositoryMock.Object);
        var validModel = new UserViewModel { Navn = "Administrator", Email = "johndoe@example.com" };

        // Act
        var result = controller.Save(validModel);

        // Assert
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectToActionResult.ActionName);
    }

        
}