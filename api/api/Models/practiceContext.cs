﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class practiceContext : DbContext
    {
        public practiceContext()
        {
        }

        public practiceContext(DbContextOptions<practiceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserView> view_User { get; set; } = null!;

        public virtual DbSet<TblOwner> TblOwners { get; set; } = null!;
        public virtual DbSet<TblPet> TblPets { get; set; } = null!;
        public virtual DbSet<TblProcedure> TblProcedures { get; set; } = null!;
        public virtual DbSet<TblTreatment> TblTreatments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblOwner>(entity =>
            {
entity.HasKey(c => new { c.Ownerid });

                entity.ToTable("tbl_Owner");

                entity.Property(e => e.Ownerid).HasColumnName("OWNERID");

                entity.Property(e => e.Admin).HasColumnName("ADMIN");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phone).HasColumnName("PHONE");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<TblPet>(entity =>
            {
                entity.HasKey(e => new { e.Petname, e.Ownerid })
                    .HasName("PK__tbl_Pet__5DAB9CE8CB8859C4");

                entity.ToTable("tbl_Pet");

                entity.Property(e => e.Petname)
                    .HasMaxLength(50)
                    .HasColumnName("PETNAME");

                entity.Property(e => e.Ownerid).HasColumnName("OWNERID");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<TblProcedure>(entity =>
            {
                entity.HasKey(e => e.Procedureid)
                    .HasName("PK__tbl_Proc__4A5CE30D70041202");

                entity.ToTable("tbl_Procedure");

                entity.Property(e => e.Procedureid)
                    .ValueGeneratedNever()
                    .HasColumnName("PROCEDUREID");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("PRICE");
            });

            modelBuilder.Entity<TblTreatment>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.Procedureid, e.Petname, e.Ownerid })
                    .HasName("PK__tbl_Trea__32841568C7FB646E");

                entity.ToTable("tbl_Treatment");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("DATE");

                entity.Property(e => e.Procedureid).HasColumnName("PROCEDUREID");

                entity.Property(e => e.Petname)
                    .HasMaxLength(50)
                    .HasColumnName("PETNAME");

                entity.Property(e => e.Ownerid).HasColumnName("OWNERID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(150)
                    .HasColumnName("NOTES");

                entity.Property(e => e.Payment)
                    .HasMaxLength(50)
                    .HasColumnName("PAYMENT");

                entity.HasOne(d => d.Procedure)
                    .WithMany(p => p.TblTreatments)
                    .HasForeignKey(d => d.Procedureid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Treat__PROCE__2FCF1A8A");

                entity.HasOne(d => d.TblPet)
                    .WithMany(p => p.TblTreatments)
                    .HasForeignKey(d => new { d.Petname, d.Ownerid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tbl_Treatment__30C33EC3");
            });

        modelBuilder.Entity<UserView>(entity =>
        {
            entity.HasNoKey();

            entity.ToView("view_User");

            entity.Property(e => e.Username).HasMaxLength(35);

            entity.Property(e => e.Password).HasMaxLength(35);
            
            entity.Property(e => e.Admin).HasMaxLength(35);
        });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
