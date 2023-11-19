
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Users
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Navn på bruker")]
        public string Navn { get; set; }
        [Required]
        [Display(Name = "Email på bruker")]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}


