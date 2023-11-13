using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingComplex.Infrastructure.Migrations
{
    public partial class MaintenanceContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceContractId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaintenanceContracts",
                columns: table => new
                {
                    MaintenanceContractId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceContracts", x => x.MaintenanceContractId);
                });

            migrationBuilder.CreateTable(
                name: "MaintenancePayments",
                columns: table => new
                {
                    MaintenancePaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceContractId = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePayments", x => x.MaintenancePaymentId);
                    table.ForeignKey(
                        name: "FK_MaintenancePayments_MaintenanceContracts_MaintenanceContractId",
                        column: x => x.MaintenanceContractId,
                        principalTable: "MaintenanceContracts",
                        principalColumn: "MaintenanceContractId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_MaintenanceContractId",
                table: "Stores",
                column: "MaintenanceContractId",
                unique: true,
                filter: "[MaintenanceContractId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePayments_MaintenanceContractId",
                table: "MaintenancePayments",
                column: "MaintenanceContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_MaintenanceContracts_MaintenanceContractId",
                table: "Stores",
                column: "MaintenanceContractId",
                principalTable: "MaintenanceContracts",
                principalColumn: "MaintenanceContractId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_MaintenanceContracts_MaintenanceContractId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "MaintenancePayments");

            migrationBuilder.DropTable(
                name: "MaintenanceContracts");

            migrationBuilder.DropIndex(
                name: "IX_Stores_MaintenanceContractId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "MaintenanceContractId",
                table: "Stores");
        }
    }
}
