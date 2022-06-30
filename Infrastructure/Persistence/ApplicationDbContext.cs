using Core.Domain.Models;
using Core.Domain.Models.SetupModels;
using MassTransit.Futures.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<ClientDetailsModel> ClientDetails { get; set; }
    public DbSet<CommissionRate> CommissionRates { get; set; }
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<IdType> IdTypes { get; set; }
    public DbSet<InsuranceDetails> InsuranceDetails { get; set; }
    public DbSet<PaymentType> PaymentTypes { get; set; }
    public DbSet<PaymentModel> PaymentModels { get; set; }
    public DbSet<TransactionType> TransactionTypes { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.HasDefaultSchema("UserSchema").Entity<User>();
        //builder.HasDefaultSchema("CRM").Entity<ClientDetailsModel>();
        builder.Entity<User>().HasData(
            new User
            {
                Id = new Guid("C4D21AEA-1BDF-4E0E-AE72-A6A300F25A9B"),
                FirstName = "Derrick",
                LastName = "Yeboah",
                Username = "admin",
                Email = "admin@gmail.com",
                Contact = "0549234591",
                RoleTypeId = "F529441F-72B0-4A51-B861-A6F7FC2327BA",
                Password = "admin",
                PhoneNumber = "233549234591",
                TenantKey = "F529441F-72B0-4A51-B861-A6F7FC2327BA",
                CreatedBy = "admin",
                ProfilePicture = "",
                CreatedDate = DateTime.UtcNow
            });
        base.OnModelCreating(builder);
    }
}