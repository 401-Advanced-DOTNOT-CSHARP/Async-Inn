using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12_2.Migrations
{
    public partial class fiexedHotelProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StretAddress",
                table: "Hotels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StretAddress",
                table: "Hotels");
        }
    }
}
