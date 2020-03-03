using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupWebApplication.Migrations
{
    public partial class Addvotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "imagedbcontext",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Explanation = table.Column<string>(nullable: true),
                    Media_Type = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Hdurl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagedbcontext", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "votedbcontext",
                columns: table => new
                {
                    Date = table.Column<string>(nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_votedbcontext", x => x.Date);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imagedbcontext");

            migrationBuilder.DropTable(
                name: "votedbcontext");
        }
    }
}
