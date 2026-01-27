using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSupport.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByAssignedTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedTo",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tickets");
        }
    }
}
