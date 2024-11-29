using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myApp.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Did = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DLocation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Did);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    St_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    St_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    St_age = table.Column<int>(type: "int", nullable: false),
                    St_address = table.Column<short>(type: "smallint", maxLength: 50, nullable: false),
                    Dept_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.St_id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_Dept_id",
                        column: x => x.Dept_id,
                        principalTable: "Departments",
                        principalColumn: "Did");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_Dept_id",
                table: "Students",
                column: "Dept_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
