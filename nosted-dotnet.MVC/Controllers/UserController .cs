using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Mappers;
using nosted_dotnet.MVC.Models.User;
using System.Text.Encodings.Web;
using System.Reflection;
using nosted_dotnet.MVC.Repositories;

namespace nosted_dotnet.MVC.Controllers
{
    public class UserController : Controller
    {
        private static List<UserViewModel> UserDataTable = new List<UserViewModel>();
        private readonly HtmlEncoder _htmlEncoder;
        private readonly IUserRepository _userRepository;

        public UserController(HtmlEncoder htmlEncoder, IUserRepository userRepository)
        {
            _htmlEncoder = htmlEncoder;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            UserDataTable.Clear();
            var users = await _userRepository.GetAllUsers();

            foreach (var user in users)
            {
                var userDataTableItem = EntityHelpers.UserViewModeMapper(user);

                UserDataTable.Add(userDataTableItem);
            }

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
        public async Task<IActionResult> AddRow(UserViewModel row)
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

            //UserDataTable.Add(row);

            var userRecord = EntityHelpers.UserMapper(row);
            var savedUser = await _userRepository.AddUser(userRecord);
            var saveUserViewModel = EntityHelpers.UserViewModeMapper(savedUser);
            UserDataTable.Add(saveUserViewModel);

            // Redirect tilbake til index-siden
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int userId)
        {

            //var user = await _userRepository.GetUserById(userId);

            //if (user != null)
            //{
            //    await _userRepository.DeleteUser(user.Id);
            //}

            // Implementer HTML encoding etter behov

            // Find and remove the user with the specified ID
            var userToRemove = UserDataTable.FirstOrDefault(user => user.Id == userId);
            if (userToRemove != null)
            {
                await _userRepository.DeleteUser(userId);
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
