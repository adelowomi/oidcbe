
namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int PlotId { get; set; }

        public int? AppUserId { get; set; }

        public string Document { get; set; }

        public string Description { get; set; }

        public int WorkOrderStatusId { get; set; }
    }
}
