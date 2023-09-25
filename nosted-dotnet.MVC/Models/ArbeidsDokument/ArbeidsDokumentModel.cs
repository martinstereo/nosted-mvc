using System.Net.Http.Headers;

namespace nosted_dotnet.MVC.Models.ArbeidsDokument
{
    public class ArbeidsDokumentModel
    {
        public required int WeekBookedService { get; set; }
        public DateTime DateRecieved { get; set; }
        public bool IsCaseDone { get; set; }
        public string? ProductType { get; set; }
        public required string OrderFromCustomer { get; set; }
        // Kundeinfo, navn, adr,
        public required string CustomerFirstName { get; set; }
        public required string CustomerLastName { get; set; }
        public required string CustomerAdress { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerPhone { get; set; }
        public DateTime DateAgreedDelivery { get; set; }
        public DateTime DateRecievedProduct { get; set; }
        public DateTime WithinDateCompletion { get; set; }
        public DateTime DateCompletion { get; set; }
        public required int NumberOfHoursForService { get; set; }
        public required int OrderNumber { get; set; }
        public string? ServiceForm { get; set; } // HTML link til service-skjema
    }
}
    
