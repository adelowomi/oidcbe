using System;
using Core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
