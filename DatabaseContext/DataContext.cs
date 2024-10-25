using Microsoft.EntityFrameworkCore;
using SimpleTwitter.Models;

namespace SimpleTwitter.DatabaseContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TwitterPost> TwitterPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TwitterPost>()
                .HasKey(p => p.TwitterId); // Explicitly define the primary key
        }

    }

}
