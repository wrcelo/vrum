using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusteRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverId",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "rentals",
                newName: "MotorcycleGuid");

            migrationBuilder.RenameColumn(
                name: "DeliveryDriverId",
                table: "rentals",
                newName: "DeliveryDriverGuid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rentals",
                newName: "Guid");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_MotorcycleId",
                table: "rentals",
                newName: "IX_rentals_MotorcycleGuid");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_DeliveryDriverId",
                table: "rentals",
                newName: "IX_rentals_DeliveryDriverGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverGuid",
                table: "rentals",
                column: "DeliveryDriverGuid",
                principalTable: "delivery_drivers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleGuid",
                table: "rentals",
                column: "MotorcycleGuid",
                principalTable: "motorcycles",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_drivers_DeliveryDriverGuid",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleGuid",
                table: "rentals");

            migrationBuilder.RenameColumn(
                name: "MotorcycleGuid",
                table: "rentals",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "DeliveryDriverGuid",
                table: "rentals",
                newName: "DeliveryDriverId");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "rentals",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_MotorcycleGuid",
                table: "rentals",
                newName: "IX_rentals_MotorcycleId");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_DeliveryDriverGuid",
                table: "rentals",
                newName: "IX_rentals_DeliveryDriverId");

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
    }
}
