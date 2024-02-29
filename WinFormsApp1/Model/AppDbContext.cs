using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\testing.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasMany(e => e.User)
                .WithMany(e => e.Message)
                .UsingEntity(
                    "UserMessage",
                    l => l.HasOne(typeof(User)).WithMany().HasForeignKey("UserId").HasPrincipalKey(nameof(User.UserId)),
                    r => r.HasOne(typeof(Message)).WithMany().HasForeignKey("MessageId").HasPrincipalKey(nameof(Message.MessageId)),
                    j => j.HasKey("UserId", "MessageId"));
        }


        public DbSet<User> Users { get; set; }
       public DbSet<Message> messages { get; set; }
    }
}
