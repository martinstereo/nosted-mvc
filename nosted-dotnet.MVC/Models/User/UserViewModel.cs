
using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Models.Users
{


    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}
    
