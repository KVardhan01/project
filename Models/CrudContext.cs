using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuhntctionCRUD.Models;

public partial class CrudContext : DbContext
{
    public CrudContext()
    {
    }

    public CrudContext(DbContextOptions<CrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Credential> Credentials { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<ManagerList> ManagerLists { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=crud;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Credential>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Credenti__3214EC0727CEF856");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Files_Id");

            entity.Property(e => e.FilePath)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ManagerList>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("pk_ManagerList_ManagerID");

            entity.ToTable("ManagerList");

            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ManagerName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Technology)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("pk_Students_StudentID");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.ManagerId).HasColumnName("ManagerID");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentEmail)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.StudentPassword)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Task)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Manager).WithMany(p => p.Students)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("fk_Students_ManagerID");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Tasks_Id");

            entity.Property(e => e.TaskName)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
