using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.DAL;

public partial class TaskDbContext : DbContext
{
    public TaskDbContext()
    {
    }

    public TaskDbContext(DbContextOptions<TaskDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PRAKASH-I5PC\\SQLEXPRESS;Database=WiproTest;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D17792B4F0");

            entity.Property(e => e.TaskId).HasColumnName("TaskID");
            entity.Property(e => e.AssignedTo).HasMaxLength(100);
            entity.Property(e => e.CompletionStatus).HasMaxLength(50);
            entity.Property(e => e.TaskDescription).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
