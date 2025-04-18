using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurantDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_address_AddressId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                schema: "dbo",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                schema: "dbo",
                table: "address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "dbo",
                table: "address",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_address_UserId",
                schema: "dbo",
                table: "address",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address_Users_UserId",
                schema: "dbo",
                table: "address",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_Users_UserId",
                schema: "dbo",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_UserId",
                schema: "dbo",
                table: "address");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "address");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                schema: "dbo",
                table: "address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                schema: "dbo",
                table: "Users",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_address_AddressId",
                schema: "dbo",
                table: "Users",
                column: "AddressId",
                principalSchema: "dbo",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
