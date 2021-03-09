using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppService.AppModel.InputModel;
using AppService.AppModel.ViewModel;
using AppService.Helpers;
using AppService.Repository.Abstractions;
using AppService.Services.Abstractions;
using AppService.Services.ContentServer;
using AppService.Services.ContentServer.Model;
using AutoMapper;
using BusinessLogic.Repository;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace AppService.Repository
{
    public class PaymentAppService : ResponseViewModel, IPaymentAppService
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        private readonly ISubscriptionAppService _subscriptionAppService;
        private readonly INotificationAppService _notificationAppService;
        private readonly IPlotService _plotService;
        private readonly AppSettings _settings;
        private readonly IUserService _userService;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="paymentService"></param>
        /// <param name="subscriptionAppService"></param>
        /// <param name="mapper"></param>
        public PaymentAppService(IPaymentService paymentService,
                                 ISubscriptionAppService subscriptionAppService,
                                 INotificationAppService notificationAppService,
                                 IPlotService plotService,
                                 IOptions<AppSettings> options,
                                 IUserService userService,
                                 IMapper mapper) : base()
        {
            _paymentService = paymentService;
            _mapper = mapper;
            _subscriptionAppService = subscriptionAppService;
            _notificationAppService = notificationAppService;
            _plotService = plotService;
            _settings = options.Value;
            _userService = userService;
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

        /// <summary>
        /// Get Payment Cyle
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetPaymentCycle()
        {
            var result = _paymentService.GetAvailablePaymentCycles().Select(_mapper.Map<PaymentCycle, PaymentCyleViewModel>);

            return Ok(result);
        }

        /// <summary>
        /// Get Payment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel GetPaymentById(int id)
        {
            var result = _mapper.Map<Payment, PaymentViewModel>(_paymentService.GetPayments().FirstOrDefault(x => x.Id == id));

            return Ok(result);
        }

        /// <summary>
        /// Get All Payments
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetAllPayments()
        {
            var result = _paymentService.GetPayments().Select(_mapper.Map<Payment, PaymentViewModel>);

            return Ok(result);
        }

        /// <summary>
        /// Get Payments By Status Approved
        /// </summary>
        /// <returns></returns>
        public ResponseViewModel GetApprovedPayments()
        {
            var result =_paymentService.GetPayments().Where(x => x.PaymentStatusId == (int)PaymentStatusEnum.APPROVED).Select(_mapper.Map<Payment, PaymentViewModel>);

            return Ok(result);
        }

        /// <summary>
        /// Approve Payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel Approve(int id)
        {
            return Ok(_mapper.Map<Payment, PaymentViewModel>(_paymentService.DeclinePayment(id)));
        }

        /// <summary>
        /// Decline Payment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseViewModel Decline(int id)
        {
            return Ok(_mapper.Map<Payment, PaymentViewModel>(_paymentService.DeclinePayment(id)));
        }
         
        public ResponseViewModel GetDuePayments()
        {
            var result = _paymentService.GetDuePayments().Select(_mapper.Map<Payment, PaymentViewModel>);
            return Ok(result);
        }

        public async Task<ResponseViewModel> PaymentAllocation(PaymentAllocationInputModel model)
        {
            var plot = _plotService.GetByPlotId(model.PlotId);

            if(plot == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PLOT, ResponseErrorCodeStatus.INVALID_PLOT);
            }

             var paymentType = _paymentService.GetAllPaymentTypes().FirstOrDefault(x => x.Id == model.PaymentType);

            if(paymentType == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PAYMENT_TYPE, ResponseErrorCodeStatus.INVALID_PAYMENT_TYPE);
            }

            var paymentMethod = _paymentService.GetAllPaymentMethods().FirstOrDefault(x => x.Id == model.PaymentMethodId);

            if(paymentMethod == null)
            {
                return NotFound(ResponseMessageViewModel.INVALID_PAYMENT_METHOD, ResponseErrorCodeStatus.INVALID_PAYMENT_METHOD);
            }

            FileDocument uploadResult = FileDocument.Create();

            try
            {
                uploadResult = await
                   BaseContentServer
                   .Build(ContentServerTypeEnum.FIREBASE, _settings)
                   .UploadDocumentAsync(FileDocument.Create(model.Receipt, $"{Helper.RandomNumber(10)}", $"{Helper.RandomNumber(10)}", FileDocumentType.GetDocumentType(MIMETYPE.IMAGE)));

                model.Receipt = uploadResult.Path;
            }
            catch (Exception e)
            {
                return Failed(ResponseMessageViewModel.UNABLE_TO_UPLOAD_RECEIPT, ResponseErrorCodeStatus.UNABLE_TO_UPLOAD_RECEIPT);
            }

            var allocation = _paymentService.Allocate(_mapper.Map<PaymentAllocationInputModel, PaymentAllocation>(model));

            allocation.PaymentStatusId = (int) PaymentStatusEnum.PENDING;

            var user = await _userService.GetCurrentLoggedOnUserAsync();

            allocation.AppUserId = user.Id;

            var created = _paymentService.Allocate(allocation);

            return Ok(_mapper.Map<PaymentAllocation, PaymentAllocationViewModel>(created));
        }
    }
}
