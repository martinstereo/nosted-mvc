using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.User;
using nosted_dotnet.MVC.Entites;
using nosted_dotnet.MVC.Models.Users;

namespace nosted_dotnet.MVC.Controllers
{
    
        //[Authorize]
        public class UsersController : Controller
        {
            private readonly IUserRepository userRepository;

            public UsersController(IUserRepository userRepository)
            {
                this.userRepository = userRepository;
            }
            [HttpGet]
            public IActionResult Index(string? email)
            {
                var model = new UserViewModel();
                model.Users = userRepository.GetUsers();
                if (email != null)
                {
                    var currentUser = model.Users.FirstOrDefault(x => x.Email == email);
                    if (currentUser != null)
                    {

                        model.Email = currentUser.Email;
                        model.Fornavn = currentUser.Fornavn;
                        model.Etternavn = currentUser.Etternavn;
                        model.IsAdmin = userRepository.IsAdmin(currentUser.Email);
                    }
                }
                return View(model);
            }

            [HttpPost]
            public IActionResult Save(UserViewModel model)
            {

                UserEntity newUser = new UserEntity
                {
                    Fornavn = model.Fornavn,
                    Etternavn = model.Etternavn,
                    Email = model.Email,
                };
                var roles = new List<string>();
                if (model.IsAdmin)
                    roles.Add("Administrator");

                if (userRepository.GetUsers().FirstOrDefault(x => x.Email.Equals(newUser.Email, StringComparison.InvariantCultureIgnoreCase)) != null)
                    userRepository.Update(newUser, roles);
                else
                    userRepository.Add(newUser);

                return RedirectToAction("Index");
            }

            [HttpPost]
            public IActionResult Delete(string email)
            {
                userRepository.Delete(email);
                return RedirectToAction("Index");
            }
        }
    }
