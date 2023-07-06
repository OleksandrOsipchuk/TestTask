using Microsoft.EntityFrameworkCore;
using TestTask.Models;

namespace TestTask;

public class FolderContext : DbContext
{
    public DbSet<Folder> Folders { get; set; }

    public FolderContext(DbContextOptions<FolderContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>().HasData(
            new Folder { Id = 1, Name = "Creating Digital Images", ParentId = 0},
            new Folder { Id = 2, Name = "Resources", ParentId = 1 },
            new Folder { Id = 3, Name = "Evidence", ParentId = 1 },
            new Folder { Id = 4, Name = "Graphic Products", ParentId = 1 },
            new Folder { Id = 5, Name = "Primary Sources", ParentId = 2 },
            new Folder { Id = 6, Name = "Secondary Sources", ParentId = 2 },
            new Folder { Id = 7, Name = "Process", ParentId = 4 },
            new Folder { Id = 8, Name = "Final Product", ParentId = 4 });
    }
}