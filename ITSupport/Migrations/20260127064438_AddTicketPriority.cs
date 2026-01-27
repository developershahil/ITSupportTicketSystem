using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITSupport.Migrations
{
    /// <inheritdoc />
    public partial class AddTicketPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketPriorities",
                columns: table => new
                {
                    PriorityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriorityName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPriorities", x => x.PriorityId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketPriorities");
        }
    }
}
