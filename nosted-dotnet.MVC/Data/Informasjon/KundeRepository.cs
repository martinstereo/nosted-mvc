using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class KundeRepository : IKundeRepository
{
    private readonly DataContext _dataContext;

    public KundeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}