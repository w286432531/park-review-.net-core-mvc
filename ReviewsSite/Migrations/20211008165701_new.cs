using Microsoft.EntityFrameworkCore.Migrations;

namespace ReviewsSite.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasHandicapAccess = table.Column<bool>(type: "bit", nullable: false),
                    IsDogFriendly = table.Column<bool>(type: "bit", nullable: false),
                    ParkType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkId = table.Column<int>(type: "int", nullable: false),
                    ReviewerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StarRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Parks_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Parks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "HasHandicapAccess", "IsDogFriendly", "Name", "ParkType" },
                values: new object[] { 1, true, true, "Edgewater", "Beach" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "HasHandicapAccess", "IsDogFriendly", "Name", "ParkType" },
                values: new object[] { 2, false, true, "Mohican", "River" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "Id", "HasHandicapAccess", "IsDogFriendly", "Name", "ParkType" },
                values: new object[] { 3, false, false, "Kurtz", "Sport" });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ParkId",
                table: "Reviews",
                column: "ParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
