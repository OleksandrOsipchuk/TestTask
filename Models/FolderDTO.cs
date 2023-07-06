namespace TestTask.Models;

public class FolderDTO
{
    public string Name { get; set; }
    public IList<Child> Children { get; set; } = new List<Child>();
}