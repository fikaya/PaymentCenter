using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentCenter.DataAccessLayer.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_BoxOfficeAttendants_BoxOfficeAttendantID",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "BoxOfficeAttendantID",
                table: "Invoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_BoxOfficeAttendants_BoxOfficeAttendantID",
                table: "Invoices",
                column: "BoxOfficeAttendantID",
                principalTable: "BoxOfficeAttendants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_BoxOfficeAttendants_BoxOfficeAttendantID",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "BoxOfficeAttendantID",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_BoxOfficeAttendants_BoxOfficeAttendantID",
                table: "Invoices",
                column: "BoxOfficeAttendantID",
                principalTable: "BoxOfficeAttendants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
