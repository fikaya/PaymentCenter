using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentCenter.DataAccessLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BoxOfficeAttendants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoxOfficeAttendantName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BoxOfficeAttendantSurname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BoxOfficeAttendantIdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BoxOfficeAttendantPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BoxOfficeAttendantEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoxOfficeAttendantAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxOfficeAttendants", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SubscriberSurname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SubscriberIdentityNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SubscriberPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SubscriberEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubscriberAge = table.Column<int>(type: "int", nullable: false),
                    SubscriberAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstitutionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InstitutionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Institutions_InstitutionTypes_InstitutionTypeID",
                        column: x => x.InstitutionTypeID,
                        principalTable: "InstitutionTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionSubscribers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepositAmount = table.Column<float>(type: "real", nullable: false),
                    InstitutionID = table.Column<int>(type: "int", nullable: false),
                    SubscriberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionSubscribers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InstitutionSubscribers_Institutions_InstitutionID",
                        column: x => x.InstitutionID,
                        principalTable: "Institutions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstitutionSubscribers_Subscribers_SubscriberID",
                        column: x => x.SubscriberID,
                        principalTable: "Subscribers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceAmount = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoxOfficeAttendantID = table.Column<int>(type: "int", nullable: false),
                    InstitutionSubscriberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_BoxOfficeAttendants_BoxOfficeAttendantID",
                        column: x => x.BoxOfficeAttendantID,
                        principalTable: "BoxOfficeAttendants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_InstitutionSubscribers_InstitutionSubscriberID",
                        column: x => x.InstitutionSubscriberID,
                        principalTable: "InstitutionSubscribers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Institutions_InstitutionTypeID",
                table: "Institutions",
                column: "InstitutionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionSubscribers_InstitutionID",
                table: "InstitutionSubscribers",
                column: "InstitutionID");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionSubscribers_SubscriberID",
                table: "InstitutionSubscribers",
                column: "SubscriberID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_BoxOfficeAttendantID",
                table: "Invoices",
                column: "BoxOfficeAttendantID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InstitutionSubscriberID",
                table: "Invoices",
                column: "InstitutionSubscriberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "BoxOfficeAttendants");

            migrationBuilder.DropTable(
                name: "InstitutionSubscribers");

            migrationBuilder.DropTable(
                name: "Institutions");

            migrationBuilder.DropTable(
                name: "Subscribers");

            migrationBuilder.DropTable(
                name: "InstitutionTypes");
        }
    }
}
