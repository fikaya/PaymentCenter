using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentCenter.DataAccessLayer.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubscriberRegistrationNumber",
                table: "InstitutionSubscribers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriberRegistrationNumber",
                table: "InstitutionSubscribers");
        }
    }
}
