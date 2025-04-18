using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaRestaurantDemo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addtable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_Pizza_PizzasId",
                schema: "dbo",
                table: "OrderPizza");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderPizza_orders_PizzaOrdersId",
                schema: "dbo",
                table: "OrderPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderPizza",
                schema: "dbo",
                table: "OrderPizza");

            migrationBuilder.RenameTable(
                name: "OrderPizza",
                schema: "dbo",
                newName: "PizzaOrder",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "PizzaOrdersId",
                schema: "dbo",
                table: "PizzaOrder",
                newName: "OrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderPizza_PizzasId",
                schema: "dbo",
                table: "PizzaOrder",
                newName: "IX_PizzaOrder_PizzasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaOrder",
                schema: "dbo",
                table: "PizzaOrder",
                columns: new[] { "OrdersId", "PizzasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrder_Pizza_PizzasId",
                schema: "dbo",
                table: "PizzaOrder",
                column: "PizzasId",
                principalSchema: "dbo",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaOrder_orders_OrdersId",
                schema: "dbo",
                table: "PizzaOrder",
                column: "OrdersId",
                principalSchema: "dbo",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrder_Pizza_PizzasId",
                schema: "dbo",
                table: "PizzaOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaOrder_orders_OrdersId",
                schema: "dbo",
                table: "PizzaOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaOrder",
                schema: "dbo",
                table: "PizzaOrder");

            migrationBuilder.RenameTable(
                name: "PizzaOrder",
                schema: "dbo",
                newName: "OrderPizza",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                schema: "dbo",
                table: "OrderPizza",
                newName: "PizzaOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaOrder_PizzasId",
                schema: "dbo",
                table: "OrderPizza",
                newName: "IX_OrderPizza_PizzasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderPizza",
                schema: "dbo",
                table: "OrderPizza",
                columns: new[] { "PizzaOrdersId", "PizzasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_Pizza_PizzasId",
                schema: "dbo",
                table: "OrderPizza",
                column: "PizzasId",
                principalSchema: "dbo",
                principalTable: "Pizza",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPizza_orders_PizzaOrdersId",
                schema: "dbo",
                table: "OrderPizza",
                column: "PizzaOrdersId",
                principalSchema: "dbo",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
