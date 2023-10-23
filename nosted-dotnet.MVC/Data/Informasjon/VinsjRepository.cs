using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class VinsjRepository : IVinsjRepository
{
    private readonly DataContext _dataContext;

    public VinsjRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}