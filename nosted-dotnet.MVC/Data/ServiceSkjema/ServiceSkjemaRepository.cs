using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class ServiceSkjemaRepository : IServiceSkjemaRepository
{
    private readonly DataContext _dataContext;

    public ServiceSkjemaRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}