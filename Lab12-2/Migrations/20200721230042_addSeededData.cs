using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12_2.Migrations
{
    public partial class addSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Air Conditioner" },
                    { 2, "Heater" },
                    { 3, "Fridge" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "State", "StretAddress" },
                values: new object[,]
                {
                    { 1, "Seattle", "Bryant Comfort Inn", "555-555-5555", "Washington", "123 Fake Street" },
                    { 2, "Burien", "Bryant Resort", "555-555-9999", "Washington", "312 Awesome Avenue" },
                    { 3, "San Diego", "Bryant Sunny Lake View Hotel", "888-777-6666", "California", "876 Burned Avenue" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Vampire Suite" },
                    { 2, 3, "Burned Villa" },
                    { 3, 1, "Boring Cottage" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
