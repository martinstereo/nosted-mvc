using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data
{
    public interface IUserRepository
    {
        void Update(UserEntity user, List<string> roles);
        void Add(UserEntity user);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
    }
}
