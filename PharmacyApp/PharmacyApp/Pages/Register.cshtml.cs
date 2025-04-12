using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PharmacyApp.Data;
using PharmacyApp.Models;
using Microsoft.AspNetCore.Identity;

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

    public string Message { get; set; } = string.Empty;

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        var hasher = new PasswordHasher<User>();
        var user = new User
        {
            Username = Input.Username,
            Email = Input.Email,
            PasswordHash = hasher.HashPassword(null, Input.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        Message = "User registered successfully!";
        return Page();
    }

    public class RegisterInput
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
