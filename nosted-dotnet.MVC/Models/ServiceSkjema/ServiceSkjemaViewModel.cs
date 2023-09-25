namespace nosted_dotnet.MVC.Models.ServiceSkjema
{
    public class ServiceSkjemaViewModel
    {
        public required string Mechanic { get; set; }
        public bool IsAdministrator { get; set; }
        public required string SerialNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal ConsumedHours { get; set; }
        public required string ImageUrl { get; set; }
        public required string MechanicComment { get; set; }
        public required string CustomerComment { get; set; }

        public required string FutureMaintenance { get; set; }
        public int ServiceSkjemaId { get; set; }

        public required string CustomerName { get; set; }
        public required string CustomerEmail { get; set; }
        public required string CustomerStreet { get; set; }
        public required string CustomerCity { get; set; }
        public required string CustomerZipcode { get; set; }
        public  required string CustomerTelephoneNumber { get; set; }

    }

  
}


