using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Mappers;

namespace nosted_dotnet.MVC.Controllers
{
    public class CheckListController : Controller
    {
        public IActionResult Index()
        {
            var model = new CheckListViewModel
            {
                CategoryGroups = new List<CheckListCategoryGroupModel> {
                    new CheckListCategoryGroupModel {Name ="Mekanisk", Jobs=new List<string>{"Clutch Lameller", "Bremser|Bånd|Pal","Trommel Lager","Kjedestrammer","Wire", "Pinion Lager","Kjedehjul Kile"} },
                    new CheckListCategoryGroupModel{ Name="Hydraulisk", Jobs=new List<string>{"Sylinder Lekasje","Slanger","Hydraulikkblokk Test","Oljeskifte på Tank","Oljeskifte på Girboks","Ringsylinder | Skift Tetninger","Bremsesylinder | Skift Tetninger" } },
                    new CheckListCategoryGroupModel{ Name="Elektrisk", Jobs=new List<string>{"Ledningsnett","Radio", "Knappekasse" } },
                },
                CheckListId = 1
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CheckListViewModel model)
        {
            //Create a way to Request from list instead of singel iteam in list
            var test = HttpContext.Request.Form["Ledningsnett"];
            var testComment = HttpContext.Request.Form["MechanicComment"];
            if (!ModelState.IsValid)
            {
                //Does not redirect to anything. Define where it should redirect.
                return BadRequest("Not a valid model");
            }

            // Access the form data via the model object
            int checkListId = model.CheckListId;
            string comment = model.MechanicComment;

            // Log the form data
            Debug.WriteLine($"CheckListId: {checkListId}");
            Debug.WriteLine($"Comment: {comment}");



            var entity = EntityHelpers.CheckListMapper(model);
            // dbcontext.Checklists.Add(entitiy);
            // save



            // Redirect to a confirmation page or back to the form page after handling the data.
            return RedirectToAction("Index");
        }
    }
}

//ConsumedHours = 0,
//CreatedDate = new DateTime(2023, 9, 7),
//CustomerCity = "Kristiansand",
//CustomerComment = "Hei og hå, jeg er en kundekommentar",
//CustomerEmail = "customer@thesystem.no",
//CustomerName = "Sattosk Rev",
//CustomerStreet = "Gata 13",
//CustomerTelephoneNumber = "1337",
//CustomerZipcode = "1234",

//Mechanic = "Espen",
//MechanicComment = "ingen kommentar",
//SerialNumber = "pirepioj123åojå",