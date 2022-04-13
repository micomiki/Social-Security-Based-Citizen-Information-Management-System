using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLast.Migrations
{
    public partial class middlename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mid_Name",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCity",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mid_Name",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "SubCity",
                table: "Citizens");
        }
    }
}
