using CourierPackage_API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CourierPackage_API.Data
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }

        public DbSet<Location> locations { get; set; }
        public DbSet<BoxDimension> boxDimensions { get; set; }
        public DbSet<BoxType> boxType { get; set; }
        public DbSet<DeliveryFeedback> deliveryFeedback { get; set; }
        public DbSet<District> district { get; set; }
        public DbSet<Driver> driver { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Notification> notification { get; set; }
        public DbSet<PackageMaster> packageMaster { get; set; }
        public DbSet<PackageRoute> packageRoute { get; set; }
        public DbSet<PackageStatus> packageStatus { get; set; }
        public DbSet<PackageVerification> packageVerification { get; set; }
        public DbSet<Province> province { get; set; }
        public DbSet<Recipient> recipient { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Vehicle> vehicle { get; set; }
        public DbSet<VehicleType> vehicleType { get; set; }
        public DbSet<Warehouse> warehouses { get; set; }
        public DbSet<RefreshToken> refreshTokens { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");
            });

            modelBuilder.Entity<BoxType>(entity =>
            {
                entity.ToTable("BoxType");
            });

            modelBuilder.Entity<BoxDimension>(entity =>
            {
                entity.ToTable("BoxDimension");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("District");
            });

            modelBuilder.Entity<PackageStatus>(entity =>
            {
                entity.ToTable("PackageStatus");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.ToTable("VehicleType");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.HasOne(e => e.Package)
                      .WithMany(e => e.Notifications)
                      .HasForeignKey(e => e.PackageId);
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.HasOne(e => e.Employee)
                      .WithOne(e => e.Driver)
                      .HasForeignKey<Driver>(e => e.EmployeeId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasOne(e => e.Warehouse)
                      .WithOne(e => e.Employee)
                      .HasForeignKey<Employee>(e => e.WarehouseId);

                entity.HasOne(e => e.User)
                      .WithOne(e => e.Employee)
                      .HasForeignKey<Employee>(e => e.UserId);
            });

            modelBuilder.Entity<DeliveryFeedback>(entity =>
            {
                entity.ToTable("DeliveryFeedback");

                entity.HasOne(e => e.PackageRoute)
                      .WithOne(e => e.DeliveryFeedback)
                      .HasForeignKey<DeliveryFeedback>(e => e.PackageRouteId);
            });

            modelBuilder.Entity<PackageMaster>(entity =>
            {
                entity.ToTable("PackageMaster");

                entity.HasOne(e => e.BoxType)
                    .WithMany(e => e.PackageMaster)
                    .HasForeignKey(e => e.BoxTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.BoxDimension)
                    .WithMany(e => e.PackageMaster)
                    .HasForeignKey(e => e.BoxDimensionId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Sender)
                    .WithMany()
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Recipient)
                    .WithMany()
                    .HasForeignKey(e => e.RecipientId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.PackageStatus)
                    .WithMany()
                    .HasForeignKey(e => e.StatusId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.SourceWarehouse)
                    .WithMany()
                    .HasForeignKey(e => e.HandOverWarehouseId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.DestinationWarehouse)
                    .WithMany()
                    .HasForeignKey(e => e.DestinationId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PackageRoute>(entity =>
            {
                entity.ToTable("PackageRoute");

                entity.HasOne(e => e.PackageMaster)
                    .WithMany()
                    .HasForeignKey(e => e.PackageId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.SourceWarehouse)
                    .WithMany()
                    .HasForeignKey(e => e.SourceWarehouseId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.DestinationWarehouse)
                    .WithMany()
                    .HasForeignKey(e => e.DestinationWarehouseId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Driver)
                    .WithMany()
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Vehicle)
                    .WithMany()
                    .HasForeignKey(e => e.VehicleId)
                    .OnDelete(DeleteBehavior.NoAction);

                
            });

            modelBuilder.Entity<PackageVerification>(entity =>
            {
                entity.ToTable("PackageVerification");

                // Recipient -> User
                entity.HasOne(e => e.Package)
                    .WithOne( e => e.PackageVerification )
                    .HasForeignKey<PackageVerification>(e => e.PackageId)
                    .OnDelete(DeleteBehavior.NoAction);

                
            });



            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<UserLocation>(entity =>
            {
                entity.ToTable("UserLocation");

                entity.HasOne(e => e.User)
                    .WithMany(e => e.UserLocations)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.Province)
                    .WithMany(e => e.UserLocation)
                    .HasForeignKey(e => e.ProvinceId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(e => e.District)
                    .WithMany(e => e.UserLocations)
                    .HasForeignKey(e => e.DistrictId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Recipient>(entity =>
            {
                entity.ToTable("Recipient");

                entity.HasKey(e => e.RecipientId);

                // Recipient -> User
                entity.HasOne(e => e.Sender)
                    .WithMany()
                    .HasForeignKey(e => e.SenderId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Recipient -> Sender
                entity.HasOne(e => e.Receiver)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicle");

                // Recipient -> User
                entity.HasOne(e => e.VehicleType)
                    .WithMany()
                    .HasForeignKey(e => e.VehicleTypeId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Recipient -> Sender
                entity.HasOne(e => e.Driver)
                    .WithMany()
                    .HasForeignKey(e => e.DriverId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.HasKey(e => e.WarehouseId);

                entity.HasOne(e => e.Province)
                    .WithMany(e=> e.Warehouses)
                    .HasForeignKey(e => e.ProvinceId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.RefreshToken)
                    .HasForeignKey<RefreshToken>(e => e.UserId);
            });
        }
    }
}
