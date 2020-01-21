using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcBootstrap_CoreMvc.Migrations
{
    public partial class FirstDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[] { 1, "RD", "no@gmail.com", "0912-422231", "Kevin", "專員" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[] { 2, "RD", "no@gmail.com", "0912-422231", "Lissa", "助理" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[] { 3, "RD", "no@gmail.com", "0912-422231", "Sheldon", "老闆" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[] { 4, "RD", "no@gmail.com", "0912-422231", "Amy", "客服" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "Email", "Mobile", "Name", "Title" },
                values: new object[] { 5, "RD", "no@gmail.com", "0912-422231", "Penny", "寫手" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
