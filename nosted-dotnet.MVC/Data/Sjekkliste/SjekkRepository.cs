using nosted_dotnet.MVC.Entities;

namespace nosted_dotnet.MVC.Data;

public class SjekkRepository : ISjekkRepository
{
    private readonly DataContext _dataContext;

    public SjekkRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public List<Sjekk> HentAlle()
    {
        return _dataContext.Sjekk.ToList();
    }
}