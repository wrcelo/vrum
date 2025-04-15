using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusteIngles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NotificacoesMoto",
                table: "NotificacoesMoto");

            migrationBuilder.RenameTable(
                name: "NotificacoesMoto",
                newName: "MotorcycleNotifications");

            migrationBuilder.RenameColumn(
                name: "MotoId",
                table: "MotorcycleNotifications",
                newName: "MotorcycleGuid");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "MotorcycleNotifications",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "DataNotificacao",
                table: "MotorcycleNotifications",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "MotorcycleNotifications",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MotorcycleNotifications",
                newName: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotorcycleNotifications",
                table: "MotorcycleNotifications",
                column: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MotorcycleNotifications",
                table: "MotorcycleNotifications");

            migrationBuilder.RenameTable(
                name: "MotorcycleNotifications",
                newName: "NotificacoesMoto");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "NotificacoesMoto",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "MotorcycleGuid",
                table: "NotificacoesMoto",
                newName: "MotoId");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "NotificacoesMoto",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "NotificacoesMoto",
                newName: "DataNotificacao");

            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "NotificacoesMoto",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NotificacoesMoto",
                table: "NotificacoesMoto",
                column: "Id");
        }
    }
}
