using nosted_dotnet.MVC.Entites;
using nosted_dotnet.MVC.Models.Ordre;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Users;

public class UsersEditViewModel
    {
        public UsersEditViewModel()
        {
            UpsertModel = new List<UserEntity>();
        }

        public bool IsAdmin { get; set; }
        public UserViewModel User { get; set; }
        public List<UserEntity> UpsertModel { get; }
        public UserEntity UpdatedUser { get; }
}

