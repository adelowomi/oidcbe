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
    public class PaymentAppService : IPaymentAppService
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentAppService(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public IEnumerable<PaymentMethodViewModel> GetAllPaymentMethods()
        {
            var result =  _paymentService.GetAllPaymentMethods().Select(_mapper.Map<PaymentMethod, PaymentMethodViewModel>);
            return result;
        }

        public IEnumerable<PaymentProviderViewModel> GetAllPaymentProviders()
        {
            var result = _paymentService.GetAllPaymentProviders().Select(_mapper.Map<PaymentProvider, PaymentProviderViewModel>);
            return result;
        }

        public IEnumerable<PaymentStatusViewModel> GetAllPaymentStatuses()
        {
            var result = _paymentService.GetAllPaymentStatuses().Select(_mapper.Map<PaymentStatus, PaymentStatusViewModel>);
            return result;
        }

        public IEnumerable<PaymentTypeViewModel> GetAllPaymentTypes()
        {
            var result = _paymentService.GetAllPaymentTypes().Select(_mapper.Map<PaymentType, PaymentTypeViewModel>);
            return result;
        }

        public PaymentViewModel MakePayment(PaymentInputModel payment)
        {
           var result = _paymentService.LogNewPayment(payment.SubscriptionId, payment.PaymentTypeId, payment.PaymentMethodId, payment.PaymentProviderId, payment.Amount);

           var mappedResult = _mapper.Map<Payment, PaymentViewModel>(result);

           return mappedResult;
        }

        public PaymentViewModel QueryPayment(string trnxRef)
        {
            var result = _paymentService.QueryPayment(trnxRef);

            var mappedResult = _mapper.Map<Payment, PaymentViewModel>(result);

            return mappedResult;
        }
    }
}
