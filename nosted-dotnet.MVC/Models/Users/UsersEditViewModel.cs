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

        public UserViewModel Id { get; }
        public UserViewModel Fornavn { get; set; }
        public UserViewModel Etternavn { get; set; }
        public UserViewModel Email { get; set; }
        public bool IsAdmin { get; set; }
        public UserViewModel User { get; internal set; }
        public List<UserEntity> UpsertModel { get; }
        public UserEntity UpdatedUser { get; }
}

