using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsSite.Migrations
{
    public partial class ParkDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParkDescription",
                table: "Parks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ParkDescription",
                value: "The 147 acre Edgewater Park is the westernmost park in Cleveland Metroparks Lakefront Reservation. Edgewater Park features 9000 feet of shoreline, beaches, boat ramps,  fishing pier, picnic areas and grills. The park is both wheelchair accessible and dog friendly. Open daily 6am to 11pm. Located at 6500 Cleveland Memorial Shoreway in Cleveland");

            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 2,
                column: "ParkDescription",
                value: "Has thousands of acres covered in woods and offers many hiking trails and water features. There is also a full-service lodge and family campground with a pool. Hours of operation vary depending on area and is located at 3116 OH-3 in Loudonville,Ohio.");

            migrationBuilder.UpdateData(
                table: "Parks",
                keyColumn: "Id",
                keyValue: 3,
                column: "ParkDescription",
                value: "Kurtz  park in Cuyahoga County has an elevation of 856 feet and is situated west of Parma Heights, located near Brook Park Fire Department Station 4.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkDescription",
                table: "Parks");
        }
    }
}
