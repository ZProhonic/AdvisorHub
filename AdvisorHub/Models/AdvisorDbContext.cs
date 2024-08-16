using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AdvisorHub.Models;

public partial class AdvisorDbContext : DbContext
{
    public AdvisorDbContext()
    {
    }

    public AdvisorDbContext(DbContextOptions<AdvisorDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Advisor> Advisors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Advisor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Advisors__3214EC0767E68DB4");

            entity.Property(e => e.AdditionalRepIds)
                .HasMaxLength(50)
                .HasColumnName("AdditionalRepIDs");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Crd).HasColumnName("CRD");
            entity.Property(e => e.EmailAddress).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.IsHybrid).HasDefaultValue(false);
            entity.Property(e => e.Last4Ssn)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Last4SSN");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Licenses).HasMaxLength(10);
            entity.Property(e => e.NonOsj)
                .HasMaxLength(50)
                .HasColumnName("NonOSJ");
            entity.Property(e => e.Osj)
                .HasMaxLength(50)
                .HasColumnName("OSJ");
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.RepId)
                .HasMaxLength(10)
                .HasColumnName("RepID");
            entity.Property(e => e.RiaId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RiaName).HasMaxLength(70);
            entity.Property(e => e.StateRegistrations).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
