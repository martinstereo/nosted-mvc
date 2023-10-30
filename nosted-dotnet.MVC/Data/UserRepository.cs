using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}