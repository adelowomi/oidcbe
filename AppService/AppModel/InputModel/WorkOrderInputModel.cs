﻿
namespace AppService.AppModel.InputModel
{
    public class WorkOrderInputModel
    {
        public int PlotId { get; set; }

        public int? AppUserId { get; set; }

        public string Description { get; set; }

        public int WorkOrderTypeId { get; set; }

        public string Title { get; set; }
    }
}
