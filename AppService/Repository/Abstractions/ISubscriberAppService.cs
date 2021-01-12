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

        /// <summary>
        /// Get Count Metrics
        /// </summary>
        /// <returns></returns>
        CountMetricViewModel GetCountsMetric();

        /// <summary>
        /// Add New Subscirber As Individual
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns></returns>
        Task<ResponseViewModel> AddNewSubscriberIndividual(SubcriberIndividualInputModel subscriber);

        /// <summary>
        /// Add New Subscriber As Corporate
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns></returns>
        Task<ResponseViewModel> AddNewSubscriberCorporate(SubscriberCorporateInputModel subscriber);

        /// <summary>
        /// Get Subscriber By Its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ResponseViewModel> GetSubscriberById(int id);

        /// <summary>
        /// Get Subscribers 
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetSubscribers();

        /// <summary>
        /// Get Vendors
        /// </summary>
        /// <returns></returns>
        ResponseViewModel GetVendors();

        /// <summary>
        /// Get Vendors
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseViewModel GetVendors(int id);
    }
}
