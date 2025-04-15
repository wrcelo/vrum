using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajustenomenotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MotorcycleNotifications",
                table: "MotorcycleNotifications");

            migrationBuilder.RenameTable(
                name: "MotorcycleNotifications",
                newName: "motorcycle_notifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_motorcycle_notifications",
                table: "motorcycle_notifications",
                column: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_motorcycle_notifications",
                table: "motorcycle_notifications");

            migrationBuilder.RenameTable(
                name: "motorcycle_notifications",
                newName: "MotorcycleNotifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotorcycleNotifications",
                table: "MotorcycleNotifications",
                column: "Guid");
        }
    }
}
