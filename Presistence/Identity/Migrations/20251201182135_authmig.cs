using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Presistence.Identity.Migrations
{
    /// <inheritdoc />
    public partial class authmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CV",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CV",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
