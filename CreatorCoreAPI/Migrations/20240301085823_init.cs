using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreatorCoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    creatorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    creatorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    creatorRevenueSplit = table.Column<float>(type: "real", nullable: false),
                    creatorRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lifeTimeEarnings = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.creatorID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    transactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    creatorID = table.Column<int>(type: "int", nullable: true),
                    clientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.transactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_clientID",
                        column: x => x.clientID,
                        principalTable: "Clients",
                        principalColumn: "clientID");
                    table.ForeignKey(
                        name: "FK_Transactions_Creators_creatorID",
                        column: x => x.creatorID,
                        principalTable: "Creators",
                        principalColumn: "creatorID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_clientID",
                table: "Transactions",
                column: "clientID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_creatorID",
                table: "Transactions",
                column: "creatorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Creators");
        }
    }
}
