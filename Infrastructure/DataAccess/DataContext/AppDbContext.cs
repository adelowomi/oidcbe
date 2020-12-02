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

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<SubscriptionStatus> SubscriptionStatuses { get; set; }

        public DbSet<DocumentStatus> DocumentStatuses { get; set; }

        public DbSet<WorkOrder> WorkOrders { get; set; }

        public DbSet<WorkOrderType> WorkOrderTypes { get; set; }

        public DbSet<Calendar> Calendars { get; set; }

        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        public DbSet<Mobilization> Mobilizations { get; set; }

        public DbSet<Permit> Permits { get; set; }

        public DbSet<PermitType> PermitTypes { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
