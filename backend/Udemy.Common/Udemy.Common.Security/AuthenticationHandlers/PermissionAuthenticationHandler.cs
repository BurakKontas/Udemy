using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Udemy.Common.Security.PermissionAuthorizeAttribute;

namespace Udemy.Common.Security.AuthenticationHandlers;

public class PermissionAuthenticationHandler(
    IOptionsMonitor<AuthenticationSchemeOptions> options,
    ILoggerFactory logger,
    UrlEncoder encoder)
    : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder)
{
    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        //TimeProvider.LocalTimeZone;
        var identity = new ClaimsIdentity();
        var principal = new ClaimsPrincipal(identity);
        var permissions = new List<Claim>
        {
            new("Permission", Permissions.Read.ToString()),
            new("Permission", Permissions.Create.ToString())
        };
        identity.AddClaims(permissions);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return Task.FromResult(AuthenticateResult.Success(ticket));
    }
}