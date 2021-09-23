using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Part01.Models.AAA
{
    public class AAADbContext : IdentityDbContext<UserApp>
    {
        public AAADbContext(DbContextOptions<AAADbContext> options) : base(options)
        {

        }
        public DbSet<BlackList> BlackLists { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        //}
    }
}