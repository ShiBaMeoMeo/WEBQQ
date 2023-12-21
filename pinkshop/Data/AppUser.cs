using Microsoft.AspNetCore.Identity;

namespace pinkshop.Areas.Identity.Data
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
