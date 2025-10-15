using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComplexTypeBug.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TableWithComplexType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Enum = table.Column<int>(type: "integer", nullable: false),
                    Token0_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Token0_Name = table.Column<string>(type: "text", nullable: false),
                    Token1_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Token1_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableWithComplexType", x => new { x.Name, x.Value });
                });

            migrationBuilder.CreateTable(
                name: "TableWithSameComplexType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Token0_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Token0_Name = table.Column<string>(type: "text", nullable: false),
                    Token1_Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Token1_Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableWithSameComplexType", x => new { x.Name, x.Value });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableWithComplexType");

            migrationBuilder.DropTable(
                name: "TableWithSameComplexType");
        }
    }
}
