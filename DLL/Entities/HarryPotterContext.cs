using Microsoft.EntityFrameworkCore;

namespace DLL.Entities
{
    public class HarryPotterContext: DbContext
    {
        public HarryPotterContext(DbContextOptions<HarryPotterContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Id)
                .IsUnique();
            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<UserInfo>()
                .HasIndex(e => e.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Login)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserInfo)
                .WithOne(ui => ui.User)
                .HasForeignKey<UserInfo>(ui => ui.UserId);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<UserInfo>()
                .HasKey(u => u.UserId);
        }
        public DbSet<User> User { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
