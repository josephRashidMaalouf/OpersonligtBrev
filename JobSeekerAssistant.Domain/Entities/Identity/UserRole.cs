using System.Data;
using Microsoft.AspNetCore.Identity;

namespace JobSeekerAssistant.Domain.Entities.Identity;

public class UserRole : IdentityUserRole<string>
{
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}