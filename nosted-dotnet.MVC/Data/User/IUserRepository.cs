using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data
{
    public interface IUserRepository
    {
        void Update(UserEntity user, List<string> roles);
        void Add(UserEntity user);
        List<UserEntity> GetUsers();
        void Delete(string email);
        bool IsAdmin(string email);
        UserEntity GetUserByEmail(string email);

    }
}
