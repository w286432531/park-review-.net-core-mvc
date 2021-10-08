using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsSite.Migrations
{
    public partial class addedDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "HasHandicapAccess", "IsDogFriendly", "Name", "ParkType" },
                values: new object[,]
                {
                    { 1, true, true, "Edgewater", "Beach" },
                    { 2, false, true, "Mohican", "River" },
                    { 3, false, false, "Kurtz", "Sport" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "ParkId", "ReviewerName", "StarRating" },
                values: new object[] { 1, null, 2340, null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
