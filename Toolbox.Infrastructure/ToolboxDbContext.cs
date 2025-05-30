using Microsoft.EntityFrameworkCore;
using Toolbox.Infrastructure.Entities;

namespace Toolbox.Infrastructure
{
    public class ToolboxDbContext : DbContext
    {
        DbSet<Chat> Chats { get; set; }
        DbSet<Request> Requests { get; set; }
        DbSet<Chat> Response { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ToolDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
