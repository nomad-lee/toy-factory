using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseProject.Data
{
    public class BaseDbContext : IdentityDbContext<IdentityUser>
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> option) : base(option)
        {
        }
    }
}
