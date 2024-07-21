using System.Security.Claims;
using JobSeekerAssistant.Domain.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAssistant.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    [HttpPost("logout")]
    [Authorize]
    public async Task<IResult> LogoutAsync(SignInManager<User> signInManager, [FromBody] object empty)
    {
        if (empty is null)
            return Results.Unauthorized();

        await signInManager.SignOutAsync();

        return Results.Ok();

    }

    [HttpGet("roles")]
    [Authorize]
    public async Task<IResult> GetRolesAsync()
    {
        var user = HttpContext.User;
        if (user.Identity is not null && user.Identity.IsAuthenticated)
        {
            var identity = (ClaimsIdentity)user.Identity;
            var roles = identity.FindAll(identity.RoleClaimType)
                .Select(c =>
                    new
                    {
                        c.Issuer,
                        c.OriginalIssuer,
                        c.Type,
                        c.Value,
                        c.ValueType
                    });

            return TypedResults.Json(roles);
        }

        return Results.Unauthorized();

    }
    [HttpDelete("delete")]
    [Authorize]
    public async Task<IResult> DeleteAsync(UserManager<User> userManager)
    {

        var claimsPrincipal = HttpContext.User;
        if (claimsPrincipal.Identity is not null && claimsPrincipal.Identity.IsAuthenticated)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            if (email is not null)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user is not null)
                {
                    await userManager.DeleteAsync(user);
                    return Results.Ok();
                }
            }
        }

        return Results.Unauthorized();

    }
}