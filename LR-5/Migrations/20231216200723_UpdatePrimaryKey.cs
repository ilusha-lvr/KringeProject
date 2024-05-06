using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LR_5.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "category",
                newName: "NameC");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "list_g",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NameC",
                table: "category",
                type: "character varying(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)[]",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "list_g");

            migrationBuilder.RenameColumn(
                name: "NameC",
                table: "category",
                newName: "name");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "category",
                type: "character varying(1)[]",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1)",
                oldNullable: true);
        }
    }
}
