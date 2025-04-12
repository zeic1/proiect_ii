using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// ✅ Add Authentication with Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";     // Redirect if not logged in
        options.LogoutPath = "/Logout";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
    });

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// ✅ Enable Authentication and Authorization Middleware
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.Run();
