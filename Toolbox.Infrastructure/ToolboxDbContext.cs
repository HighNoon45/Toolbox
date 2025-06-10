using Microsoft.EntityFrameworkCore;
using Toolbox.Infrastructure.Entities;

namespace Toolbox.Infrastructure
{
    public class ToolboxDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ToolDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Request)
                .WithOne(r => r.Chat)
                .HasForeignKey<Chat>(c => c.RequestId);

            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Response)
                .WithOne(r => r.Chat)
                .HasForeignKey<Chat>(c => c.ResponseId);
        }
    }
}
