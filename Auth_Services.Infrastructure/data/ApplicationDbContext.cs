using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Auth_Services.Domain.Entitys;
using Microsoft.AspNetCore.Identity;

namespace Auth_Services.Infrastructure.data;

public class ApplicationDbContext :IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions):base(dbContextOptions)
    {
        
    }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Seed roles
		modelBuilder.Entity<IdentityRole>().HasData(
			new IdentityRole { Id = Guid.NewGuid().ToString() , Name = "User", NormalizedName = "USER" },
			new IdentityRole { Id = Guid.NewGuid().ToString() , Name = "Admin", NormalizedName = "ADMIN" }
		);
	}
}
