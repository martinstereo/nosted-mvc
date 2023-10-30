using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data;
using nosted_dotnet.MVC.Entites;
using nosted_dotnet.MVC.Models.Users;

namespace nosted_dotnet.MVC.Controllers
{
    public class BrukerController : Controller
    {
        private readonly IUserRepository brukerRepository;

        public BrukerController(IUserRepository brukerRepository)
        {
            this.brukerRepository = brukerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserViewModel model)
        {
            UserEntity newUser = new UserEntity
            {
                Fornavn = model.Fornavn,
                Etternavn = model.Etternavn,
                Email = model.Email,
            };
            var roles = new List<string>();
            if (model.Stilling == "Mekaniker")
                roles.Add("Mekaniker");
            else if (model.Stilling == "")
                roles.Add("Mekaniker");

            // Redirect back to the index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int brukerId)
        {
            // Find and remove the user with the specified ID
            var userToRemove = BrukerDataTable.FirstOrDefault(user => user.BrukerID == brukerId);
            if (userToRemove != null)
            {
                BrukerDataTable.Remove(userToRemove);
            }

            // Redirect back to the index page
            return RedirectToAction("Index");
        }

        // Helper method to generate a unique ID (you can implement your own logic)
        //private int GenerateUniqueId()
        //{
        // Random random = new Random();
        //int uniqueId;
        //   do
        //   {
        // uniqueId = random.Next(1000, 9999); // Modify the range as needed
        // } while (BrukerDataTable.Any(user => user.BrukerID == uniqueId));
        //     return uniqueId;
        //  }


        [HttpPost]
        public IActionResult EditUser(BrukerRad editedUser)
        {
            // Find the user in the list by BrukerID
            var existingUser = BrukerDataTable.FirstOrDefault(user => user.BrukerID == editedUser.BrukerID);

            if (existingUser != null)
            {
                // Update the user information
                existingUser.Navn = editedUser.Navn;
                existingUser.Etternavn = editedUser.Etternavn;
                existingUser.Adresse = editedUser.Adresse;
                existingUser.Telefonnummer = editedUser.Telefonnummer;
                existingUser.Stilling = editedUser.Stilling;
            }

            // Redirect back to the index page
            return RedirectToAction("Index");
        }

    }
}
