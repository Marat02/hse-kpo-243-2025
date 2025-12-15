using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KPO.Example.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityCounts",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityCounts", x => x.Name);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityCounts");
        }
    }
}
