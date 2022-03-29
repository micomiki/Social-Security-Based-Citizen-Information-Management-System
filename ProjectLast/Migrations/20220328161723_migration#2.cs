using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLast.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "POB",
                table: "Citizens",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Citizens",
                newName: "POB");
        }
    }
}
