using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgyBest.Domain.Context.Migrations
{
    /// <inheritdoc />
    public partial class AddCalculateRat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalculateRate",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculateRate",
                table: "Movies");
        }
    }
}
