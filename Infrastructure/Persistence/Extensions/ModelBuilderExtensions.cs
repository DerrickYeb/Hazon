using Core.Application.Abstractions.Services.General;
using Core.Domain.Models;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAuthenticationConfiguration(this ModelBuilder modelBuilder,ITenantService service)
        {
            var dbProvider = service.GetDatabaseProvider();
            modelBuilder.Entity<ApplicationUser>(user =>
            {
                user.ToTable("Users", "Authentication");
            });

            modelBuilder.Entity<ApplicationRole>(role =>
            {
                role.ToTable("Roles", "Authentication");
                role.Metadata.RemoveIndex(new[] { role.Property(r => r.NormalizedName).Metadata });
                role.HasIndex(r => new {r.NormalizedName,r.TenantKey}).HasDatabaseName("RoleIndexName").IsUnique();
            });

            modelBuilder.Entity<ApplicationRoleClaim>(claim =>
            {
                claim.ToTable("RoleClaims", "Authentication");
            });

            modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Authentication");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Authentication");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Authentication");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Authentication");
            });
        }

        public static void ApplyGlobalFilters<TInterface>(this ModelBuilder modelBuilder,Expression<Func<TInterface,bool>> expression)
        {
            var entities = modelBuilder.Model
                .GetEntityTypes()
                .Where(c => c.ClrType.GetInterface(typeof(TInterface).Name) != null)
                .Select(c => c.ClrType);

            foreach (var entiy in entities)
            {
                var newParam = Expression.Parameter(entiy);
                var newBody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
                modelBuilder.Entity(entiy).HasQueryFilter(Expression.Lambda(newBody, newParam));
            }
        }
    }
}
