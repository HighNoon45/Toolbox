using Microsoft.Extensions.Configuration;

namespace Toolbox.Infrastructure
{
    //dotnet user-secrets init --project Toolbox.Infrastructure
    //dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=DESKTOP-V5M89SE\SQLEXPRESS;Database=ToolDB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;" --project Toolbox.Infrastructure
    //Add-Migration MigrationName -Project Toolbox.Infrastructure -StartupProject Toolbox.Infrastructure -OutputDir "Migrations"

    public class ToolboxDbContext : DbContext
    {
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Build configuration with user secrets
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<ToolboxDbContext>()
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string not found");

            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User -> Chats (One-to-Many)
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.User)
                .WithMany(u => u.Chats)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Chat -> Request (One-to-One)
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Request)
                .WithOne(r => r.Chat)
                .HasForeignKey<Chat>(c => c.RequestId)
                .OnDelete(DeleteBehavior.Cascade);

            // Chat -> Response (One-to-One)
            modelBuilder.Entity<Chat>()
                .HasOne(c => c.Response)
                .WithOne(r => r.Chat)
                .HasForeignKey<Chat>(c => c.ResponseId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes for better performance
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Chat>()
                .HasIndex(c => c.UserId);
        }
    }
}
