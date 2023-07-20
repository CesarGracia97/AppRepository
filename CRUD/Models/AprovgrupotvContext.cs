using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models;

public partial class AprovgrupotvContext : DbContext
{
    public AprovgrupotvContext()
    {
    }

    public AprovgrupotvContext(DbContextOptions<AprovgrupotvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppsApplication> AppsApplications { get; set; }

    public virtual DbSet<AppsScheme> AppsSchemes { get; set; }

    public virtual DbSet<AppsSchemeApp> AppsSchemeApps { get; set; }

    public virtual DbSet<AppsUser> AppsUsers { get; set; }

    public virtual DbSet<AppsUserSchemeApp> AppsUserSchemeApps { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<AppsApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("apps_applications");

            entity.Property(e => e.Id)
                .HasColumnType("int(9)")
                .HasColumnName("id");
            entity.Property(e => e.DescriptionApplication)
                .HasMaxLength(20)
                .HasColumnName("description_application");
            entity.Property(e => e.NameApplication)
                .HasMaxLength(20)
                .HasColumnName("name_application");
        });

        modelBuilder.Entity<AppsScheme>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("apps_scheme");

            entity.Property(e => e.Id)
                .HasColumnType("int(9)")
                .HasColumnName("id");
            entity.Property(e => e.DescriptionScheme)
                .HasMaxLength(20)
                .HasColumnName("description_scheme");
            entity.Property(e => e.NameScheme)
                .HasMaxLength(20)
                .HasColumnName("name_scheme");
        });

        modelBuilder.Entity<AppsSchemeApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("apps_scheme_apps");

            entity.Property(e => e.Id)
                .HasComment("Clave primaria")
                .HasColumnType("int(9)")
                .HasColumnName("id");
            entity.Property(e => e.IdAppsApps)
                .HasMaxLength(50)
                .HasComment("id usuario")
                .HasColumnName("id_apps_apps");
            entity.Property(e => e.IdAppsScheme)
                .HasMaxLength(20)
                .HasComment("id esquema")
                .HasColumnName("id_apps_scheme");
        });

        modelBuilder.Entity<AppsUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("apps_user");

            entity.Property(e => e.Id)
                .HasComment("Clave primaria")
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AppsDescritionUser)
                .HasMaxLength(20)
                .HasColumnName("apps_descrition_user");
            entity.Property(e => e.AppsFullNames)
                .HasMaxLength(50)
                .HasComment("id usuario")
                .HasColumnName("apps_full_names");
            entity.Property(e => e.AppsUser1)
                .HasMaxLength(20)
                .HasComment("id esquema")
                .HasColumnName("apps_user");
        });

        modelBuilder.Entity<AppsUserSchemeApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("apps_user_scheme_apps");

            entity.Property(e => e.Id)
                .HasComment("Clave primaria")
                .HasColumnType("int(9)")
                .HasColumnName("id");
            entity.Property(e => e.IdAppsSchemeApps)
                .HasMaxLength(20)
                .HasComment("id esquema")
                .HasColumnName("id_apps_scheme_apps");
            entity.Property(e => e.IdAppsUser)
                .HasMaxLength(50)
                .HasComment("id usuario")
                .HasColumnName("id_apps_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
