using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class SubscriberAppService : ISubscriberAppService
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public SubscriberAppService(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }

        public IEnumerable<VendorViewModel> GetAllExisting()
        {
            var result = _subscriberService.GetExistingSubscribers().Select(_mapper.Map<AppUser, VendorViewModel>);

            return result;
        }
    }
}
