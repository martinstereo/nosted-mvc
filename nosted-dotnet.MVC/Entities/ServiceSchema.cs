using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Entities;

public class ServiceSchema : IEntity
{
    public int Id { get; set; }

    public string RepBeskrivelse { get; set; }

    public string MedgåtteDeler { get; set; }

    public DateTime FerdigDato { get; set; }

    public string UtskiftetDelerRetur { get; set; }

    public string ForsendelsesMåte { get; set; }

    public string SignaturRep { get; set; }

    public int UserId { get; set; }

    public CheckList? CheckList { get; set; }

    public Order? Order { get; set; }

    public User? User { get; set; }
}