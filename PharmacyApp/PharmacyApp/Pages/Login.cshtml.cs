using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmacyApp.Data;
using PharmacyApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApp.Pages;

public class LoginModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public LoginModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public LoginInput Input { get; set; } = new();

    public string Message { get; set; } = string.Empty;

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
        if (user is null)
        {
            Message = "Invalid credentials.";
            return Page();
        }

        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.PasswordHash, Input.Password);

        if (result == PasswordVerificationResult.Success)
        {
            user.LastLogin = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }

        Message = "Invalid credentials.";
        return Page();
    }

    public class LoginInput
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
