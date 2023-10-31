
using nosted_dotnet.MVC.Entites;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Users
{


    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
    
