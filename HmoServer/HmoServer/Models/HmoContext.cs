using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HmoServer.Models;

public partial class HmoContext : DbContext
{
    public HmoContext()
    {
    }

    public HmoContext(DbContextOptions<HmoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoronaDetail> CoronaDetails { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V70NGAP;Database=HMO;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoronaDetail>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.FirstVaccinationManufacturer)
                .HasMaxLength(50)
                .HasColumnName("first_vaccination_manufacturer");
            entity.Property(e => e.FirstVaccitionDate)
                .HasColumnType("datetime")
                .HasColumnName("first_vaccition_date");
            entity.Property(e => e.ForthVaccinationManufacturer)
                .HasMaxLength(50)
                .HasColumnName("forth_vaccination_manufacturer");
            entity.Property(e => e.ForthVaccitionDate)
                .HasColumnType("datetime")
                .HasColumnName("forth_vaccition_date");
            entity.Property(e => e.PositiveResultDate)
                .HasColumnType("datetime")
                .HasColumnName("positive_result_date");
            entity.Property(e => e.RecoveryDate)
                .HasColumnType("datetime")
                .HasColumnName("recovery_date");
            entity.Property(e => e.SecondVaccinationManufacturer)
                .HasMaxLength(50)
                .HasColumnName("second_vaccination_manufacturer");
            entity.Property(e => e.SecondVaccitionDate)
                .HasColumnType("datetime")
                .HasColumnName("second_vaccition_date");
            entity.Property(e => e.ThirdVaccinationManufacturer)
                .HasMaxLength(50)
                .HasColumnName("third_vaccination_manufacturer");
            entity.Property(e => e.ThirdVaccitionDate)
                .HasColumnType("datetime")
                .HasColumnName("third_vaccition_date");

            entity.HasOne(d => d.Customer).WithMany(p => p.CoronaDetails)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CoronaDetails_Customers");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("customer_id");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birth_date");
            entity.Property(e => e.CellPhone)
                .HasMaxLength(50)
                .HasColumnName("cell_phone");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.HouseNumber).HasColumnName("house_number");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
