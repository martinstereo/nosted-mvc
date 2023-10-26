//using nosted_dotnet.MVC.Models.CheckList;
//using nosted_dotnet.MVC.Models.ServiceSkjema;
using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models.Ordre
{
    public class OrderFullViewModel
    {
        public OrderFullViewModel()
        {
            UpsertModel = new OrdreViewModel();
            OrdreList = new List<OrdreViewModel>();
        }
        public OrdreViewModel UpsertModel{ get; set; }
        public List<OrdreViewModel> OrdreList { get; set; }

        
    }
    
    
    public class OrdreViewModel
    {
        //ORDRE
        public int OrdreId { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi datoen ordren ble mottatt.")]
        public DateTime ServiceDato { get; set; }
        [Required(ErrorMessage = "Vennligst fyll ut service / rep garanti.")]
        public string ServiceRep { get; set; }
        
        //KUNDE
        public int KundeId { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Fornavn { get; set; }
        
        [Required(ErrorMessage = "Vennligst oppgi kundenavn.")]
        public string Etternavn { get; set; }
        
        [Required(ErrorMessage = "Vennligst oppgi kundetelefonnummer.")]
        [Phone(ErrorMessage = "Ikke et gyldig telefonnummer.")]
        public string TelefonNr { get; set; }
        
        [Required(ErrorMessage = "Vennligst oppgi kunde email.")]
        [EmailAddress(ErrorMessage = "Ikke en gyldig emailadresse.")]
        public string Email { get; set; }
        
        //PRODUKT
        public int ProduktId { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi serienummer.")]
        public string RegNr { get; set; }
        
        [Required(ErrorMessage = "Vennligst oppgi produkttype.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Vennligst oppgi årsmodell.")]
        public string Model { get; set; }
        
        //ADRESSE
        public int AdreseeId { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi Postkode.")]
        public int Postkode { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi Poststed.")]
        public string Poststed { get; set; }
        [Required(ErrorMessage = "Vennligst oppgi Gate.")]
        public string Gate { get; set; }
        
    }
}
    
