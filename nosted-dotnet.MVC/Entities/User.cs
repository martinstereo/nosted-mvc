using nosted_dotnet.MVC.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace nosted_dotnet.MVC.Entities;

[Table("Users")]
public class UserEntity
{
    public int Id { get; set; }
    public string Navn { get; set; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }
}