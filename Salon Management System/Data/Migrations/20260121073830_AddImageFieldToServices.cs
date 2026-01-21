using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImageFieldToServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "SalonServices",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "SalonServices");
        }
    }
}
