using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Data
{
    public class AuthorizationIdentityDbContext : IdentityDbContext
    {
        public AuthorizationIdentityDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
