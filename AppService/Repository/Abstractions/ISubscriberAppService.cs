using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using Core.Model;

namespace AppService.Repository.Abstractions
{
    public interface ISubscriberAppService
    {
        /// <summary>
        /// Get All Existing Subscribers 
        /// </summary>
        /// <returns></returns>
        IEnumerable<VendorViewModel> GetAllExisting();

        CountMetricViewModel GetCountsMetric();

        Task<ResponseViewModel> AddNewSubscriberAsync(SubscriberInputModel subscriber);
    }
}
