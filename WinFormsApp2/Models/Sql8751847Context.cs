using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WinFormsApp2.Models;

public partial class Sql8751847Context : DbContext
{
    public Sql8751847Context()
    {
    }

    public Sql8751847Context(DbContextOptions<Sql8751847Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Day> Days { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<LectureNumber> LectureNumbers { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TypesClassroom> TypesClassrooms { get; set; }

    public virtual DbSet<TypesLecture> TypesLectures { get; set; }

    public virtual DbSet<Week> Weeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=sql8751847", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.IdClassroom).HasName("PRIMARY");

            entity
                .ToTable("classrooms")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdClassroom, "id_Classrooms_UNIQUE").IsUnique();

            entity.Property(e => e.IdClassroom).HasColumnName("id_Classroom");
            entity.Property(e => e.NumberClassroom).HasColumnName("Number_classroom");
            entity.Property(e => e.NumberOfSeats).HasColumnName("Number_of_seats");

            entity.HasMany(d => d.TypesClassroomsIdTypeClassrooms).WithMany(p => p.ClassroomsIdClassrooms)
                .UsingEntity<Dictionary<string, object>>(
                    "ClassroomsHasTypesClassroom",
                    r => r.HasOne<TypesClassroom>().WithMany()
                        .HasForeignKey("TypesClassroomsIdTypeClassroom")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Classrooms_has_Types_classrooms_Types_classrooms1"),
                    l => l.HasOne<Classroom>().WithMany()
                        .HasForeignKey("ClassroomsIdClassrooms")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Classrooms_has_Types_classrooms_Classrooms1"),
                    j =>
                    {
                        j.HasKey("ClassroomsIdClassrooms", "TypesClassroomsIdTypeClassroom")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j
                            .ToTable("classrooms_has_types_classrooms")
                            .HasCharSet("utf8mb3")
                            .UseCollation("utf8mb3_general_ci");
                        j.HasIndex(new[] { "ClassroomsIdClassrooms" }, "fk_Classrooms_has_Types_classrooms_Classrooms1_idx");
                        j.HasIndex(new[] { "TypesClassroomsIdTypeClassroom" }, "fk_Classrooms_has_Types_classrooms_Types_classrooms1_idx");
                        j.IndexerProperty<int>("ClassroomsIdClassrooms").HasColumnName("Classrooms_id_Classrooms");
                        j.IndexerProperty<int>("TypesClassroomsIdTypeClassroom").HasColumnName("Types_classrooms_id_Type_classroom");
                    });
        });

        modelBuilder.Entity<Day>(entity =>
        {
            entity.HasKey(e => e.IdDay).HasName("PRIMARY");

            entity
                .ToTable("days")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdDay, "id_Day_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdWeek, "key_Week_idx");

            entity.Property(e => e.IdDay).HasColumnName("id_Day");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(20)
                .HasColumnName("Day_of_Week");
            entity.Property(e => e.IdWeek).HasColumnName("id_Week");

            entity.HasOne(d => d.IdWeekNavigation).WithMany(p => p.Days)
                .HasForeignKey(d => d.IdWeek)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Week");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.IdGroup).HasName("PRIMARY");

            entity
                .ToTable("groups")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdGroup, "id_Group_UNIQUE").IsUnique();

            entity.Property(e => e.IdGroup).HasColumnName("id_Group");
            entity.Property(e => e.NameOfGroup)
                .HasMaxLength(50)
                .HasColumnName("name_of_Group");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.HasKey(e => new { e.IdLectureNumber, e.IdGroup, e.IdDay, e.IdSubject, e.IdTeacher, e.IdClassrooms, e.IdTypeLecture, e.IdLectures })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0, 0, 0, 0, 0 });

            entity
                .ToTable("lectures")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdClassrooms, "key_Classroom_idx");

            entity.HasIndex(e => e.IdDay, "key_Day_idx");

            entity.HasIndex(e => e.IdGroup, "key_Group_idx");

            entity.HasIndex(e => e.IdSubject, "key_Subject_idx");

            entity.HasIndex(e => e.IdTeacher, "key_Teacher_idx");

            entity.HasIndex(e => e.IdTypeLecture, "key_Type_lecture_idx");

            entity.Property(e => e.IdLectureNumber).HasColumnName("id_Lecture_number");
            entity.Property(e => e.IdGroup).HasColumnName("id_Group");
            entity.Property(e => e.IdDay).HasColumnName("id_Day");
            entity.Property(e => e.IdSubject).HasColumnName("id_Subject");
            entity.Property(e => e.IdTeacher).HasColumnName("id_Teacher");
            entity.Property(e => e.IdClassrooms).HasColumnName("id_Classrooms");
            entity.Property(e => e.IdTypeLecture).HasColumnName("id_Type_lecture");
            entity.Property(e => e.IdLectures).HasColumnName("id_Lectures");

            entity.HasOne(d => d.IdClassroomsNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdClassrooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Classroom");

            entity.HasOne(d => d.IdDayNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdDay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Day");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Group");

            entity.HasOne(d => d.IdLectureNumberNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdLectureNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Lecture_number");

            entity.HasOne(d => d.IdSubjectNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Subject");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Teacher");

            entity.HasOne(d => d.IdTypeLectureNavigation).WithMany(p => p.Lectures)
                .HasForeignKey(d => d.IdTypeLecture)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Type_lecture");
        });

        modelBuilder.Entity<LectureNumber>(entity =>
        {
            entity.HasKey(e => e.IdLectureNumber).HasName("PRIMARY");

            entity
                .ToTable("lecture_numbers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdLectureNumber, "id_Lecture_number_UNIQUE").IsUnique();

            entity.Property(e => e.IdLectureNumber).HasColumnName("id_Lecture_number");
            entity.Property(e => e.NumberOfLecture).HasColumnName("Number_of_lecture");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.IdSemester).HasName("PRIMARY");

            entity
                .ToTable("semesters")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdSemester, "idnew_table_UNIQUE").IsUnique();

            entity.Property(e => e.IdSemester).HasColumnName("id_Semester");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .HasColumnName("date");
            entity.Property(e => e.NumberSemester).HasColumnName("number_semester");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.IdSubject).HasName("PRIMARY");

            entity
                .ToTable("subjects")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdSubject, "id_Subject_UNIQUE").IsUnique();

            entity.Property(e => e.IdSubject).HasColumnName("id_Subject");
            entity.Property(e => e.HoursConsultation).HasColumnName("Hours_consultation");
            entity.Property(e => e.HoursExam).HasColumnName("Hours_exam");
            entity.Property(e => e.HoursLaboratory).HasColumnName("Hours_laboratory");
            entity.Property(e => e.HoursLecture).HasColumnName("Hours_lecture");
            entity.Property(e => e.HoursPractices).HasColumnName("Hours_practices");
            entity.Property(e => e.NameSubject)
                .HasMaxLength(45)
                .HasColumnName("Name_Subject");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.IdTeacher).HasName("PRIMARY");

            entity
                .ToTable("teachers")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdTeacher, "id_Teacher_UNIQUE").IsUnique();

            entity.Property(e => e.IdTeacher).HasColumnName("id_Teacher");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_name");
            entity.Property(e => e.Status).HasMaxLength(45);
        });

        modelBuilder.Entity<TypesClassroom>(entity =>
        {
            entity.HasKey(e => e.IdTypeClassroom).HasName("PRIMARY");

            entity
                .ToTable("types_classrooms")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdTypeClassroom, "id_Type_classroom_UNIQUE").IsUnique();

            entity.Property(e => e.IdTypeClassroom).HasColumnName("id_Type_classroom");
            entity.Property(e => e.NameOfType)
                .HasMaxLength(45)
                .HasColumnName("Name_of_type");
        });

        modelBuilder.Entity<TypesLecture>(entity =>
        {
            entity.HasKey(e => e.IdTypeLecture).HasName("PRIMARY");

            entity
                .ToTable("types_lectures")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdTypeLecture, "id_Type_lecture_UNIQUE").IsUnique();

            entity.Property(e => e.IdTypeLecture).HasColumnName("id_Type_lecture");
            entity.Property(e => e.TitleLecturec)
                .HasMaxLength(45)
                .HasColumnName("Title_lecturec");
        });

        modelBuilder.Entity<Week>(entity =>
        {
            entity.HasKey(e => e.IdWeek).HasName("PRIMARY");

            entity
                .ToTable("weeks")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IdWeek, "id_Week_UNIQUE").IsUnique();

            entity.HasIndex(e => e.IdSemester, "key_Semesters_idx");

            entity.Property(e => e.IdWeek).HasColumnName("id_Week");
            entity.Property(e => e.IdSemester).HasColumnName("id_Semester");
            entity.Property(e => e.NumberWeek).HasColumnName("number_Week");

            entity.HasOne(d => d.IdSemesterNavigation).WithMany(p => p.Weeks)
                .HasForeignKey(d => d.IdSemester)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("key_Semesters");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
