using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingDervico.Migrations
{
    public partial class initialcommitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "varchar(100)", nullable: false),
                    rolePriority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffId = table.Column<string>(type: "varchar(7)", nullable: false),
                    fullName = table.Column<string>(type: "varchar(150)", nullable: false),
                    emailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobileNo = table.Column<string>(type: "varchar(15)", nullable: false),
                    joiningDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    odcName = table.Column<string>(type: "varchar(45)", nullable: false),
                    designation = table.Column<string>(type: "varchar(45)", nullable: false),
                    location = table.Column<string>(type: "varchar(45)", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    authType = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lockcount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => new { x.userId, x.staffId });
                    table.ForeignKey(
                        name: "FK_users_role_roleId",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_roleId",
                table: "users",
                column: "roleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
