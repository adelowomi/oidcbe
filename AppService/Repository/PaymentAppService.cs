using System;
using System.Collections.Generic;
using System.Linq;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class PaymentAppService : ResponseViewModel, IPaymentAppService
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ISubscriptionAppService _subscriptionAppService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paymentService"></param>
        /// <param name="subscriptionAppService"></param>
        /// <param name="mapper"></param>
        public PaymentAppService(IPaymentService paymentService, ISubscriptionAppService subscriptionAppService, IMapper mapper) : base()
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _subscriptionAppService = subscriptionAppService;
        }

        /// <summary>
        /// Get All Payment Methods 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentMethodViewModel> GetAllPaymentMethods()
        {
            var result =  _paymentService.GetAllPaymentMethods().Select(_mapper.Map<PaymentMethod, PaymentMethodViewModel>);
            return result;
        }

        /// <summary>
        /// Get All Payment Providers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentProviderViewModel> GetAllPaymentProviders()
        {
            var result = _paymentService.GetAllPaymentProviders().Select(_mapper.Map<PaymentProvider, PaymentProviderViewModel>);
            return result;
        }

        /// <summary>
        /// Get All Payment Statuses
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentStatusViewModel> GetAllPaymentStatuses()
        {
            var result = _paymentService.GetAllPaymentStatuses().Select(_mapper.Map<PaymentStatus, PaymentStatusViewModel>);
            return result;
        }

        /// <summary>
        /// Get All Payment Types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PaymentTypeViewModel> GetAllPaymentTypes()
        {
            var result = _paymentService.GetAllPaymentTypes().Select(_mapper.Map<PaymentType, PaymentTypeViewModel>);
            return result;
        }

        public ResponseViewModel GetPaymentHistory()
        {
            var result = _paymentService.GetPayments().Select(_mapper.Map<Payment, PaymentViewModel>);

            return Ok(result);
            
        }

        /// <summary>
        /// Make Payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public ResponseViewModel MakePayment(PaymentInputModel payment)
        {
           var subscription = _subscriptionAppService.GetSubscriptions().FirstOrDefault(x => x.SubscriptionId == payment.SubscriptionId);

           //TODO: Please do try and catch inside Business Logic instead of the following you, SMH
           if(subscription == null)
           {
                return Failed(ResponseMessageViewModel.INVALID_SUBSCRIPTION_ENTRY, ResponseErrorCodeStatus.INVALID_SUBSCRIPTION_ENTRY);
           }

           var types = _paymentService.GetAllPaymentTypes().FirstOrDefault(x => x.Id == payment.PaymentTypeId);

           if(types == null)
           {
                return Failed(ResponseMessageViewModel.INVALID_PAYMENT_TYPE, ResponseErrorCodeStatus.INVALID_PAYMENT_TYPE);
           }

           var methods = _paymentService.GetAllPaymentMethods().FirstOrDefault(x => x.Id == payment.PaymentMethodId);

           if (methods == null)
           {
               return Failed(ResponseMessageViewModel.INVALID_PAYMENT_METHOD, ResponseErrorCodeStatus.INVALID_PAYMENT_METHOD);
           }

           var providers = _paymentService.GetAllPaymentProviders().FirstOrDefault(x => x.Id == payment.PaymentProviderId);

           if (providers == null)
           {
               return Failed(ResponseMessageViewModel.INVALID_PAYMENT_PROVIDER, ResponseErrorCodeStatus.INVALID_PAYMENT_PROVIDER);
           }

            var result = _paymentService.LogNewPayment(payment.SubscriptionId, payment.PaymentTypeId, payment.PaymentMethodId, payment.PaymentProviderId, 0);

           var mappedResult = _mapper.Map<Payment, PaymentViewModel>(result);

           return Ok(mappedResult);
        }

        /// <summary>
        /// Query Payment
        /// </summary>
        /// <param name="trnxRef"></param>
        /// <returns></returns>
        public ResponseViewModel QueryPayment(string trnxRef)
        {
            var result = _paymentService.QueryPayment(trnxRef);

            var mappedResult = _mapper.Map<Payment, PaymentViewModel>(result);

            return Ok(mappedResult);
        }
    }
}
