using Microsoft.EntityFrameworkCore.Migrations;

namespace MUSACA.Migrations
{
    public partial class Total_To_decimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Total",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
