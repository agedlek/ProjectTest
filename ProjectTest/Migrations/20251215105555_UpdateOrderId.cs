using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTest.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderLineId",
                table: "OrderLine");

            migrationBuilder.RenameColumn(
                name: "OrderLineId",
                table: "OrderLine",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderLineId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLine_Order_OrderId",
                table: "OrderLine");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderLine",
                newName: "OrderLineId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderLine_OrderId",
                table: "OrderLine",
                newName: "IX_OrderLine_OrderLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderLineId",
                table: "OrderLine",
                column: "OrderLineId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
