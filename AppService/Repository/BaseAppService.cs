using System;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace AppService.Repository
{
    public class BaseAppService
    {
        public readonly IMapper _mapper;
        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly UserManager<AppUser> _userManager;

        public BaseAppService(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public BaseAppService() { }
    }
}
