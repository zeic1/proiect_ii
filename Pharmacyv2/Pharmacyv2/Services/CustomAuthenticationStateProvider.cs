using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.JSInterop;

namespace PharmacyManagement.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _jsRuntime;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var token = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

                if (string.IsNullOrEmpty(token))
                {
                    return new AuthenticationState(_anonymous);
                }

                var userData = JsonSerializer.Deserialize<UserData>(token);
                if (userData == null)
                {
                    return new AuthenticationState(_anonymous);
                }

                // Check token expiry
                if (DateTime.Parse(userData.ExpiresAt) < DateTime.Now)
                {
                    await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", "authToken");
                    return new AuthenticationState(_anonymous);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userData.Name),
                    new Claim(ClaimTypes.NameIdentifier, userData.Id),
                    new Claim("Role", userData.Role)
                };

                var identity = new ClaimsIdentity(claims, "Custom Authentication");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch
            {
                return new AuthenticationState(_anonymous);
            }
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private class UserData
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Role { get; set; }
            public string ExpiresAt { get; set; }
        }
    }
}