using Microsoft.EntityFrameworkCore.Migrations;

namespace RestApiTestEFCore.Migrations
{
    public partial class CreateRestApiTestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestApiTests",
                columns: table => new
                {
                    RestApiTestId = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequestPath = table.Column<string>(nullable: true),
                    RequestBody = table.Column<string>(nullable: true),
                    ExpectedResponseStatusCode = table.Column<int>(nullable: false),
                    ExectedResponseJsonSchema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestApiTests", x => x.RestApiTestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestApiTests");
        }
    }
}
