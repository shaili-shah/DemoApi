using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Infrastructure.Migrations
{
    public partial class removeRoleIdFromApplicationUserTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "ApplicationUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "ApplicationUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
