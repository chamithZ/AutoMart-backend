using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_partId",
                table: "Orders",
                column: "partId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Parts_partId",
                table: "Orders",
                column: "partId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Parts_partId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_partId",
                table: "Orders");
        }
    }
}
