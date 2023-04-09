using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Catchsmart.Areas.Identity.Data;

public class CatchsmartIdentityDbContext : IdentityDbContext<CatchsmartUser>
{
    public CatchsmartIdentityDbContext(DbContextOptions<CatchsmartIdentityDbContext> options)
        : base(options)
    {
    }

    public DbSet<CatchsmartUser> Users { get; set; }
    public DbSet<Avatar> Avatars { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
