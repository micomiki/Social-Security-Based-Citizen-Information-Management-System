using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectLast.Migrations
{
    public partial class migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Citizens");

            migrationBuilder.AddColumn<int>(
                name: "CityCode",
                table: "Citizens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Citizens_CityCode",
                table: "Citizens",
                column: "CityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Citizens_Cities_CityCode",
                table: "Citizens",
                column: "CityCode",
                principalTable: "Cities",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citizens_Cities_CityCode",
                table: "Citizens");

            migrationBuilder.DropIndex(
                name: "IX_Citizens_CityCode",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Citizens");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
