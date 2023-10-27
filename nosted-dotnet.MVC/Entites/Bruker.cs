using nosted_dotnet.MVC.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entites;

[Table("Bruker")]
public class BrukerEntity
{
    public int Id { get; set; }
    public string? Fornavn { get; set; }
    public string? Etternavn { get; set; }
    public string? Email { get; set; }
    public string? Stilling { get; set; }
}