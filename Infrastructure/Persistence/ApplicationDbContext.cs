using Core.Application.Abstractions.Services.AuthService;
using Core.Application.Abstractions.Services.General;
using Core.Domain.Contracts;
using Core.Domain.Models;
using Core.Domain.Models.SetupModels;
using MassTransit.Futures.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Infrastructure.Persistence;

public class ApplicationDbContext :BaseDbContext
{
    private readonly ITenantService _tenantService;
    public IDbConnection connection => Database.GetDbConnection();
    private readonly ISerializerService _serializer;
    private readonly ICurrentUser _currentUser;
    public ApplicationDbContext(DbContextOptions options,ICurrentUser currentUser,ITenantService tenantService,ISerializerService serializer)
        : base((DbContextOptions<BaseDbContext>)options,currentUser,tenantService,serializer)
    {
        _tenantService = tenantService;
        _currentUser = currentUser;
        _serializer = serializer;
    }
    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        base.OnModelCreating(optionsBuilder);
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var currentUserId = _currentUser.GetUserId();
        foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = currentUserId;
                    entry.Entity.LastModifiedBy = currentUserId;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedOn = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = currentUserId;
                    break;
                case EntityState.Deleted:
                    if (entry.Entity is ISoftDelete softDelete)
                    {
                        softDelete.DeletedBy = currentUserId;
                        softDelete.DeletedOn = DateTime.UtcNow;
                        entry.State = EntityState.Modified;
                    }

                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    //builder.HasDefaultSchema("UserSchema").Entity<User>();
    //    //builder.HasDefaultSchema("CRM").Entity<ClientDetailsModel>();
    //    builder.Entity<User>().HasData(
    //        new User
    //        {
    //            Id = new Guid("C4D21AEA-1BDF-4E0E-AE72-A6A300F25A9B"),
    //            FirstName = "Derrick",
    //            LastName = "Yeboah",
    //            Username = "admin",
    //            Email = "admin@gmail.com",
    //            Contact = "0549234591",
    //            RoleTypeId = "F529441F-72B0-4A51-B861-A6F7FC2327BA",
    //            Password = "admin",
    //            PhoneNumber = "233549234591",
    //            TenantKey = "F529441F-72B0-4A51-B861-A6F7FC2327BA",
    //            CreatedBy = "admin",
    //            ProfilePicture = "",
    //            CreatedDate = DateTime.UtcNow
    //        });
    //    base.OnModelCreating(builder);
    //}
}