using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AutoMapper;
using Core.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;


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

            CreateMap<PaymentProvider, PaymentProviderViewModel>()

               .ForMember(dest => dest.PaymentProviderName, opts => opts.MapFrom(src => src.Name))
               ;


            CreateMap<Plot, PlotViewModel>()
                .ForMember(dest => dest.Acres, opts => opts.MapFrom(src => src.Acres))
                .ForMember(dest => dest.DatePurchased, opts => opts.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.PlotType, opts => opts.MapFrom(src => src.PlotType.Name))
                .ForMember(dest => dest.PlotId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.PlotAddresss, opts => opts.MapFrom(src => src.Address))
                .ForMember(dest => dest.Lattitude, opts => opts.MapFrom(src => src.Lattitude))
                .ForMember(dest => dest.Longitude, opts => opts.MapFrom(src => src.Longitude))
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
        }
    }
}
