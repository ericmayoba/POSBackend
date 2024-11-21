using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DB
{
    public class PosContextFactory : IDesignTimeDbContextFactory<PosContext>
    {
        public PosContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PosContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432; Database=pos; Username=postgres; Password= M@yoba39.");  // Tu cadena de conexión completa

            return new PosContext(optionsBuilder.Options);
        }
    }
}
