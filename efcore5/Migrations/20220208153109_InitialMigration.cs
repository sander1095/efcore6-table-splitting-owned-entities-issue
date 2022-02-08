using Microsoft.EntityFrameworkCore.Migrations;

namespace efcore5.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SomeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Something = table.Column<int>(type: "int", nullable: false),
                    FooEntityId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<int>(type: "int", nullable: false),
                    SomePropertyInOwnedType = table.Column<int>(type: "int", nullable: true),
                    JustSomePropertyInDerivedDerivedClass = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SomeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SomeEntity_Foo_FooEntityId",
                        column: x => x.FooEntityId,
                        principalTable: "Foo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SomeEntity_FooEntityId",
                table: "SomeEntity",
                column: "FooEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SomeEntity");

            migrationBuilder.DropTable(
                name: "Foo");
        }
    }
}
