using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int userId);

        Task<User?> GetUserById(int id);

        Task<List<User>> GetAllUsers();
    };

    public class UserRepository : IUserRepository
    {
        private readonly NostedDbContext _context;

        public UserRepository(NostedDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
            
            return user;
        }

        public async Task UpdateUser(User user)
        {
            var entity = _context.Users.Single(w => w.Id == user.Id);

            entity.Etternavn = user.Etternavn;
            entity.Adresse = user.Adresse;
            entity.Navn = user.Navn;
            entity.Stilling = user.Stilling;
            entity.Telefonnummer = user.Telefonnummer;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int userId)
        {
            await _context.Users.Where(w => w.Id == userId).ExecuteDeleteAsync();

            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}