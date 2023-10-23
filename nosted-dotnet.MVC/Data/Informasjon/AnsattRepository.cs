using nosted_dotnet.MVC.Entites;

namespace nosted_dotnet.MVC.Data;

public class AnsattRepository : IAnsattRepository
{
    private readonly DataContext _dataContext;

    public AnsattRepository(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
}