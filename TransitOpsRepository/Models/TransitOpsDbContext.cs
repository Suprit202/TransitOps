using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TransitOpsRepository.Models;

public partial class TransitOpsDbContext : DbContext
{
    public TransitOpsDbContext()
    {
    }

    public TransitOpsDbContext(DbContextOptions<TransitOpsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppSetting> AppSettings { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<DistanceUnit> DistanceUnits { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverStatus> DriverStatuses { get; set; }

    public virtual DbSet<FuelLog> FuelLogs { get; set; }

    public virtual DbSet<MaintenanceLog> MaintenanceLogs { get; set; }

    public virtual DbSet<MaintenanceStatus> MaintenanceStatuses { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripExpense> TripExpenses { get; set; }

    public virtual DbSet<TripStatus> TripStatuses { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleStatus> VehicleStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppSetti__3214EC073FB5F862");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.DepotName).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Currency).WithMany(p => p.AppSettings)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AppSettin__Curre__778AC167");

            entity.HasOne(d => d.DistanceUnit).WithMany(p => p.AppSettings)
                .HasForeignKey(d => d.DistanceUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AppSettin__Dista__787EE5A0");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Currenci__3214EC07AA2CA37C");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<DistanceUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Distance__3214EC078E92B90A");

            entity.Property(e => e.Name).HasMaxLength(10);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drivers__3214EC071AB1B311");

            entity.HasIndex(e => e.LicenseNumber, "UQ__Drivers__E889016626D3D71C").IsUnique();

            entity.Property(e => e.ContactNumber).HasMaxLength(20);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.LicenseCategory).HasMaxLength(20);
            entity.Property(e => e.LicenseNumber).HasMaxLength(50);
            entity.Property(e => e.SafetyScore)
                .HasDefaultValue(100m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Status).WithMany(p => p.Drivers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Drivers__StatusI__5EBF139D");
        });

        modelBuilder.Entity<DriverStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DriverSt__3214EC075963F631");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<FuelLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FuelLogs__3214EC07AAC5E458");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Liters).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Vehicle).WithMany(p => p.FuelLogs)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FuelLogs__Vehicl__6E01572D");
        });

        modelBuilder.Entity<MaintenanceLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC075F7B4C44");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.ServiceType).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Status).WithMany(p => p.MaintenanceLogs)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__Statu__6A30C649");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.MaintenanceLogs)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__Vehic__693CA210");
        });

        modelBuilder.Entity<MaintenanceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Maintena__3214EC078E3FDEF0");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Trips__3214EC074C2A1713");

            entity.HasIndex(e => e.TripCode, "UQ__Trips__4992CD16BE904045").IsUnique();

            entity.Property(e => e.CargoWeight).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.Destination).HasMaxLength(100);
            entity.Property(e => e.PlannedDistance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Source).HasMaxLength(100);
            entity.Property(e => e.TripCode).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DriverId)
                .HasConstraintName("FK__Trips__DriverId__6477ECF3");

            entity.HasOne(d => d.Status).WithMany(p => p.Trips)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Trips__StatusId__656C112C");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Trips)
                .HasForeignKey(d => d.VehicleId)
                .HasConstraintName("FK__Trips__VehicleId__6383C8BA");
        });

        modelBuilder.Entity<TripExpense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TripExpe__3214EC079E5030E7");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.OtherCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TollCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);

            entity.HasOne(d => d.Trip).WithMany(p => p.TripExpenses)
                .HasForeignKey(d => d.TripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TripExpen__TripI__73BA3083");
        });

        modelBuilder.Entity<TripStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TripStat__3214EC07F29AB7B3");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehicles__3214EC070A54CCE1");

            entity.HasIndex(e => e.RegistrationNumber, "UQ__Vehicles__E8864602D3D949D5").IsUnique();

            entity.Property(e => e.AcquisitionCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CapacityKg).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(450);
            entity.Property(e => e.ModelName).HasMaxLength(100);
            entity.Property(e => e.Odometer).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RegistrationNumber).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(450);
            entity.Property(e => e.VehicleType).HasMaxLength(50);

            entity.HasOne(d => d.Status).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vehicles__Status__59063A47");
        });

        modelBuilder.Entity<VehicleStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VehicleS__3214EC0749FCEFFF");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
