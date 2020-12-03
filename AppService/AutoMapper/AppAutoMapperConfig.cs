using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AutoMapper;
using Core.Model;

namespace AppService.AutoMapper
{
    public class AppAutoMapperConfig : Profile
    {
        protected readonly AppSettings _settings;

        public AppAutoMapperConfig(AppSettings settings)
        {
            _settings = settings;

            CreateMap<Gender, GenderViewModel>()
                .ForMember(dest => dest.GenderId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.GenderName, opts => opts.MapFrom(src => src.Name))
                ;

            CreateMap<AppUser, RegisterViewModel>()
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.ConcurrencyStamp, opts => opts.MapFrom(src => src.ConcurrencyStamp ))
                ;

            CreateMap<AppUser, UserViewModel>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opts => opts.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender.Name))
                .ForMember(dest => dest.PhotoUrl, opts => opts.MapFrom(src => $"{settings.BaseUrl}/api/assets/photo?id={src.Id}"))
                .ForMember(dest => dest.DocumentUrl, opts => opts.MapFrom(src => $"{settings.BaseUrl}/api/assets/document?id={src.Id}"))
                .ForMember(dest => dest.HasConfirmedEmail, opts => opts.MapFrom(src => src.EmailConfirmed))
                .ForMember(dest => dest.HasUploadedProfilePhoto, opts => opts.MapFrom(src => src.HasUploadedProfilePhoto))
                .ForMember(dest => dest.HasUploadedDocument, opts => opts.MapFrom(src => src.HasUploadedDocument))
                .ForMember(dest => dest.UserTypeId, opts => opts.MapFrom(src => src.OrganizationTypeId))
                ;

            CreateMap<AppUser, VendorViewModel>()
                 .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                 .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                 .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                 .ForMember(dest => dest.MiddleName, opts => opts.MapFrom(src => src.MiddleName))
                 .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email))
                 .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                 .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender.Name))
                 .ForMember(dest => dest.NameOfEntry, opts => opts.MapFrom(src => src.EntryName))
                 .ForMember(dest => dest.PhotoUrl, opts => opts.MapFrom(src => $"{settings.BaseUrl}/api/assets/photo?id={src.Id}"))
                 .ForMember(dest => dest.DocumentUrl, opts => opts.MapFrom(src => $"{settings.BaseUrl}/api/assets/document?id={src.Id}"))
                 .ForMember(dest => dest.HasConfirmedEmail, opts => opts.MapFrom(src => src.EmailConfirmed))
                 .ForMember(dest => dest.HasUploadedProfilePhoto, opts => opts.MapFrom(src => src.HasUploadedProfilePhoto))
                 .ForMember(dest => dest.HasUploadedDocument, opts => opts.MapFrom(src => src.HasUploadedDocument))
                 ;

            CreateMap<Document, DocumentViewModel>()
               .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.DocumentName, opts => opts.MapFrom(src => src.Name))
               .ForMember(dest => dest.Link, opts => opts.MapFrom(src => $"{settings.BaseUrl}/api/documents/link?name={src.Name}"))
               .ForMember(dest => dest.DocumentType, opts => opts.MapFrom(src => src.DocumentType.Name))
               .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.DateCreated))
               .ForMember(dest => dest.DateModified, opts => opts.MapFrom(src => src.DateModified))

               ;

            CreateMap<DocumentInputModel, Document>()
               .ForMember(dest => dest.AppUserId, opts => opts.MapFrom(src => src.UserId))
               .ForMember(dest => dest.DocumentTypeId, opts => opts.MapFrom(src => src.DocumentType))
               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Document))
               .ForMember(dest => dest.DocumentType, opts => opts.Ignore())
               ;

            CreateMap<VendorInputModel, AppUser>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.Gender, opts => opts.Ignore())
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.MiddleName, opts => opts.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.ResidentialAddress, opts => opts.MapFrom(src => src.ResidentialAddress))
                .ForMember(dest => dest.MailingAddress, opts => opts.MapFrom(src => src.MailingAddress))
                .ForMember(dest => dest.OfficeAddress, opts => opts.MapFrom(src => src.OfficeAddress))
                .ForMember(dest => dest.EntryName, opts => opts.MapFrom(src => src.NameOfEntry))
                .ForMember(dest => dest.WebsiteUrl, opts => opts.MapFrom(src => src.WebSiteUrl))
                .ForMember(dest => dest.RCNumber, opts => opts.MapFrom(src => src.RCNumber))
                ;
            CreateMap<VendorNextOfKinInputModel, NextOfKin>()
                .ForMember(dest => dest.Gender, opts => opts.Ignore())
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.Address))
                ;

            
            CreateMap<Subscription, SubscriptionViewModel>()
                .ForMember(dest => dest.SubscriptionId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.SubscriptionStatus.Name))
                .ForMember(dest => dest.Amount, opts => opts.MapFrom(src => src.Offer.Plot.Price))
                .ForMember(dest => dest.OrganizationType, opts => opts.MapFrom(src => src.OrganizationType.Name))
                ;

            CreateMap<Payment, PaymentViewModel>()
                .ForMember(dest => dest.PaymentMethod, opts => opts.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.PaymentType, opts => opts.MapFrom(src => src.PaymentType.Name))
                .ForMember(dest => dest.PaymentProvider, opts => opts.MapFrom(src => src.PaymentProvider.Name))
                .ForMember(dest => dest.PaymentStatus, opts => opts.MapFrom(src => src.PaymentStatus.Name))
                .ForMember(dest => dest.Subscription, opts => opts.MapFrom(src => src.Subscription))
            
            ;

            CreateMap<Offer, OfferViewModel>()
                .ForMember(dest => dest.OfferStatus, opts => opts.MapFrom(src => src.OfferStatus.Name))
                .ForMember(dest => dest.IsPaymentCompleted, opts => opts.MapFrom(src => src.IsPaymentCompleted))
                ;

            CreateMap<Plot, PlotViewModel>()
                .ForMember(dest => dest.Acres, opts => opts.MapFrom(src => src.Acres))
                .ForMember(dest => dest.PlotName, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.DatePurchased, opts => opts.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.PlotType, opts => opts.MapFrom(src => src.PlotType.Name))
                .ForMember(dest => dest.PlotId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.PlotAddresss, opts => opts.MapFrom(src => src.Address))
                .ForMember(dest => dest.Lattitude, opts => opts.MapFrom(src => src.Lattitude))
                .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.PlotStatus.Name))
                //.ForMember(dest => dest.Calendars, opts => opts.MapFrom(src => src.Calendars))
                ;

            CreateMap<PlotInputModel, Plot>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.PlotName))
                .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.PlotAddresss))
                .ForMember(dest => dest.PlotTypeId, opts => opts.MapFrom(src => src.PlotTypeId))
                .ForMember(dest => dest.Acres, opts => opts.MapFrom(src => src.PlotAcres))
                .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Lattitude, opts => opts.MapFrom(src => src.Lattitude))
                .ForMember(dest => dest.KilometerSquare, opts => opts.MapFrom(src => src.KilometerSquare))
                .ForMember(dest => dest.Price, opts => opts.MapFrom(src => src.Amount))
                ;

            CreateMap<NextOfKin, VendorNextOfKinInputModel>()
               .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender))
               .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
               .ForMember(dest => dest.PhoneNumber, opts => opts.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.Address, opts => opts.MapFrom(src => src.Address))
               ;

            CreateMap<State, StateViewModel>()
                .ForMember(dest => dest.StateId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.StateName, opts => opts.MapFrom(src => src.Name))
                ;

            CreateMap<WorkOrder, WorkOrderViewModel>()
               
                .ForMember(dest => dest.PlotId, opts => opts.MapFrom(src => src.PlotId))
                .ForMember(dest => dest.WorkOrderType, opts => opts.MapFrom(src => src.WorkOrderType.Name))
                .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.DateModified, opts => opts.MapFrom(src => src.DateModified))
                ;

            CreateMap<WorkOrderInputModel, WorkOrder>()
                .ForMember(dest => dest.PlotId, opts => opts.MapFrom(src => src.PlotId))
                .ForMember(dest => dest.AppUserId, opts => opts.MapFrom(src => src.AppUserId))
                .ForMember(dest => dest.WorkOrderTypeId, opts => opts.MapFrom(src => src.WorkOrderTypeId))
                ;


            CreateMap<WorkOrderType, WorkOrderTypeViewModel>()
               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.DateCreated))
               .ForMember(dest => dest.DateModified, opts => opts.MapFrom(src => src.DateModified))
               .ForMember(dest => dest.IsActive, opts => opts.MapFrom(src => src.IsEnabled))
               ;

            CreateMap<Calendar, CalendarViewModel>()
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
               .ForMember(dest => dest.Note, opts => opts.MapFrom(src => src.Note))
               .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.DateCreated))
               .ForMember(dest => dest.Event, opts => opts.MapFrom(src => src.CalendarEvent.Name))
               .ForMember(dest => dest.IsActive, opts => opts.MapFrom(src => src.IsEnabled))
               ;

            CreateMap<PaymentProvider, PaymentProviderViewModel>().ForMember(dest => dest.PaymentProviderName, opts => opts.MapFrom(src => src.Name));
            CreateMap<PaymentType, PaymentTypeViewModel>().ForMember(dest => dest.PaymentTypeName, opts => opts.MapFrom(src => src.Name));
            CreateMap<PaymentMethod, PaymentMethodViewModel>().ForMember(dest => dest.PaymentMethodName, opts => opts.MapFrom(src => src.Name));
            CreateMap<PaymentStatus, PaymentStatusViewModel>().ForMember(dest => dest.PaymentStatusName, opts => opts.MapFrom(src => src.Name));
            CreateMap<CalendarEvent, CalendarEventViewModel>().ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));
            CreateMap<MobilizationInputModel, Mobilization>();
            CreateMap<Mobilization, MobilizationViewModel>();

            CreateMap<CalendarInputModel, Calendar>()
              .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
              .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.Date))
              .ForMember(dest => dest.Note, opts => opts.MapFrom(src => src.Note))
              .ForMember(dest => dest.CalendarEventId, opts => opts.MapFrom(src => src.EventTypeId))
              .ForMember(dest => dest.PlotId, opts => opts.MapFrom(src => src.PlotId))
              ;

            CreateMap<PlotType, PlotTypeViewModel>()
             .ForMember(dest => dest.PlotTypeId, opts => opts.MapFrom(src => src.Id))
             .ForMember(dest => dest.PlotTypeName, opts => opts.MapFrom(src => src.Name))
             .ForMember(dest => dest.DateCreated, opts => opts.MapFrom(src => src.DateCreated))
             .ForMember(dest => dest.DateModified, opts => opts.MapFrom(src => src.DateModified))
             ;
        }
    }
}
