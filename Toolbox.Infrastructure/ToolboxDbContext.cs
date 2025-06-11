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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-V5M89SE\SQLEXPRESS;Database=ToolDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
        }
        //Add-Migration InitialCreate -OutputDir "Migrations"
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
