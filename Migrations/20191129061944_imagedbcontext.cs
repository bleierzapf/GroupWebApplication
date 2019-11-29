using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupWebApplication.Migrations
{
    public partial class imagedbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels");

            migrationBuilder.RenameTable(
                name: "ImageModels",
                newName: "imagedbcontext");

            migrationBuilder.AddPrimaryKey(
                name: "PK_imagedbcontext",
                table: "imagedbcontext",
                column: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_imagedbcontext",
                table: "imagedbcontext");

            migrationBuilder.RenameTable(
                name: "imagedbcontext",
                newName: "ImageModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageModels",
                table: "ImageModels",
                column: "Date");
        }
    }
}
