using Microsoft.EntityFrameworkCore;
using Toolbox.Infrastructure.Entities;

namespace Toolbox.Infrastructure
{
    public class ToolboxDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }

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
