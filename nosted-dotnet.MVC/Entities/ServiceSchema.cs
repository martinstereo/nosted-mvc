using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Entities;

public class ServiceSchema : IEntity
{
    public int Id { get; set; }

    public string Kunde { get; set; }

    public string Serienummer { get; set; }

    public DateTime MotattDato { get; set; }

    public decimal Arbeidstimer { get; set; }

    public string AvtaltMedKunden { get; set; }

    public string RepBeskrivelse { get; set; }

    public string MedgåtteDeler { get; set; }

    public string OrdreNummer { get; set; }

    public string KundeMail { get; set; }

    public string KundeAdresse { get; set; }

    public string KundeTelefonNr { get; set; }

    public string Produkttype { get; set; }

    public string Årsmodell { get; set; }

    public string ServiceRep { get; set; }

    public DateTime FerdigDato { get; set; }

    public string UtskiftetDelerRetur { get; set; }

    public string ForsendelsesMåte { get; set; }

    public string SignaturKunde { get; set; }

    public string SignaturRep { get; set; }

    public int UserId { get; set; }

    public CheckList? CheckList { get; set; }

    public Order? Order { get; set; }

    public User? User { get; set; }
}