using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entities
{
    [Table("Ordre")]
    public class Ordre
    {
        public int Id { get; set; }

        //public string Status { get; set; }
        //public DateTime Opprettet { get; set; }
        public DateTime ServiceDato { get; set; }
        public string ServiceRep{ get; set; }
        
       

        public virtual Kunde Kunde { get; set; }
        public int KundeId { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int ProduktId { get; set; }

        /*public virtual ServiceSkjema ServiceSkjema { get; set; }
        public int ServiceSkjemaId { get; set; }
        public virtual Sjekkliste Sjekkliste { get; set; }
        public int SjekklisteId { get; set; }*/

    }
}