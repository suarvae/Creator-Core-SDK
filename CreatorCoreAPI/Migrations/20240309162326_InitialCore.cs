using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatorCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Clients_clientID",
                table: "Transactions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_clientID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "clientID",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clientID",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    clientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.clientID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_clientID",
                table: "Transactions",
                column: "clientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Clients_clientID",
                table: "Transactions",
                column: "clientID",
                principalTable: "Clients",
                principalColumn: "clientID");
        }
    }
}
