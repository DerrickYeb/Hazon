using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hazon.DAL.Migrations
{
    public partial class authSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Contact", "CreatedBy", "CreatedDate", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "RoleTypeId", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName", "Username" },
                values: new object[] { "c9bec67b-60df-4ad4-9d86-92ad7490148f", 0, "3905e158-6cd3-40ab-ac29-937d1f85173e", "0549234591", "admin", new DateTime(2022, 4, 9, 11, 49, 5, 264, DateTimeKind.Utc).AddTicks(4640), "User", null, false, "Derrick", "Yeboah", false, null, null, null, "admin", null, null, false, "", "F529441F-72B0-4A51-B861-A6F7FC2327BA", "2984e4a3-77aa-4eaa-b19c-1d9f71ab6a9f", "F529441F-72B0-4A51-B861-A6F7FC2327BA", false, null, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9bec67b-60df-4ad4-9d86-92ad7490148f");
        }
    }
}
