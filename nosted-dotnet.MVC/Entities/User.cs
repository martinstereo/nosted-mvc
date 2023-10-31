using nosted_dotnet.MVC.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entites;

[Table("Users")]
public class UserEntity
{
    public int Id { get; set; }
    public string? Fornavn { get; set; }
    public string? Etternavn { get; set; }
    public string Email { get; set; }
}