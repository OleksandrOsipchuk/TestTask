using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask.Repository;

public class FolderRepository : IFolderRepository
{
    private FolderContext _context;

    public FolderRepository(FolderContext context)
    {
        _context = context;
    }

    public async Task<Folder> GetFolder(string name,int parentId)
    {
        return await _context.Folders.FirstAsync(f => f.Name == name && f.ParentId==parentId);
    }

    public async Task<List<Folder>> GetChildFolders(int id)
    {
        IQueryable<Folder> data = _context.Folders;
        var children = await data.Where(f => f.ParentId == id).ToListAsync();
        return children;
    }
}