using Microsoft.EntityFrameworkCore;
using Moc_DynamicCustomerService.Models;

namespace Moc_DynamicCustomerService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Accounts> Accounts => Set<Accounts>();
    public DbSet<Sla_contracts> Sla_contracts => Set<Sla_contracts>();
    public DbSet<Products> Products => Set<Products>();
    public DbSet<Licenses> Licenses => Set<Licenses>();
    public DbSet<Users> Users => Set<Users>();
    public DbSet<Cases> Cases => Set<Cases>();
    public DbSet<Notes> Notes => Set<Notes>();
    public DbSet<Emails> Emails => Set<Emails>();
    public DbSet<Contacts> Contacts => Set<Contacts>();
    public DbSet<Report> Reports => Set<Report>();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accounts>(entity =>
        {
            entity.HasKey(e => e.Account_id);
            entity.HasIndex(e => e.CompanyName).IsUnique();
            entity.Property(e => e.CompanyName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Industry).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Nip).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Address).IsRequired().HasMaxLength(150);
            entity.Property(e => e.City);
            entity.Property(e => e.Country);
            entity.Property(e => e.MainEmail).IsRequired().HasMaxLength(12);
            entity.Property(e => e.MainPhone).IsRequired().HasMaxLength(100);
            entity.Property(e => e.DateCreated).IsRequired();
            entity.Property(e => e.DateUpdated).IsRequired();
            entity
                .HasMany(e => e.Sla_contracts)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId); 
            entity
                .HasMany(e => e.Licenses)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId);
            entity
                .HasMany(e => e.Contacts)
                .WithOne(e => e.Account)
                .HasForeignKey(e => e.AccountId);
        }); 

        modelBuilder.Entity<Sla_contracts>(entity =>
        {
            entity.HasKey(e => e.Sla_id);
            entity.Property(e => e.AccountId).IsRequired();
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.minReactionTime).IsRequired();
            entity.Property(e => e.minSolveTime).IsRequired();
            entity.Property(e => e.startDate).IsRequired();
            entity.Property(e => e.endDate).IsRequired();
        });

         modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Product_id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Category).IsRequired();
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Price).IsRequired();
            entity
                .HasMany(e => e.Licenses)
                .WithOne(e => e.Products)
                .HasForeignKey(e => e.ProductId);
        });

         modelBuilder.Entity<Licenses>(entity =>
        {
            entity.HasKey(e => e.License_id);
            entity.Property(e => e.AccountId).IsRequired();
            entity.Property(e => e.ProductId).IsRequired();
            entity.Property(e => e.SeriesNumber).IsRequired().HasMaxLength(10);
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
        });
        
         modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.User_id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(10);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(15);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Login).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Role).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
        });

        modelBuilder.Entity<Cases>(entity =>
        {
            entity.HasKey(e => e.Case_id);
            entity.Property(e => e.AccountId);
            entity.Property(e => e.UserId);
            entity.Property(e => e.ContactId);
            entity.Property(e => e.Topic).HasMaxLength(100);
            entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.Priority).IsRequired();
            entity.Property(e => e.DateCreated).IsRequired();
            entity.Property(e => e.DateClosed).IsRequired();
            entity
                .HasOne(e => e.Account)
                .WithMany(e => e.Cases)
                .HasForeignKey(e => e.AccountId);
            entity
                .HasOne(e => e.User)
                .WithMany(e => e.Case)
                .HasForeignKey(e => e.UserId);
        });

         modelBuilder.Entity<Notes>(entity =>
        {
            entity.HasKey(e => e.Note_id);
            entity.Property(e => e.CaseId).IsRequired();
            entity.Property(e => e.UserId).IsRequired();
            entity.Property(e => e.Content).IsRequired().HasMaxLength(500);
            entity.Property(e => e.DateCreated).IsRequired();
            entity
                .HasOne(e => e.Case)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.CaseId);
            entity
                .HasOne(e => e.User)
                .WithMany(e => e.Notes)
                .HasForeignKey(e => e.UserId);
        });

         modelBuilder.Entity<Emails>(entity =>
        {
            entity.HasKey(e => e.Email_id);
            entity.Property(e => e.CaseId).IsRequired();
            entity.Property(e => e.Sender).IsRequired();
            entity.Property(e => e.Recipient).IsRequired().HasMaxLength(10);
            entity.Property(e => e.Subject).IsRequired();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.SendDate).IsRequired();
            entity
                .HasOne(e => e.Cases)
                .WithMany(e => e.Emails)
                .HasForeignKey(e => e.CaseId);
        });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.HasKey(e => e.Contact_id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Phone).IsRequired().HasMaxLength(12);
                entity.Property(e => e.DateCreated).IsRequired();
                entity.Property(e => e.DateUpdated).IsRequired();
                entity
                    .HasMany(e => e.Cases)
                    .WithOne(e => e.Contact)
                    .HasForeignKey(e => e.ContactId);

            });
    
            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Report_id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Type).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Parameters).IsRequired().HasColumnType("json");
                entity.Property(e => e.DateCreated).IsRequired();
                entity
                    .HasOne(e => e.User)
                    .WithMany(e => e.Reports)
                    .HasForeignKey(e => e.UserId);
            });
    }
}
