using nosted_dotnet.MVC.Models;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Entities
{
    public class CustomerInformation: IEntity
    {
        public int Id { get; set; }
        public string Kunde { get; set; }
        public string Serienummer { get; set; }
        public DateTime MotattDato { get; set; }
        public string AvtaltMedKunden { get; set; }
        public string KundeMail { get; set; }
        public string KundeAdresse { get; set; }
        public string KundeTelefonNr { get; set; }
        public string Produkttype { get; set; }
        public string Årsmodell { get; set; }
        public string ServiceRep { get; set; }

        public int UserId { get; set; }
        public Order? Order { get; set; }
        public User? User { get; set; }


    }
}
