using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineAkademi.Core.Domain.Entities.Identity;
using OnlineAkademi.Data.Sql.DbMappings.Identity;

namespace OnlineAkademi.Data.Sql
{
    public class IdentityContext:IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> dbContextOptions):base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<AppUser>(new AppUserMapping());
        }
    }
}
