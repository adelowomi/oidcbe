using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public DbSet<MobilizationStatus> MobilizationStatuses { get; set; }

        public DbSet<Permit> Permits { get; set; }

        public DbSet<PermitType> PermitTypes { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<Forum> Forums { get; set; }

        public DbSet<ForumSubscription> ForumSubscriptions { get; set; }

        public DbSet<ForumMessage> ForumMessages { get; set; }

        public DbSet<PermitStatus> PermitStatuses { get; set; }

        public DbSet<ForumMessageType> ForumMessageTypes { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<MessageType> MessageTypes { get; set; }

        public DbSet<MessageIndicator> MessageIndicators { get; set; }

        public DbSet<MessageStatus> MessageStatuses { get; set; }

        public DbSet<Proposal> Proposals { get; set; }

        public DbSet<ProposalStatus> ProposalStatuses { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<JobType> JobTypes { get; set; }

        public DbSet<JobStatus> JobStatuses { get; set; }

        public DbSet<PaymentInstalment> PaymentInstalments { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<PaymentCycle> PaymentCycles { get; set; }

        public DbSet<PaymentAllocation> PaymentAllocations { get; set; }

        public DbSet<Account> Accounts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
