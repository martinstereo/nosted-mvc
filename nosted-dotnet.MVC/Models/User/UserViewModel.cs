namespace nosted_dotnet.MVC.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Navn { get; set; }
        public string? Etternavn { get; set; }
        public string? Adresse { get; set; } 
        public string? Telefonnummer { get; set; }
        public StillingType? Stilling { get; set; }
    }

    public enum StillingType
    {
        None,
        Kundesenter,
        Administrator,
        Mekaniker
    }
}