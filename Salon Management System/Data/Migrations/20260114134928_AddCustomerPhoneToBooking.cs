using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Management_System.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPhoneToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhone",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhone",
                table: "Bookings");
        }
    }
}
