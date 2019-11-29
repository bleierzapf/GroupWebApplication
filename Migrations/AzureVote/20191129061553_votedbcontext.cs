using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupWebApplication.Migrations.AzureVote
{
    public partial class votedbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels");

            migrationBuilder.RenameTable(
                name: "ImageModels",
                newName: "votedbcontext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_votedbcontext",
                table: "votedbcontext",
                column: "ImageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_votedbcontext",
                table: "votedbcontext");

            migrationBuilder.RenameTable(
                name: "votedbcontext",
                newName: "ImageModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels",
                column: "ImageID");
        }
    }
}
