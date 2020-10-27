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
                .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.FirstName))
                ;
        }
    }
}
