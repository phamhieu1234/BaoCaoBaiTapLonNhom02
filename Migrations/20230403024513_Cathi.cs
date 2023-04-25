using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaoCaoBaiTapLonNhom02.Migrations
{
    /// <inheritdoc />
    public partial class Cathi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaCathi",
                table: "SinhVien",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cathi",
                columns: table => new
                {
                    MaCathi = table.Column<string>(type: "TEXT", nullable: false),
                    TenCathi = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cathi", x => x.MaCathi);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SinhVien_MaCathi",
                table: "SinhVien",
                column: "MaCathi");

            migrationBuilder.AddForeignKey(
                name: "FK_SinhVien_Cathi_MaCathi",
                table: "SinhVien",
                column: "MaCathi",
                principalTable: "Cathi",
                principalColumn: "MaCathi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SinhVien_Cathi_MaCathi",
                table: "SinhVien");

            migrationBuilder.DropTable(
                name: "Cathi");

            migrationBuilder.DropIndex(
                name: "IX_SinhVien_MaCathi",
                table: "SinhVien");

            migrationBuilder.DropColumn(
                name: "MaCathi",
                table: "SinhVien");
        }
    }
}
