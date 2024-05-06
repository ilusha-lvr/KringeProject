using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LR_5.Migrations
{
    /// <inheritdoc />
    public partial class AddIdUsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_catalog.adminpack", ",,");

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    brand = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    model = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    type_c = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    type_kpp = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("car_pkey", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    cat_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time_t = table.Column<int>(type: "integer", nullable: false),
                    time_p = table.Column<int>(type: "integer", nullable: false),
                    type_kpp = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    time_les = table.Column<int>(type: "integer", nullable: false),
                    NameC = table.Column<string>(type: "character varying(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_pkey", x => x.cat_id);
                });

            migrationBuilder.CreateTable(
                name: "group_s",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_group = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("group_s_pkey", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "instruct",
                columns: table => new
                {
                    inst_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    surname_i = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    name_i = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    otchestvo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    gender = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    date_b = table.Column<DateOnly>(type: "date", nullable: false),
                    city = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    street = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    house = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    flat = table.Column<int>(type: "integer", nullable: false),
                    pass_nom = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    pass_serial = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("instruct_pkey", x => x.inst_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    username = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name_p = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    role = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    id_us = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "teory",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false),
                    date_l = table.Column<DateOnly>(type: "date", nullable: false),
                    time_l = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "teory_group_id_fkey",
                        column: x => x.group_id,
                        principalTable: "group_s",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "stud",
                columns: table => new
                {
                    stud_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cat_id = table.Column<int>(type: "integer", nullable: false),
                    inst_id = table.Column<int>(type: "integer", nullable: false),
                    surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    name_s = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    otchestvo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    date_s = table.Column<DateOnly>(type: "date", nullable: false),
                    date_e = table.Column<DateOnly>(type: "date", nullable: true),
                    exam = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("stud_pkey", x => x.stud_id);
                    table.ForeignKey(
                        name: "stud_cat_id_fkey",
                        column: x => x.cat_id,
                        principalTable: "category",
                        principalColumn: "cat_id");
                    table.ForeignKey(
                        name: "stud_inst_id_fkey",
                        column: x => x.inst_id,
                        principalTable: "instruct",
                        principalColumn: "inst_id");
                });

            migrationBuilder.CreateTable(
                name: "finance",
                columns: table => new
                {
                    stud_id = table.Column<int>(type: "integer", nullable: false),
                    cat_id = table.Column<int>(type: "integer", nullable: false),
                    sum_vn = table.Column<decimal>(type: "money", nullable: false),
                    type_pay = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "finance_cat_id_fkey",
                        column: x => x.cat_id,
                        principalTable: "category",
                        principalColumn: "cat_id");
                    table.ForeignKey(
                        name: "finance_stud_id_fkey",
                        column: x => x.stud_id,
                        principalTable: "stud",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateTable(
                name: "list_g",
                columns: table => new
                {
                    id_stud = table.Column<int>(type: "integer", nullable: false),
                    id_group = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "id_group",
                        column: x => x.id_group,
                        principalTable: "group_s",
                        principalColumn: "group_id");
                    table.ForeignKey(
                        name: "id_stud",
                        column: x => x.id_stud,
                        principalTable: "stud",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateTable(
                name: "rec",
                columns: table => new
                {
                    rec_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    stud_id = table.Column<int>(type: "integer", nullable: false),
                    inst_id = table.Column<int>(type: "integer", nullable: false),
                    car_id = table.Column<int>(type: "integer", nullable: false),
                    date_l = table.Column<DateOnly>(type: "date", nullable: false),
                    time_l = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("rec_pkey", x => x.rec_id);
                    table.ForeignKey(
                        name: "rec_car_id_fkey",
                        column: x => x.car_id,
                        principalTable: "car",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "rec_inst_id_fkey",
                        column: x => x.inst_id,
                        principalTable: "instruct",
                        principalColumn: "inst_id");
                    table.ForeignKey(
                        name: "rec_stud_id_fkey",
                        column: x => x.stud_id,
                        principalTable: "stud",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateTable(
                name: "practical",
                columns: table => new
                {
                    rec_id = table.Column<int>(type: "integer", nullable: false),
                    stud_id = table.Column<int>(type: "integer", nullable: false),
                    inst_id = table.Column<int>(type: "integer", nullable: false),
                    car_id = table.Column<int>(type: "integer", nullable: false),
                    date_l = table.Column<DateOnly>(type: "date", nullable: false),
                    time_l = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "practical_car_id_fkey",
                        column: x => x.car_id,
                        principalTable: "car",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "practical_inst_id_fkey",
                        column: x => x.inst_id,
                        principalTable: "instruct",
                        principalColumn: "inst_id");
                    table.ForeignKey(
                        name: "practical_rec_id_fkey",
                        column: x => x.rec_id,
                        principalTable: "rec",
                        principalColumn: "rec_id");
                    table.ForeignKey(
                        name: "practical_stud_id_fkey",
                        column: x => x.stud_id,
                        principalTable: "stud",
                        principalColumn: "stud_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_finance_cat_id",
                table: "finance",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_finance_stud_id",
                table: "finance",
                column: "stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_list_g_id_group",
                table: "list_g",
                column: "id_group");

            migrationBuilder.CreateIndex(
                name: "IX_list_g_id_stud",
                table: "list_g",
                column: "id_stud");

            migrationBuilder.CreateIndex(
                name: "IX_practical_car_id",
                table: "practical",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_practical_inst_id",
                table: "practical",
                column: "inst_id");

            migrationBuilder.CreateIndex(
                name: "IX_practical_rec_id",
                table: "practical",
                column: "rec_id");

            migrationBuilder.CreateIndex(
                name: "IX_practical_stud_id",
                table: "practical",
                column: "stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_rec_car_id",
                table: "rec",
                column: "car_id");

            migrationBuilder.CreateIndex(
                name: "IX_rec_inst_id",
                table: "rec",
                column: "inst_id");

            migrationBuilder.CreateIndex(
                name: "IX_rec_stud_id",
                table: "rec",
                column: "stud_id");

            migrationBuilder.CreateIndex(
                name: "IX_stud_cat_id",
                table: "stud",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "IX_stud_inst_id",
                table: "stud",
                column: "inst_id");

            migrationBuilder.CreateIndex(
                name: "IX_teory_group_id",
                table: "teory",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "users_username_key",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "finance");

            migrationBuilder.DropTable(
                name: "list_g");

            migrationBuilder.DropTable(
                name: "practical");

            migrationBuilder.DropTable(
                name: "teory");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "rec");

            migrationBuilder.DropTable(
                name: "group_s");

            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "stud");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "instruct");
        }
    }
}
