using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wrcelo.VrumApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusteNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificacoesMoto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MotoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Modelo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "integer", nullable: false),
                    DataNotificacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacoesMoto", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificacoesMoto");
        }
    }
}
