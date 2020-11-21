using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    /// <summary>
    /// Concrete Implementation Of ISubscriberAppService
    /// </summary>
    public class SubscriberAppService : ISubscriberAppService
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="subscriberService"></param>
        /// <param name="mapper"></param>
        public SubscriberAppService(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Existing Vendor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<VendorViewModel> GetAllExisting()
        {
            var result = _subscriberService.GetExistingSubscribers().Select(_mapper.Map<AppUser, VendorViewModel>);

            return result;
        }

        public CountMetricViewModel GetCountsMetric()
        {
            return new CountMetricViewModel()
            {
                ExistingSubscribers = GetAllExisting().Count(),
                NewSubscribers = GetAllExisting().Count(),
                ExistingVendors = GetAllExisting().Count(),
                NewVendors = GetAllExisting().Count()
            };
        }
    }
}
