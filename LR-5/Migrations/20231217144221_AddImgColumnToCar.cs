using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LR_5.Migrations
{
    /// <inheritdoc />
    public partial class AddImgColumnToCar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "stud");

            migrationBuilder.AddColumn<byte[]>(
                name: "img",
                table: "car",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img",
                table: "car");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "stud",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
