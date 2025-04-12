using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmacyApp.Models;
using PharmacyApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace PharmacyApp.Pages;

public class RegisterModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public RegisterModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public RegisterInput Input { get; set; } = new();

    public string Message { get; set; } = "";

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        // Check if user already exists
        if (await _context.Users.AnyAsync(u => u.Email == Input.Email))
        {
            Message = "Email is already registered.";
            return Page();
        }

        var user = new User
        {
            Username = Input.Username,
            Email = Input.Email,
            PasswordHash = new PasswordHasher<User>().HashPassword(null, Input.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        Message = "Registration successful!";
        return RedirectToPage("/Login");
    }

    public class RegisterInput
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
