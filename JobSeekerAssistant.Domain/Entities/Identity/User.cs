using Microsoft.AspNetCore.Identity;

namespace JobSeekerAssistant.Domain.Entities.Identity;

public class User : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
}