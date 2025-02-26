using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odata.Endpoints.Migrations
{
    /// <inheritdoc />
    public partial class deletedsomecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryType",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
