using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AAA.Models
{
    public class AAADbContext : IdentityDbContext<customIdentityUser>
    {
        public AAADbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
