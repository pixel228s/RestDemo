using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurantDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_orders_OrderId",
                schema: "dbo",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_OrderId",
                schema: "dbo",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "dbo",
                table: "Pizza");

            migrationBuilder.CreateTable(
                name: "OrderPizza",
                schema: "dbo",
                columns: table => new
                {
                    PizzaOrdersId = table.Column<int>(type: "int", nullable: false),
                    PizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPizza", x => new { x.PizzaOrdersId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_OrderPizza_Pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalSchema: "dbo",
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPizza_orders_PizzaOrdersId",
                        column: x => x.PizzaOrdersId,
                        principalSchema: "dbo",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPizza_PizzasId",
                schema: "dbo",
                table: "OrderPizza",
                column: "PizzasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPizza",
                schema: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "dbo",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_OrderId",
                schema: "dbo",
                table: "Pizza",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_orders_OrderId",
                schema: "dbo",
                table: "Pizza",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "orders",
                principalColumn: "Id");
        }
    }
}
