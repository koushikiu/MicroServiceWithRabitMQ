﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroRabbit.Transfer.Data.Migrations
{
    public partial class TransferMocriServiceinitialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transferLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormAccount = table.Column<int>(type: "int", nullable: false),
                    ToAccount = table.Column<int>(type: "int", nullable: false),
                    TransferAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transferLogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transferLogs");
        }
    }
}
