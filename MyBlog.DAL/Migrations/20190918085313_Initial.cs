using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBlog.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(maxLength: 256, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Description" },
                values: new object[] { 1, "Örnek Kategori", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "UserName", "UserType" },
                values: new object[] { 1, "yigith1@gmail.com", "ACAWW+FoPY72mKNQrrsCs7UOJp4cV3TgKqVTLWmi+8XrzrEx9r9NCpjhenjoUoZWCg==", "yigith1@gmail.com", 1 });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "Title" },
                values: new object[] { 1, 1, 1, "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ut pretium elit. Praesent nec mi sit amet leo mollis venenatis. Vivamus scelerisque ipsum a nunc varius, in dictum justo lacinia. Sed sit amet dui quis nisl aliquam dictum ut ut urna. Nunc risus ante, accumsan et mattis sit amet, elementum a lorem. Quisque est ante, fermentum ac efficitur eu, bibendum non risus. Donec accumsan enim id fringilla accumsan. Mauris ligula velit, viverra ut tempus vel, ullamcorper eget nulla. Praesent commodo mauris nisi, in aliquam tortor varius sit amet. Curabitur porta venenatis nulla id pellentesque. Ut tellus erat, sodales eu fermentum at, sollicitudin in nibh.</p><p>Nullam molestie, lectus at congue interdum, odio augue faucibus magna, quis lacinia sem quam eu sem. Aenean vel finibus est. In semper semper convallis. Maecenas non tincidunt est. Suspendisse ut nulla vel est blandit bibendum a sed sem. Nam ut risus velit. Vestibulum ipsum tellus, ornare at gravida non, luctus nec turpis. Suspendisse potenti. Sed turpis libero, facilisis vitae justo et, sollicitudin lacinia massa. Nam ac ornare urna, id pulvinar ante.</p><p>Vivamus facilisis vehicula ante auctor convallis. Donec iaculis, enim vel fringilla rhoncus, dui quam congue erat, sit amet gravida tellus ligula quis mauris. Suspendisse aliquet metus nibh, non efficitur urna consequat a. Etiam efficitur quam a maximus scelerisque. Vestibulum pellentesque interdum faucibus. Suspendisse potenti. Vivamus ut dui eu tellus interdum maximus in quis eros. Aliquam molestie lacus odio, quis maximus risus cursus eget.</p>", "Örnek Yazı 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "Title" },
                values: new object[] { 2, 1, 1, "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ut pretium elit. Praesent nec mi sit amet leo mollis venenatis. Vivamus scelerisque ipsum a nunc varius, in dictum justo lacinia. Sed sit amet dui quis nisl aliquam dictum ut ut urna. Nunc risus ante, accumsan et mattis sit amet, elementum a lorem. Quisque est ante, fermentum ac efficitur eu, bibendum non risus. Donec accumsan enim id fringilla accumsan. Mauris ligula velit, viverra ut tempus vel, ullamcorper eget nulla. Praesent commodo mauris nisi, in aliquam tortor varius sit amet. Curabitur porta venenatis nulla id pellentesque. Ut tellus erat, sodales eu fermentum at, sollicitudin in nibh.</p><p>Nullam molestie, lectus at congue interdum, odio augue faucibus magna, quis lacinia sem quam eu sem. Aenean vel finibus est. In semper semper convallis. Maecenas non tincidunt est. Suspendisse ut nulla vel est blandit bibendum a sed sem. Nam ut risus velit. Vestibulum ipsum tellus, ornare at gravida non, luctus nec turpis. Suspendisse potenti. Sed turpis libero, facilisis vitae justo et, sollicitudin lacinia massa. Nam ac ornare urna, id pulvinar ante.</p><p>Vivamus facilisis vehicula ante auctor convallis. Donec iaculis, enim vel fringilla rhoncus, dui quam congue erat, sit amet gravida tellus ligula quis mauris. Suspendisse aliquet metus nibh, non efficitur urna consequat a. Etiam efficitur quam a maximus scelerisque. Vestibulum pellentesque interdum faucibus. Suspendisse potenti. Vivamus ut dui eu tellus interdum maximus in quis eros. Aliquam molestie lacus odio, quis maximus risus cursus eget.</p>", "Örnek Yazı 2" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
