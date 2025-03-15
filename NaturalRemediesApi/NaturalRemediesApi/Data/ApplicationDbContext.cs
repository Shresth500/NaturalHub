using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NaturalRemediesApi.Models;
using NaturalRemediesApi.Models.Domain;

namespace NaturalRemediesApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<NaturalRemedies> NaturalRemedies{ get; set; }
        public DbSet<Diseases> Diseases { get; set; }
        public DbSet<Remedies> Remedies { get; set; }
        public DbSet<HealthTips> HealthTips { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "a71a55d6-99d7-4123-b4e0-1218ecb90e3e";
            var writerRoleId = "c309fa92-2123-47be-b397-a1c77adb502c";
            var adminRoleId = "b78d4f92-56c8-4f33-8b59-9a1d7b23f15a";
            var userRoleId = "d73b4f98-62d9-4g38-9c60-8b2e6a12e14b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<Carts>().HasKey(a => new {a.ApplicationUserId , a.ProductsId });
            //builder.Entity<Orders>().HasKey(a => new { a.ApplicationUserId});
            builder.Entity<OrderItems>().HasKey(a => new { a.OrdersId, a.ProductsId });

            builder.Entity<Remedies>().HasKey(a => new {a.NaturalRemediesId,a.DiseasesId});

            builder.Entity<Carts>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(b => b.Carts)
                .HasForeignKey(a => a.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Carts>()
                .HasOne(a => a.Products)
                .WithMany(b => b.Carts)
                .HasForeignKey(c => c.ProductsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Orders>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(b => b.Orders)
                .HasForeignKey(a => a.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItems>()
                .HasOne(a => a.Products)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(a => a.ProductsId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderItems>()
                .HasOne(a => a.Orders)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(a => a.OrdersId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Remedies>()
                .HasOne(a => a.NaturalRemedies)
                .WithMany(b => b.Remedies)
                .HasForeignKey(a => a.NaturalRemediesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Remedies>()
                .HasOne(a => a.Diseases)
                .WithMany(b => b.Remedies)
                .HasForeignKey(a => a.DiseasesId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<HealthTips>()
                .HasOne(a => a.Diseases)
                .WithMany(b => b.HealthTips)
                .HasForeignKey(a => a.DiseaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
