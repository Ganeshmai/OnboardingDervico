using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnboardingDervico.Migrations
{
    public partial class profiletableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userProfile",
                columns: table => new
                {
                    profileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    staffId = table.Column<string>(type: "varchar(7)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: false),
                    startDate = table.Column<DateTime>(type: "date", nullable: false),
                    RecentActivity = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userProfile", x => x.profileId);
                    table.ForeignKey(
                        name: "FK_userProfile_users_staffId",
                        column: x => x.staffId,
                        principalTable: "users",
                        principalColumn: "staffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userProfile_staffId",
                table: "userProfile",
                column: "staffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userProfile");
        }
    }
}
