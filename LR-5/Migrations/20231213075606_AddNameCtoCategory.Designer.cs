﻿// <auto-generated />
using System;
using LR_5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LR_5.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20231213075606_AddNameCtoCategory")]
    partial class AddNameCtoCategory
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pg_catalog", "adminpack");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LR_5.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("car_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CarId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("brand");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("model");

                    b.Property<string>("TypeC")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("type_c");

                    b.Property<string>("TypeKpp")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("type_kpp");

                    b.HasKey("CarId")
                        .HasName("car_pkey");

                    b.ToTable("car", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cat_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CatId"));

                    b.Property<string>("NameC")
                        .HasColumnType("character varying(1)")
                        .HasColumnName("NameC");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.Property<int>("TimeLes")
                        .HasColumnType("integer")
                        .HasColumnName("time_les");

                    b.Property<int>("TimeP")
                        .HasColumnType("integer")
                        .HasColumnName("time_p");

                    b.Property<int>("TimeT")
                        .HasColumnType("integer")
                        .HasColumnName("time_t");

                    b.Property<string>("TypeKpp")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("type_kpp");

                    b.HasKey("CatId")
                        .HasName("category_pkey");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Finance", b =>
                {
                    b.Property<int>("CatId")
                        .HasColumnType("integer")
                        .HasColumnName("cat_id");

                    b.Property<int>("StudId")
                        .HasColumnType("integer")
                        .HasColumnName("stud_id");

                    b.Property<decimal>("SumVn")
                        .HasColumnType("money")
                        .HasColumnName("sum_vn");

                    b.Property<string>("TypePay")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("type_pay");

                    b.HasIndex("CatId");

                    b.HasIndex("StudId");

                    b.ToTable("finance", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GroupId"));

                    b.Property<string>("TypeGroup")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("type_group");

                    b.HasKey("GroupId")
                        .HasName("group_s_pkey");

                    b.ToTable("group_s", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Instruct", b =>
                {
                    b.Property<int>("InstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("inst_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("city");

                    b.Property<DateOnly>("DateB")
                        .HasColumnType("date")
                        .HasColumnName("date_b");

                    b.Property<int>("Flat")
                        .HasColumnType("integer")
                        .HasColumnName("flat");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)")
                        .HasColumnName("gender");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)")
                        .HasColumnName("house");

                    b.Property<string>("NameI")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name_i");

                    b.Property<string>("Otchestvo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("otchestvo");

                    b.Property<string>("PassNom")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)")
                        .HasColumnName("pass_nom");

                    b.Property<string>("PassSerial")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("character varying(6)")
                        .HasColumnName("pass_serial");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("street");

                    b.Property<string>("SurnameI")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("surname_i");

                    b.HasKey("InstId")
                        .HasName("instruct_pkey");

                    b.ToTable("instruct", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.ListG", b =>
                {
                    b.Property<int>("IdGroup")
                        .HasColumnType("integer")
                        .HasColumnName("id_group");

                    b.Property<int>("IdStud")
                        .HasColumnType("integer")
                        .HasColumnName("id_stud");

                    b.HasIndex("IdGroup");

                    b.HasIndex("IdStud");

                    b.ToTable("list_g", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Practical", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("integer")
                        .HasColumnName("car_id");

                    b.Property<DateOnly>("DateL")
                        .HasColumnType("date")
                        .HasColumnName("date_l");

                    b.Property<int>("InstId")
                        .HasColumnType("integer")
                        .HasColumnName("inst_id");

                    b.Property<int>("RecId")
                        .HasColumnType("integer")
                        .HasColumnName("rec_id");

                    b.Property<int>("StudId")
                        .HasColumnType("integer")
                        .HasColumnName("stud_id");

                    b.Property<TimeOnly>("TimeL")
                        .HasColumnType("time without time zone")
                        .HasColumnName("time_l");

                    b.HasIndex("CarId");

                    b.HasIndex("InstId");

                    b.HasIndex("RecId");

                    b.HasIndex("StudId");

                    b.ToTable("practical", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Rec", b =>
                {
                    b.Property<int>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("rec_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RecId"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer")
                        .HasColumnName("car_id");

                    b.Property<DateOnly>("DateL")
                        .HasColumnType("date")
                        .HasColumnName("date_l");

                    b.Property<int>("InstId")
                        .HasColumnType("integer")
                        .HasColumnName("inst_id");

                    b.Property<int>("StudId")
                        .HasColumnType("integer")
                        .HasColumnName("stud_id");

                    b.Property<TimeOnly>("TimeL")
                        .HasColumnType("time without time zone")
                        .HasColumnName("time_l");

                    b.HasKey("RecId")
                        .HasName("rec_pkey");

                    b.HasIndex("CarId");

                    b.HasIndex("InstId");

                    b.HasIndex("StudId");

                    b.ToTable("rec", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Stud", b =>
                {
                    b.Property<int>("StudId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("stud_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudId"));

                    b.Property<int>("CatId")
                        .HasColumnType("integer")
                        .HasColumnName("cat_id");

                    b.Property<DateOnly?>("DateE")
                        .HasColumnType("date")
                        .HasColumnName("date_e");

                    b.Property<DateOnly>("DateS")
                        .HasColumnType("date")
                        .HasColumnName("date_s");

                    b.Property<bool>("Exam")
                        .HasColumnType("boolean")
                        .HasColumnName("exam");

                    b.Property<int>("InstId")
                        .HasColumnType("integer")
                        .HasColumnName("inst_id");

                    b.Property<string>("NameS")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name_s");

                    b.Property<string>("Otchestvo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("otchestvo");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("surname");

                    b.HasKey("StudId")
                        .HasName("stud_pkey");

                    b.HasIndex("CatId");

                    b.HasIndex("InstId");

                    b.ToTable("stud", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Teory", b =>
                {
                    b.Property<DateOnly>("DateL")
                        .HasColumnType("date")
                        .HasColumnName("date_l");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<TimeOnly>("TimeL")
                        .HasColumnType("time without time zone")
                        .HasColumnName("time_l");

                    b.HasIndex("GroupId");

                    b.ToTable("teory", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int?>("IdUs")
                        .HasColumnType("integer")
                        .HasColumnName("id_us");

                    b.Property<string>("NameP")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("name_p");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("role");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("surname");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("username");

                    b.HasKey("UserId")
                        .HasName("users_pkey");

                    b.HasIndex(new[] { "Username" }, "users_username_key")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("LR_5.Models.Finance", b =>
                {
                    b.HasOne("LR_5.Models.Category", "Cat")
                        .WithMany()
                        .HasForeignKey("CatId")
                        .IsRequired()
                        .HasConstraintName("finance_cat_id_fkey");

                    b.HasOne("LR_5.Models.Stud", "Stud")
                        .WithMany()
                        .HasForeignKey("StudId")
                        .IsRequired()
                        .HasConstraintName("finance_stud_id_fkey");

                    b.Navigation("Cat");

                    b.Navigation("Stud");
                });

            modelBuilder.Entity("LR_5.Models.ListG", b =>
                {
                    b.HasOne("LR_5.Models.Group", "IdGroupNavigation")
                        .WithMany()
                        .HasForeignKey("IdGroup")
                        .IsRequired()
                        .HasConstraintName("id_group");

                    b.HasOne("LR_5.Models.Stud", "IdStudNavigation")
                        .WithMany()
                        .HasForeignKey("IdStud")
                        .IsRequired()
                        .HasConstraintName("id_stud");

                    b.Navigation("IdGroupNavigation");

                    b.Navigation("IdStudNavigation");
                });

            modelBuilder.Entity("LR_5.Models.Practical", b =>
                {
                    b.HasOne("LR_5.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("practical_car_id_fkey");

                    b.HasOne("LR_5.Models.Instruct", "Inst")
                        .WithMany()
                        .HasForeignKey("InstId")
                        .IsRequired()
                        .HasConstraintName("practical_inst_id_fkey");

                    b.HasOne("LR_5.Models.Rec", "Rec")
                        .WithMany()
                        .HasForeignKey("RecId")
                        .IsRequired()
                        .HasConstraintName("practical_rec_id_fkey");

                    b.HasOne("LR_5.Models.Stud", "Stud")
                        .WithMany()
                        .HasForeignKey("StudId")
                        .IsRequired()
                        .HasConstraintName("practical_stud_id_fkey");

                    b.Navigation("Car");

                    b.Navigation("Inst");

                    b.Navigation("Rec");

                    b.Navigation("Stud");
                });

            modelBuilder.Entity("LR_5.Models.Rec", b =>
                {
                    b.HasOne("LR_5.Models.Car", "Car")
                        .WithMany("Recs")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("rec_car_id_fkey");

                    b.HasOne("LR_5.Models.Instruct", "Inst")
                        .WithMany("Recs")
                        .HasForeignKey("InstId")
                        .IsRequired()
                        .HasConstraintName("rec_inst_id_fkey");

                    b.HasOne("LR_5.Models.Stud", "Stud")
                        .WithMany("Recs")
                        .HasForeignKey("StudId")
                        .IsRequired()
                        .HasConstraintName("rec_stud_id_fkey");

                    b.Navigation("Car");

                    b.Navigation("Inst");

                    b.Navigation("Stud");
                });

            modelBuilder.Entity("LR_5.Models.Stud", b =>
                {
                    b.HasOne("LR_5.Models.Category", "Cat")
                        .WithMany("Studs")
                        .HasForeignKey("CatId")
                        .IsRequired()
                        .HasConstraintName("stud_cat_id_fkey");

                    b.HasOne("LR_5.Models.Instruct", "Inst")
                        .WithMany("Studs")
                        .HasForeignKey("InstId")
                        .IsRequired()
                        .HasConstraintName("stud_inst_id_fkey");

                    b.Navigation("Cat");

                    b.Navigation("Inst");
                });

            modelBuilder.Entity("LR_5.Models.Teory", b =>
                {
                    b.HasOne("LR_5.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .IsRequired()
                        .HasConstraintName("teory_group_id_fkey");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("LR_5.Models.Car", b =>
                {
                    b.Navigation("Recs");
                });

            modelBuilder.Entity("LR_5.Models.Category", b =>
                {
                    b.Navigation("Studs");
                });

            modelBuilder.Entity("LR_5.Models.Instruct", b =>
                {
                    b.Navigation("Recs");

                    b.Navigation("Studs");
                });

            modelBuilder.Entity("LR_5.Models.Stud", b =>
                {
                    b.Navigation("Recs");
                });
#pragma warning restore 612, 618
        }
    }
}
