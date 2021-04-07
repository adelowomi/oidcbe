using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService.AppModel.ViewModel;
using AppService.Repository.Abstractions;
using AutoMapper;
using BusinessLogic.Repository.Abstractions;
using Core.Model;

namespace AppService.Repository
{
    public class PaymentInstalmentAppService : ResponseViewModel, IPaymentInstalmentAppService
    {
        private readonly IPaymentInstalmentService _instalmentService;  
        private readonly IMapper _mapper;
        public PaymentInstalmentAppService(IMapper mapper, IPaymentInstalmentService paymentInstalmentService)
        {
            _mapper = mapper;
            _instalmentService = paymentInstalmentService;
        }
        public IEnumerable<PaymentInstalmentViewModel> GetInstalments()
        {
            return _instalmentService.GetInstalments().Select(_mapper.Map<PaymentInstalment, PaymentInstalmentViewModel>);
        }

        public IEnumerable<PaymentInstalmentViewModel> GetDueInstalments()
        {
            return _instalmentService.GetDueInstalments()
                .Select(_mapper.Map<PaymentInstalment, PaymentInstalmentViewModel>);
        }
    }
}
