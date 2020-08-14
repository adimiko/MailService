using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF
{
    public class MailServiceContext : DbContext
    {
        public DbSet<EmailSettings> EmailSettings {get; set;}
        public DbSet<Mail> Mails {get; set;}
        public MailServiceContext(DbContextOptions<MailServiceContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =  @"Server=localhost\SQLEXPRESS;Database=EFQuerying;Trusted_Connection=True;Database=MailService";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var emailSettings = modelBuilder.Entity<EmailSettings>();
            emailSettings.HasKey(x => x.Id);
            emailSettings.OwnsOne(x => x.Email)
                .Property( x => x.Value).HasColumnName("Email");

            var mail = modelBuilder.Entity<Mail>();

            mail.HasKey(x => x.Id);

            mail.OwnsOne(x => x.From)
                .Property(x => x.Value)
                .HasColumnName("From");

            mail.OwnsOne(x => x.To)
                .Property(x => x.Value)
                .HasColumnName("To");
        }
    }
}