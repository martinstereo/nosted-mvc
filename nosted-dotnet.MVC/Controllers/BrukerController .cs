﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using nosted_dotnet.MVC.Mappers;
using nosted_dotnet.MVC.Models.Bruker;

namespace nosted_dotnet.MVC.Controllers
{
    public class BrukerController : Controller
    {
        private static List<BrukerRad> BrukerDataTable = new List<BrukerRad>();

        public IActionResult Index()
        {
            return View(BrukerDataTable);
        }

        [HttpPost]
        public IActionResult AddRow(BrukerRad row)
        {
            // Add the submitted row to the table
            //  row.BrukerID = GenerateUniqueId(); // Generate a unique ID
            BrukerDataTable.Add(row);



            //var user = EntityHelpers.UserMapper(row);
            // dbContext.Users.Add(user);
            // dbContext.SaveChanges();

            // Redirect back to the index page
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int brukerId)
        {
            // Find and remove the user with the specified ID
            var userToRemove = BrukerDataTable.FirstOrDefault(user => user.Id == brukerId);
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
            var existingUser = BrukerDataTable.FirstOrDefault(user => user.Id == editedUser.Id);

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
