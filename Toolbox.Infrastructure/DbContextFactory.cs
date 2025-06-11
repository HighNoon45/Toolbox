using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
