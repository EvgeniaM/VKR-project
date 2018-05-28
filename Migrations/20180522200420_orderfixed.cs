using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServerVKR.Migrations
{
    public partial class orderfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "DeliverysId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliverysId",
                table: "Orders",
                column: "DeliverysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliverys_DeliverysId",
                table: "Orders",
                column: "DeliverysId",
                principalTable: "Deliverys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliverys_DeliverysId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliverysId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliverysId",
                table: "Orders");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Deliverys",
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
    }
}
