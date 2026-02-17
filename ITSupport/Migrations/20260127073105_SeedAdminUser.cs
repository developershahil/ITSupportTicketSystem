using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Security.Cryptography;
using System.Text;

namespace ITSupport.Migrations
{
    public partial class SeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var passwordHasher = new PasswordHasher();
            var password = "admin123";
            var salt = GenerateSalt();
            var hashedPassword = passwordHasher.HashPassword(password, salt);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Username", "PasswordHash" },
                values: new object[] { "admin", hashedPassword }
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Username",
                keyValues: "admin");
        }

        private static string GenerateSalt()
        {
            var salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}