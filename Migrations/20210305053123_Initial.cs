using Microsoft.EntityFrameworkCore.Migrations;

namespace dataTransfer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameID);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GameID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SportID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Countries_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "GameID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Countries_Sports_SportID",
                        column: x => x.SportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameID", "GameName" },
                values: new object[,]
                {
                    { "wint", "Winter Olympics" },
                    { "summ", "Summer Olympics" },
                    { "para", "Paralympics" },
                    { "youth", "Youth Olympic Games" }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportID", "SportName" },
                values: new object[,]
                {
                    { "curl", "Curling/Indoor" },
                    { "bobsleigh", "Bobsleigh/Outdoor" },
                    { "dive", "Diving/Indoor" },
                    { "cycling", "Road Cycling/Outdoor" },
                    { "archery", "Archery/Indoor" },
                    { "canoe", "Canoe Sprint/Outdoor" },
                    { "dance", "Breakdancing/Indoor" },
                    { "skateboard", "Skateboarding/Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "CountryName", "FlagImage", "GameID", "SportID" },
                values: new object[,]
                {
                    { "CA", "Canada", "CA.png", "wint", "curl" },
                    { "FI", "Finland", "FI.png", "youth", "skateboard" },
                    { "RU", "Russia", "RU.png", "youth", "dance" },
                    { "CY", "Cyprus", "CY.png", "youth", "dance" },
                    { "FR", "France", "FR.png", "youth", "dance" },
                    { "ZI", "Zimbabwe", "ZI.png", "para", "canoe" },
                    { "PK", "Pakistan", "PK.png", "para", "canoe" },
                    { "AT", "Austria", "AT.png", "para", "canoe" },
                    { "UA", "Ukraine", "UA.png", "para", "archery" },
                    { "UY", "Uruguay", "UY.png", "para", "archery" },
                    { "TH", "Thailand", "TH.png", "para", "archery" },
                    { "US", "United States", "US.png", "summ", "cycling" },
                    { "NL", "Netherlands", "NL.png", "summ", "cycling" },
                    { "BR", "Brazil", "BR.png", "summ", "cycling" },
                    { "MX", "Mexico", "MX.png", "summ", "dive" },
                    { "CN", "China", "CN.png", "summ", "dive" },
                    { "GA", "Germany", "GA.png", "summ", "dive" },
                    { "JP", "Japan", "JP.png", "wint", "bobsleigh" },
                    { "IL", "Italy", "IL.png", "wint", "bobsleigh" },
                    { "JA", "Jamaica", "JA.png", "wint", "bobsleigh" },
                    { "GB", "Great Britain", "GB.png", "wint", "curl" },
                    { "SW", "Sweden", "SW.png", "wint", "curl" },
                    { "SK", "Slovakia", "SK.png", "youth", "skateboard" },
                    { "PT", "Portugal", "PT.png", "youth", "skateboard" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_GameID",
                table: "Countries",
                column: "GameID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_SportID",
                table: "Countries",
                column: "SportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
