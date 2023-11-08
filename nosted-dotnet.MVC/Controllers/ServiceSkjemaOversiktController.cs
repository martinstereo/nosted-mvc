using Microsoft.AspNetCore.Mvc;
using nosted_dotnet.MVC.Data.ServiceSkjema;
using nosted_dotnet.MVC.Models.ServiceSkjema; 

namespace nosted_dotnet.MVC.Controllers;


public class ServiceSkjemaOversiktController : Controller
{
    private readonly IServiceSkjemaRepository _serviceSkjemaRepository;

    public ServiceSkjemaOversiktController(IServiceSkjemaRepository serviceSkjemaRepository)
    {
        _serviceSkjemaRepository = serviceSkjemaRepository;
    }
    
    public IActionResult Index()
    {
        // Retrieve a list of service schemas from the repository
        var serviceSkjema = _serviceSkjemaRepository.GetAllServiceSchemas();

        // You can pass this list to a view to display the overview
        return View(serviceSkjema);
    }
}