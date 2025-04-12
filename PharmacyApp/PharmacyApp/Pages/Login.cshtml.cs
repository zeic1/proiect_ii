using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmacyApp.Models;
using PharmacyApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApp.Pages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

public class LoginModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public LoginModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public LoginInput Input { get; set; } = new();

    public string Message { get; set; } = "";

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
        if (user == null)
        {
            Message = "Invalid credentials.";
            return Page();
        }

        var result = new PasswordHasher<User>()
            .VerifyHashedPassword(user, user.PasswordHash, Input.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            Message = "Invalid credentials.";
            return Page();
        }

        var claims = new List<Claim>
{
    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.Email, user.Email)
};

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return RedirectToPage("/Index");
    }

    public class LoginInput
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
