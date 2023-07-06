using TestTask.Models;

namespace TestTask.Repository;

public interface IFolderRepository
{
    Task<Folder> GetFolder(string name,int parentId);
    Task<List<Folder>> GetChildFolders(int id);
}