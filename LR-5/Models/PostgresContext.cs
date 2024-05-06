using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace LR_5.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }
    
    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Finance> Finances { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Instruct> Instructs { get; set; }

    public virtual DbSet<ListG> ListGs { get; set; }

    public virtual DbSet<Practical> Practicals { get; set; }

    public virtual DbSet<Rec> Recs { get; set; }

    public virtual DbSet<Stud> Studs { get; set; }

    public virtual DbSet<Teory> Teories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=00");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("car_pkey");

            entity.ToTable("car");

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.Brand)
                .HasMaxLength(20)
                .HasColumnName("brand");
            entity.Property(e => e.Model)
                .HasMaxLength(20)
                .HasColumnName("model");
            entity.Property(e => e.TypeC)
                .HasMaxLength(1)
                .HasColumnName("type_c");
            entity.Property(e => e.TypeKpp)
                .HasMaxLength(4)
                .HasColumnName("type_kpp");
            entity.Property(e => e.Img)
                .HasColumnType("bytea") 
                .HasColumnName("img");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.NameC)
                .HasColumnType("character varying(1)")
                .HasColumnName("NameC");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.TimeLes).HasColumnName("time_les");
            entity.Property(e => e.TimeP).HasColumnName("time_p");
            entity.Property(e => e.TimeT).HasColumnName("time_t");
            entity.Property(e => e.TypeKpp)
                .HasMaxLength(4)
                .HasColumnName("type_kpp");
        });

        modelBuilder.Entity<Finance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("finance");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.StudId).HasColumnName("stud_id");
            entity.Property(e => e.SumVn)
                .HasColumnType("money")
                .HasColumnName("sum_vn");
            entity.Property(e => e.TypePay)
                .HasMaxLength(1)
                .HasColumnName("type_pay");

            entity.HasOne(d => d.Cat).WithMany()
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("finance_cat_id_fkey");

            entity.HasOne(d => d.Stud).WithMany()
                .HasForeignKey(d => d.StudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("finance_stud_id_fkey");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("group_s_pkey");

            entity.ToTable("group_s");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.TypeGroup)
                .HasMaxLength(10)
                .HasColumnName("type_group");
        });

        modelBuilder.Entity<Instruct>(entity =>
        {
            entity.HasKey(e => e.InstId).HasName("instruct_pkey");

            entity.ToTable("instruct");

            entity.Property(e => e.InstId).HasColumnName("inst_id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.DateB).HasColumnName("date_b");
            entity.Property(e => e.Flat).HasColumnName("flat");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.House)
                .HasMaxLength(7)
                .HasColumnName("house");
            entity.Property(e => e.NameI)
                .HasMaxLength(20)
                .HasColumnName("name_i");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(30)
                .HasColumnName("otchestvo");
            entity.Property(e => e.PassNom)
                .HasMaxLength(4)
                .HasColumnName("pass_nom");
            entity.Property(e => e.PassSerial)
                .HasMaxLength(6)
                .HasColumnName("pass_serial");
            entity.Property(e => e.Street)
                .HasMaxLength(30)
                .HasColumnName("street");
            entity.Property(e => e.SurnameI)
                .HasMaxLength(20)
                .HasColumnName("surname_i");
        });

        modelBuilder.Entity<ListG>(entity =>
        {
            entity.ToTable("list_g");

            entity.HasKey(e => e.Id); // Указываем, что поле Id - первичный ключ

            entity.Property(e => e.IdGroup).HasColumnName("id_group");
            entity.Property(e => e.IdStud).HasColumnName("id_stud");

            entity.HasOne(d => d.IdGroupNavigation).WithMany()
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_group");

            entity.HasOne(d => d.IdStudNavigation).WithMany()
                .HasForeignKey(d => d.IdStud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_stud");
        });

        modelBuilder.Entity<Practical>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("practical");

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.DateL).HasColumnName("date_l");
            entity.Property(e => e.InstId).HasColumnName("inst_id");
            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.StudId).HasColumnName("stud_id");
            entity.Property(e => e.TimeL).HasColumnName("time_l");

            entity.HasOne(d => d.Car).WithMany()
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("practical_car_id_fkey");

            entity.HasOne(d => d.Inst).WithMany()
                .HasForeignKey(d => d.InstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("practical_inst_id_fkey");

            entity.HasOne(d => d.Rec).WithMany()
                .HasForeignKey(d => d.RecId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("practical_rec_id_fkey");

            entity.HasOne(d => d.Stud).WithMany()
                .HasForeignKey(d => d.StudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("practical_stud_id_fkey");
        });

        modelBuilder.Entity<Rec>(entity =>
        {
            entity.HasKey(e => e.RecId).HasName("rec_pkey");

            entity.ToTable("rec");

            entity.Property(e => e.RecId).HasColumnName("rec_id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.DateL).HasColumnName("date_l");
            entity.Property(e => e.InstId).HasColumnName("inst_id");
            entity.Property(e => e.StudId).HasColumnName("stud_id");
            entity.Property(e => e.TimeL).HasColumnName("time_l");

            entity.HasOne(d => d.Car).WithMany(p => p.Recs)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rec_car_id_fkey");

            entity.HasOne(d => d.Inst).WithMany(p => p.Recs)
                .HasForeignKey(d => d.InstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rec_inst_id_fkey");

            entity.HasOne(d => d.Stud).WithMany(p => p.Recs)
                .HasForeignKey(d => d.StudId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rec_stud_id_fkey");
        });

        modelBuilder.Entity<Stud>(entity =>
        {
            entity.HasKey(e => e.StudId).HasName("stud_pkey");

            entity.ToTable("stud");

            entity.Property(e => e.StudId).HasColumnName("stud_id");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.DateE).HasColumnName("date_e");
            entity.Property(e => e.DateS).HasColumnName("date_s");
            entity.Property(e => e.Exam).HasColumnName("exam");
            entity.Property(e => e.InstId).HasColumnName("inst_id");
            entity.Property(e => e.NameS)
                .HasMaxLength(20)
                .HasColumnName("name_s");
            entity.Property(e => e.Otchestvo)
                .HasMaxLength(30)
                .HasColumnName("otchestvo");
            entity.Property(e => e.Surname)
                .HasMaxLength(30)
                .HasColumnName("surname");

            entity.HasOne(d => d.Cat).WithMany(p => p.Studs)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stud_cat_id_fkey");

            entity.HasOne(d => d.Inst).WithMany(p => p.Studs)
                .HasForeignKey(d => d.InstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("stud_inst_id_fkey");
        });

        modelBuilder.Entity<Teory>(entity =>
        {
            entity
                
                .ToTable("teory");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DateL).HasColumnName("date_l");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.TimeL).HasColumnName("time_l");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teory_group_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "users_username_key").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.NameP)
                .HasMaxLength(255)
                .HasColumnName("name_p");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasColumnName("role");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .HasColumnName("surname");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");
            entity.Property(e => e.IdUs).HasColumnName("id_us");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
