using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Data.Sql.DbMappings.Identity;

namespace OnlineAkademi.Data.Sql.Identity
{
    public class IdentityContext:IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions):base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new AppUserMapping());
        }
    }
}
