using DataAccess;
using Microsoft.EntityFrameworkCore;
using RecipeVault.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//ConfigurationManager configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("RecipeDatabase");
builder.Services.AddDbContext<DataContext>(options =>
 options.UseSqlite(connectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IMainDataAccess, MainDataAccess>();

var app = builder.Build();

IConfiguration configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();

