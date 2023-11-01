namespace nosted_dotnet.MVC.Models.Sjekkliste
{
    public class SjekklisteViewModel
    {
        /*public string Mechanic { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal ConsumedHours { get; set; }*/
        
        

        public int Id { get; set; } 
        public int OrdreId { get; set; }
        //public List<SjekklisteCategoryGroupModel> CategoryGroups { get; set; }
        public string ClutchLameller { get; set; }
        public string BremserBP { get; set; }
        public string TrommelLager { get; set; }
        public string Kjedestrammer { get; set; }
        public string Wire { get; set; }
        public string PinionLager { get; set; }
        public string KjedehjulKile { get; set; }
    
        public string SylinderLekasje { get; set; }
        public string Slanger { get; set; }
        public string HydraulikkblokkTest { get; set; }
        public string OljeskifteTank { get; set; }
        public string OljeskifteGirboks { get; set; }
        public string RingsylinderTetninger { get; set; }
        public string BremsesylinderTetninger { get; set; }

        public string Ledningsnett { get; set; }
        public string Radio { get; set; }
        public string Knappekasse { get; set; }

        //public string CustomerName { get; set; }
        //public string CustomerEmail { get; set; }
        //public string CustomerStreet { get; set; }
        //public string CustomerCity { get; set; }
        //public string CustomerZipcode { get; set; }
        //public string CustomerTelephoneNumber { get; set; }
        //public string CustomerComment { get; set; }
        
        //public string VinsjType { get; set; }
        //public string VinsjModel { get; set; }
        //public string VinsjRegNr { get; set; }
		public float TrykkSetting { get; set; }
        //public string FunksjonsTestKommentar { get; set; }
        public float TrekKraft { get; set; }
        public float BremseKraft { get; set; }
        public string Resultat { get; set; }
       public string MechanicComment { get; set; }

    }

    /*public class SjekklisteCategoryGroupModel
    {
        public string Name { get; set; }

        public List<string> Jobs { get; set; }
    }*/

}