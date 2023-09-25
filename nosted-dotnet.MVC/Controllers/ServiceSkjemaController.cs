using nosted_dotnet.MVC.Models.ServiceSkjema;
using Microsoft.AspNetCore.Mvc;


namespace nosted_dotnet.MVC.Controllers
{
	public class ServiceSkjemaController : Controller
	{
		public IActionResult Index(ServiceSkjemaViewModel viewModel)
		{
            var serviceData = new ServiceSkjemaViewModel
            {
                Mechanic = viewModel.Mechanic,
                IsAdministrator = viewModel.IsAdministrator,
                SerialNumber = viewModel.SerialNumber,
                CreatedDate = viewModel.CreatedDate,
                ConsumedHours = viewModel.ConsumedHours,
                ImageUrl = viewModel.ImageUrl,
                MechanicComment = viewModel.MechanicComment,
                CustomerComment = viewModel.CustomerComment,
                FutureMaintenance = viewModel.FutureMaintenance,
                CustomerName = viewModel.CustomerName,
                CustomerEmail = viewModel.CustomerEmail,
                CustomerStreet = viewModel.CustomerStreet,
                CustomerCity = viewModel.CustomerCity,
                CustomerZipcode = viewModel.CustomerZipcode,
                CustomerTelephoneNumber = viewModel.CustomerTelephoneNumber
            };
            return View(viewModel);
        }

       
    }
}




