using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AfiCustomerApi.Data.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfiCustomer",
                columns: table => new
                {
                    AfiCustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    SurName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    PolicyReferenceNumber = table.Column<string>(maxLength: 9, nullable: false),
                    Dob = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfiCustomer", x => x.AfiCustomerID);
                });
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfiCustomer");
        }
    }
}
