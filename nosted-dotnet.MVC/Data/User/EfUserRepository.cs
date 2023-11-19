using Microsoft.AspNetCore.Identity;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data.User
{
    public class EfUserRepository : UserRepositoryBase, IUserRepository
    {
        private readonly DataContext dataContext;

        public EfUserRepository(DataContext dataContext, UserManager<IdentityUser> userManager) : base(userManager)
        {
            this.dataContext = dataContext;
        }

        public void Delete(string email)
        {
            UserEntity? user = GetUserByEmail(email);
            if (user == null)
                return;
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
        }

        public UserEntity? GetUserByEmail(string email)
        {
            return dataContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public List<UserEntity> GetUsers()
        {
            return dataContext.Users.ToList();
        }

        public void Add(UserEntity user)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists found");
            }
            dataContext.Users.Add(user);
            dataContext.SaveChanges();
        }
        public void Update(UserEntity user, List<string> roles)
        {
            var existingUser = GetUserByEmail(user.Email);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.Email = user.Email;
            existingUser.Navn = user.Navn;
            dataContext.SaveChanges();
          //  SetRoles(user.Email, roles);
        }

    }
}
