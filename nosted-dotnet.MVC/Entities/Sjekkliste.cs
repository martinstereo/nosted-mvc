namespace nosted_dotnet.MVC.Entities;

public class Sjekkliste
{
    public int Id { get; set; }
    public float TrykkSetting { get; set; }
    public string FunksjonsTestKommentar { get; set; }
    public float TrekKraft { get; set; }
    public float BremseKraft { get; set; }
    
    //public virtual ICollection<UtførtSjekk> UtførteSjekker { get; set; }
    
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
    
    public virtual Ordre Ordre { get; set; }
    public int OrdreId { get; set; }
}
