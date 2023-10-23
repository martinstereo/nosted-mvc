using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class AdresseRepository : IAdresseRepository
{
    private readonly DataContext _dataContext;

    public AdresseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}