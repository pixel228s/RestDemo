using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurantDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addbridge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "pizzaOrders",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzaOrders", x => new { x.OrderId, x.PizzaId });
                    table.ForeignKey(
                        name: "FK_pizzaOrders_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalSchema: "dbo",
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pizzaOrders_orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizzaOrders_PizzaId",
                schema: "dbo",
                table: "pizzaOrders",
                column: "PizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pizzaOrders",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                schema: "dbo",
                columns: table => new
                {
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    PizzasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => new { x.OrdersId, x.PizzasId });
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalSchema: "dbo",
                        principalTable: "Pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "dbo",
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_PizzasId",
                schema: "dbo",
                table: "PizzaOrder",
                column: "PizzasId");
        }
    }
}
