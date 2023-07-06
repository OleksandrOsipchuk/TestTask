using Microsoft.AspNetCore.Mvc;
using TestTask.Models;
using TestTask.Repository;

namespace TestTask.Controllers;

[Route("/")]
public class FolderController:Controller
{
    private readonly IFolderRepository _repository;
    public FolderController(IFolderRepository repository)
    {
        _repository = repository;
    }
    [HttpGet("{name}/{parentId}")]
    public async Task<IActionResult> Index(string name,int parentId)
    {
        var folderDto = new FolderDTO{Name = name};
        var folder = await _repository.GetFolder(name,parentId);
        var children = await _repository.GetChildFolders(folder.Id);
        foreach (var child in  children)
        {
            folderDto.Children.Add(new Child{Name = child.Name, Path = $"/{child.Name}/{child.ParentId}"});
        }

        return View(folderDto);
    }
}