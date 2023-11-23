using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RandevuSistemi.Data.Migrations
{
    /// <inheritdoc />
    public partial class calisan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Kuaforler_KuaforId",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<int>(
                name: "KuaforId",
                table: "Calisanlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Kuaforler_KuaforId",
                table: "Calisanlar",
                column: "KuaforId",
                principalTable: "Kuaforler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calisanlar_Kuaforler_KuaforId",
                table: "Calisanlar");

            migrationBuilder.AlterColumn<int>(
                name: "KuaforId",
                table: "Calisanlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Calisanlar_Kuaforler_KuaforId",
                table: "Calisanlar",
                column: "KuaforId",
                principalTable: "Kuaforler",
                principalColumn: "Id");
        }
    }
}
