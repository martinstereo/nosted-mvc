using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.LoggIn;

public class LoginViewModel
{
    [Required(ErrorMessage = "Vennligst skriv inn brukernavn.")]
    public string Brukernavn { get; set; }

    [Required(ErrorMessage = "Vennligst skriv inn passord.")]
    [DataType(DataType.Password)]

    public string Passord { get; set; }
}
