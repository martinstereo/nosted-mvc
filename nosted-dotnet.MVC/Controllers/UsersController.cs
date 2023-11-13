using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Owin.BuilderProperties;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Data.User;
using nosted_dotnet.MVC.Entities;
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
        public IActionResult Index()
        {
            // Hent brukerdata fra en datakilde (for eksempel en database)
            var users = userRepository.GetUsers(); // Implementer metode for å hente brukere fra databasen

            // Konverter brukerdataene til UserViewModels
            var userViewModels = users.Select(user => new UserViewModel
            {
                Id = user.Id,
                Fornavn = user.Fornavn,
                Etternavn = user.Etternavn,
                Email = user.Email,
                //          IsAdmin = user.IsAdmin // Hent eller beregn isAdmin verdien basert på brukerens rolle
            }).ToList();

            return View(userViewModels); // Returner visningen med brukerdataene
        }

        [HttpGet]
        public IActionResult Add(string? email)
        {
            var brukerList = userRepository.GetUsers();
            if (email != null)
            {
                brukerList = new List<UserEntity>()
                    .Where(user => user.Email != null && user.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase))
                    .ToList();
                if (brukerList.Count == 0)
                {
                    // TempData["ErrorMessage"] = "Ingen brukere ble funnet med den gitte e-postadressen.";
                    return RedirectToAction("Add");

                }
            }

            var model = brukerList.Select(user => new UserViewModel
            {
                Id = user.Id,
                Fornavn = user.Fornavn,
                Etternavn = user.Etternavn,
                Email = user.Email,
                IsAdmin = userRepository.IsAdmin(user.Email)
            }).ToList();

            return View("Add", model);

        }

        [HttpPost]
        public IActionResult Save(UserViewModel model)
        {
            // if (ModelState.IsValid)
            //  {
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
            //  }
            // else
            // {
            //      return View(model);
            //    }
        }
        [HttpGet]
        public IActionResult Edit(string email)
        {
            // Hent brukerdetaljer basert på email og vis dem på Edit-siden
            var user = userRepository.GetUserByEmail(email);

            var model = new UsersEditViewModel
            {
                User = new UserViewModel
                {
                    Id = user.Id,
                    Fornavn = user.Fornavn,
                    Etternavn = user.Etternavn,
                    Email = user.Email,
                }
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(UsersEditViewModel model)
        {
            //  if (ModelState.IsValid)
            if( model.User == null )
            {
                return NotFound();
            }
            UserEntity user = new UserEntity
            {
                Id = model.User.Id,
                Fornavn = model.User.Fornavn,
                Etternavn = model.User.Etternavn,
                Email = model.User.Email,

            };
            var roles = new List<string>();
            if (model.User.IsAdmin)
                roles.Add("Administrator");

            userRepository.Update(user, roles);

            return RedirectToAction("Index", "Users");

            // If we got this far, something failed, redisplay form
            // return View(model);
        }


        [HttpPost]
        public IActionResult Delete(string email)
        {
            var user = userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }

            return View(user); // Pass the users to the delete confirmation view
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string email)
        {
            var user = userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
         
            // Perform the deletion of the users
            userRepository.Delete(email);

            return RedirectToAction("Index");
        }

    }
}

