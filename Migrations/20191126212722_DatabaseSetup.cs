using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace Election_Votes_Display_Web_API.Migrations
{
    public partial class DatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateVote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Candidate = table.Column<string>(nullable: true),
                    Party = table.Column<string>(nullable: true),
                    NumberOfVotes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateVote", x => x.Id);
                });

            var sqlFile = Path.Combine(".\\DatabaseScripts", @"data.sql");

            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateVote");
        }
    }
}
