using System;
using Core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace Infrastructure.DataAccess.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUserType> AppUserTypes { get; set; }

        public DbSet<OTP> OTPs { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<Plot> Plots { get; set; }

        public DbSet<PlotType> PlotTypes { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<OfferStatus> OfferStatuses { get; set; }

        public DbSet<OrganizationType> OrganizationTypes { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        public DbSet<PaymentProvider> PaymentProviders { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<NextOfKin> NextOfKins { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Subscriber> Subscribers { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AppUser>().HasData(
            //    new AppUser
            //    {

            //    }
            //);
        }
    }
}
