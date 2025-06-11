using Microsoft.EntityFrameworkCore.Design;

namespace Toolbox.Infrastructure
{
    internal class DbContextFactory : IDesignTimeDbContextFactory<ToolboxDbContext>
    {
        public ToolboxDbContext CreateDbContext(string[] args)
        {
            var dbContext = new ToolboxDbContext();
            return dbContext;
        }
    }

}
