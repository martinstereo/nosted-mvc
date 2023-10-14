using bacit_dotnet.MVC.Models.CheckList;
using nosted_dotnet.MVC.Entities;
using nosted_dotnet.MVC.Models.Bruker;
using nosted_dotnet.MVC.Models.ServiceSkjema;

namespace nosted_dotnet.MVC.Mappers
{
    public static class EntityHelpers
    {
        public static User UserMapper(BrukerRad model)
        {
            var user = new User();
            user.Adresse = model.Adresse;
            user.Etternavn = model.Etternavn;
            user.Id = model.Id;

            return user;
        }

        public static CheckList CheckListMapper(CheckListViewModel model)
        {
            var checkList = new CheckList();
            checkList.ConsumedHours = model.ConsumedHours;
            checkList.Mechanic=model.Mechanic;
            checkList.Id=model.Id;
            checkList.CreatedDate=model.CreatedDate;
            checkList.CheckListId=model.CheckListId;
            checkList.CustomerName=model.CustomerName;
            checkList.CustomerEmail=model.CustomerEmail;
            checkList.CustomerStreet=model.CustomerStreet;
            checkList.CustomerStreet=model.CustomerStreet;
            checkList.CustomerCity=model.CustomerCity;
            checkList.CustomerZipcode=model.CustomerZipcode;
            checkList.CustomerTelephoneNumber= model.CustomerTelephoneNumber;
            checkList.CustomerTelephoneNumber=model.CustomerTelephoneNumber;
            checkList.CustomerComment=model.CustomerComment;
            checkList.VinsjType=model.VinsjType;
            checkList.VinsjModel=model.VinsjModel;
            checkList.VinsjType=model.VinsjType;
            checkList.VinsjRegNr=model.VinsjRegNr;
            

            return checkList;
        }

        public static CheckListCategoryGroupModel CheckListCategoryGroupMapper(CheckListCategoryGroupModel model)
        {

            var checkListCategoryGroup = new CheckListCategoryGroupModel();
            checkListCategoryGroup.Name = model.Name;
            checkListCategoryGroup.Jobs = model.Jobs;
            return checkListCategoryGroup;
        }


        public static CustomerInformation CustomerInformationMapper(CustomerInformation model)
        {
            var customer = new CustomerInformation();
            customer.Id=model.Id;
            customer.Kunde=model.Kunde;
            customer.Serienummer=model.Serienummer;
            customer.MotattDato=model.MotattDato;
            customer.AvtaltMedKunden=model.AvtaltMedKunden;
            customer.KundeMail=model.KundeMail;
            customer.KundeAdresse=model.KundeAdresse;
            customer.KundeTelefonNr= model.KundeTelefonNr;
            customer.Produkttype=model.Produkttype;
            customer.Årsmodell = model.Årsmodell;
            customer.ServiceRep=model.ServiceRep;
            customer.UserId=model.UserId;
            customer.Order=model.Order;
            customer.User=model.User;
            return customer;

        }

        public static Order OrderMapper(Order model)
        {
            var order= new Order();
            order.Id= model.Id;
            order.DateReceived=model.DateReceived;
            order.ProductType=model.ProductType;
            order.TargetDate=model.TargetDate;
            order.IsDone=model.IsDone;
            order.UserId=model.UserId;
            order.ServiceSchema=model.ServiceSchema;
            order.CustomerInformation=model.CustomerInformation;
            order.User=model.User;
            return order;

        }

        public static ServiceSchema ServiceSchemaMapper(ServiceSkjemaViewModel model)
        {
            var serviceSchema= new ServiceSchema();
            serviceSchema.Id= model.Id;
            serviceSchema.RepBeskrivelse=model.RepBeskrivelse;
            serviceSchema.MedgåtteDeler=model.MedgåtteDeler;
            serviceSchema.FerdigDato=model.FerdigDato;
            serviceSchema.UtskiftetDelerRetur=model.UtskiftetDelerRetur;
            serviceSchema.ForsendelsesMåte=model.ForsendelsesMåte;
            serviceSchema.SignaturRep=model.SignaturRep;
            serviceSchema.UserId = model.UserId;
            serviceSchema.CheckList = model.CheckList;
            serviceSchema.Order = model.Order;
            serviceSchema.User = model.User;
            return serviceSchema;

        }



    }
}
