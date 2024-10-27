using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Dasher.Auth
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly IJSRuntime _js;
        public CustomAuthStateProvider(IJSRuntime js)
        {
            _js = js;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _js.InvokeAsync<string>("localStorage.getItem", "authToken");
            ClaimsIdentity identity;

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                var isEmployee = jwtToken.Claims.FirstOrDefault(c => c.Type == "Employee")?.Value == "True";
                var isEmployer = jwtToken.Claims.FirstOrDefault(c => c.Type == "Employer")?.Value == "True";

                string role = isEmployee ? "Employee" : isEmployer ? "Employer" : string.Empty;

                identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "User"),
                new Claim(ClaimTypes.Role, role)
                }, "authToken");
            }
            else
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            await _js.InvokeVoidAsync("localStorage.setItem", "authToken", token);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", "authToken");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
