using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiTestEFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestApis",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: false),
                    BaseUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestApis", x => x.Name);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestApis");
        }
    }
}
