using Microsoft.AspNetCore.Mvc;
using Moq;
using nosted_dotnet.MVC.Controllers;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Users;

namespace nosted_dotnet.MVC.Tests.Controllers;

/*
public class UsersControllerUnitTest
{
    [Fact]
    public void Index_ReturnsViewWithUserViewModels()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUsers()).Returns(new List<UserEntity>());

        var controller = new UsersController(userRepositoryMock.Object);

        // Act
        var result = controller.Index();

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<UserViewModel>>(viewResult.ViewData.Model);
        Assert.Empty(model); // Ensure the model is empty in this example
    }

    [Fact]
    public void Add_ReturnsViewWithUserViewModels()
    {
        // Arrange
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(repo => repo.GetUsers()).Returns(new List<UserEntity>());

        var controller = new UsersController(userRepositoryMock.Object);

        // Act
        var result = controller.Add(null);

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<List<UserViewModel>>(viewResult.ViewData.Model);
        Assert.Empty(model); // Ensure the model is empty in this example
    }
    
    [Fact]
        public void Save_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUsers()).Returns(new List<UserEntity>());
            var controller = new UsersController(userRepositoryMock.Object);
            var validModel = new UserViewModel { Fornavn = "John", Etternavn = "Doe", Email = "john.doe@example.com" };

            // Act
            var result = controller.Save(validModel);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public void Edit_ReturnsViewWithUsersEditViewModel()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).Returns(new UserEntity());
            var controller = new UsersController(userRepositoryMock.Object);

            // Act
            var result = controller.Edit("test@example.com");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UsersEditViewModel>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public void Delete_ReturnsViewWithUser()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).Returns(new UserEntity());
            var controller = new UsersController(userRepositoryMock.Object);

            // Act
            var result = controller.Delete("test@example.com");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<UserEntity>(viewResult.ViewData.Model);
            Assert.NotNull(model);
        }

        [Fact]
        public void DeleteConfirmed_DeletesUserAndRedirectsToIndex()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(repo => repo.GetUserByEmail(It.IsAny<string>())).Returns(new UserEntity());
            var controller = new UsersController(userRepositoryMock.Object);

            // Act
            var result = controller.DeleteConfirmed("test@example.com");

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            userRepositoryMock.Verify(repo => repo.Delete("test@example.com"), Times.Once);
        }
    }
*/