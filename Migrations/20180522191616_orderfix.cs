using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServerVKR.Migrations
{
    public partial class orderfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Deliverys",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliverys_OrderId",
                table: "Deliverys",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deliverys_Orders_OrderId",
                table: "Deliverys",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliverys_Orders_OrderId",
                table: "Deliverys");

            migrationBuilder.DropIndex(
                name: "IX_Deliverys_OrderId",
                table: "Deliverys");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Deliverys");
        }
    }
}
