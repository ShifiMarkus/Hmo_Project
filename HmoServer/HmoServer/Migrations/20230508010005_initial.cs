using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HmoServer.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    customer_id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    house_number = table.Column<int>(type: "int", nullable: true),
                    phone_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cell_phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "CoronaDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    first_vaccition_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    second_vaccition_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    third_vaccition_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    forth_vaccition_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    first_vaccination_manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    second_vaccination_manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    third_vaccination_manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    forth_vaccination_manufacturer = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    positive_result_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    recovery_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    customer_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoronaDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_CoronaDetails_Customers",
                        column: x => x.customer_id,
                        principalTable: "Customers",
                        principalColumn: "customer_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoronaDetails_customer_id",
                table: "CoronaDetails",
                column: "customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoronaDetails");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
