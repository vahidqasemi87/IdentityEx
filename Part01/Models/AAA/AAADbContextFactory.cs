using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Part01.Models.AAA
{
    public class AAADbContextFactory : IDesignTimeDbContextFactory<AAADbContext>
    {
        public AAADbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AAADbContext>();
            builder.UseSqlServer("server=.;database=AAA01Db;uid=test;pwd=sqlserver2017!@#$%;");
            return new AAADbContext(builder.Options);
        }
    }
}
