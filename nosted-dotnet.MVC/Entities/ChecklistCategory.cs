using nosted_dotnet.MVC.Models;

namespace nosted_dotnet.MVC.Entities;

public class ChecklistCategory : IEntity
{
    public int Id { get; set; }
    public string GroupName { get; set; }
    public int CheckListId { get; set; }

    public string Name { get; set; }

    public CategoryType CategoryType { get; set; }

    public CheckList CheckList { get; set; }

    // todo : delete this one 
    //public ChecklistCategory()
    //{
    //    var a = new ChecklistCategory
    //    {
    //        Id = 1,
    //        GroupName = "Mekanik",
    //        CategoryType = CategoryType.Ok,
    //        CheckListId = 1,
    //        Name = "Clucth"
    //    };

    //    var b = new ChecklistCategory
    //    {
    //        Id = 1,
    //        GroupName = "Mekanik",
    //        CategoryType = CategoryType.Defekt,
    //        CheckListId = 1,
    //        Name = "Bremser"
    //    };
    //}
}