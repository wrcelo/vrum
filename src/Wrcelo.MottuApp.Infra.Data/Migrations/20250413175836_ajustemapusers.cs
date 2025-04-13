using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustemapusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_delivery_drivers_DeliveryDriverId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_motorcycles_MotorcycleId",
                table: "Rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Rentals",
                newName: "rentals");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_MotorcycleId",
                table: "rentals",
                newName: "IX_rentals_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_Rentals_DeliveryDriverId",
                table: "rentals",
                newName: "IX_rentals_DeliveryDriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rentals",
                table: "rentals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rentals",
                table: "rentals");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "rentals",
                newName: "Rentals");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_MotorcycleId",
                table: "Rentals",
                newName: "IX_Rentals_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_DeliveryDriverId",
                table: "Rentals",
                newName: "IX_Rentals_DeliveryDriverId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rentals",
                table: "Rentals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_delivery_drivers_DeliveryDriverId",
                table: "Rentals",
                column: "DeliveryDriverId",
                principalTable: "delivery_drivers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_motorcycles_MotorcycleId",
                table: "Rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
