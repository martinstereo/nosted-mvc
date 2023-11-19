
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Users
{
    public class UserViewModel
    {
        public string Navn { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}


