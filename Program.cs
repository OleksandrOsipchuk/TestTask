using Microsoft.EntityFrameworkCore;
using TestTask;
using TestTask.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FolderContext>(options => 
    options.UseNpgsql(connection));
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.MapGet("/",async (context) =>
{
    context.Response.Redirect("/Creating Digital Images/0");
});
app.MapRazorPages();
app.MapControllers();
app.Run();