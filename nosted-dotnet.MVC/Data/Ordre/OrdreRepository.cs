using Microsoft.EntityFrameworkCore;
using nosted_dotnet.MVC.Data.Ordre;
using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class OrdreRepository : IOrdreRepository
{
    private readonly DataContext _dataContext;

    public OrdreRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public List<Entites.Ordre> HentAlle()
    {
        return _dataContext.Ordre
            .Include(x => x.Kunde)
            .Include(x => x.Vinsj)
            .ToList();
    }

    public int Opprett(Entites.Ordre ordre)
    {
        _dataContext.Ordre.Add(ordre);
        return _dataContext.SaveChanges();
    }
}