using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Bruker;

namespace nosted_dotnet.MVC.Mappers
{
    public static class EntityHelpers
    {
        public static User UserMapper(BrukerRad model)
        {
            var user = new User();
            user.Adresse = model.Adresse;
            user.Etternavn = model.Etternavn;

            return user;
        }

        public static CheckList CheckListMapper(CheckListViewModel model)
        {
            var checkList = new CheckList();
            checkList.ConsumedHours = model.ConsumedHours;

            return checkList;
        }


    }
}
