using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data; // Make sure this is here

var builder = WebApplication.CreateBuilder(args);

// Register Razor Pages and ApplicationDbContext
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
