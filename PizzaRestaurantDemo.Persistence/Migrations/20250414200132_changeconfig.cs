using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurantDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeconfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "Pizza",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                schema: "dbo",
                table: "Pizza",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }
    }
}
