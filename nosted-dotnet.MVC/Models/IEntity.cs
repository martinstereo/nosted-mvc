using System.ComponentModel.DataAnnotations;

namespace nosted_dotnet.MVC.Models
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
