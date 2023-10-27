using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class BrukerRepository : IBrukerRepository
{
    private readonly DataContext _dataContext;

    public BrukerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}