using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using nosted_dotnet.MVC.Mappers;
using nosted_dotnet.MVC.Models.User;
using System.Text.Encodings.Web;
using System.Reflection;

namespace nosted_dotnet.MVC.Controllers
{
    public class UserController : Controller
    {
        private static List<UserViewModel> UserDataTable = new List<UserViewModel>();
        private readonly HtmlEncoder _htmlEncoder;

        public UserController(HtmlEncoder htmlEncoder)
        {
            _htmlEncoder = htmlEncoder;
        }

        public IActionResult Index()
        {
            // Gå gjennom brukerdata og krypter tekstfelt før visning
            foreach (var user in UserDataTable)
            {
                PropertyInfo[] properties = user.GetType().GetProperties();

                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        var value = (string)property.GetValue(user);
                        if (value != null)
                        {
                            property.SetValue(user, _htmlEncoder.Encode(value));
                        }
                    }
                }
            }

            return View(UserDataTable);
        }

        [HttpPost]
        public IActionResult AddRow(UserViewModel row)
        {
            // Gå gjennom alle offentlige egenskaper i UserViewModel og utfør HTML encoding på strengverdiene
            PropertyInfo[] properties = row.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = (string)property.GetValue(row);
                    if (value != null)
                    {
                        property.SetValue(row, _htmlEncoder.Encode(value));
                    }
                }
            }

            UserDataTable.Add(row);

            // Redirect tilbake til index-siden
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            // Implementer HTML encoding etter behov

            // Find and remove the user with the specified ID
            var userToRemove = UserDataTable.FirstOrDefault(user => user.Id == userId);
            if (userToRemove != null)
            {
                UserDataTable.Remove(userToRemove);
            }

            // Redirect tilbake til index-siden
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditUser(UserViewModel editedUser)
        {
            // Utfør HTML encoding på inndataene før oppdatering
            PropertyInfo[] properties = editedUser.GetType().GetProperties();

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var value = (string)property.GetValue(editedUser);
                    if (value != null)
                    {
                        property.SetValue(editedUser, _htmlEncoder.Encode(value));
                    }
                }
            }

            // Redirect tilbake til index-siden
            return RedirectToAction("Index");
        }
    }
}
