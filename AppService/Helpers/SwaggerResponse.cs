using System;
using System.Collections.Generic;
using AppService.AppModel.ViewModel;
using AppService.Validations;

namespace AppService.Helpers
{
    public class SwaggerResponse<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public string StatusCode { get; set; }

        public List<ValidationError> Errors { get; }
    }

    public class PaymentResponse : SwaggerResponse<PaymentViewModel>{ }

    public class PlotResponse : SwaggerResponse<PlotViewModel> { }

    public class PlotsResponse : SwaggerResponse<IEnumerable<PlotViewModel>> { }

    public class PlotTypeResponse : SwaggerResponse<IEnumerable<PlotTypeViewModel>> { }

    public class PermitsResponse : SwaggerResponse<IEnumerable<PermitViewModel>> { }

    public class PermitResponse : SwaggerResponse<PermitViewModel> { }

    public class PermitStatusesResponse : SwaggerResponse<PermitStatusViewModel> { }

    public class PermitTypeResponse : SwaggerResponse<IEnumerable<PermitTypeVieModel>> { }

    public class VehicleTypeResponse : SwaggerResponse<IEnumerable<VehicleTypeViewModel>> { }

    public class RequestResponse : SwaggerResponse<RequestViewModel> { }

    public class RequestsResponse : SwaggerResponse<IEnumerable<RequestViewModel>> { }

    public class RequestTypesResponse : SwaggerResponse<IEnumerable<RequestTypeViewModel>> { }

    public class RequestStatusesResponse : SwaggerResponse<IEnumerable<RequestStatusViewModel>> { }

    public class DocumentTypesResponse : SwaggerResponse<IEnumerable<DocumentTypeViewModel>> { }
}
