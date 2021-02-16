using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repository
{
    public class WorkOrderRepository : BaseRepository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(AppDbContext context) : base(context)
        {

        }

        public WorkOrder Approve(int id)
        {
            var workOrder = GetById(id);

            workOrder.WorkOrderStatusId = (int)WorkOrderStatusEnum.APPROVED;

            Save();

            return GetAllWorkOrders().FirstOrDefault(x => x.Id == id);
        }

        public WorkOrder CreateNewWorkOrder(WorkOrder workOrder)
        {
            workOrder.WorkOrderStatusId = (int) WorkOrderStatusEnum.PENDING;

            var work = CreateAndReturn(workOrder);

            return GetAllWorkOrders().FirstOrDefault(x => x.Id == work.Id);
        }

        public WorkOrder Decline(int id)
        {
            var workOrder = GetById(id);

            workOrder.WorkOrderStatusId = (int)WorkOrderStatusEnum.DECLINED;

            Save();

            return GetAllWorkOrders().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetAllByPlotId(int plotId)
        {
            return GetAllWorkOrders().Where(x => x.PlotId == plotId);
        }

        public IEnumerable<WorkOrder> GetAllByUserId(int userId)
        {
            return GetAllWorkOrders().Where(x => x.AppUserId == userId);
        }

        public IEnumerable<WorkOrder> GetAllWorkOrders()
        {
            var result = _context.WorkOrders
                    .Include(x => x.WorkOrderStatus)
                    .Include(x => x.WorkOrderType)
                    .ToList();

            return result;
        }

        public WorkOrder GetByUserId(int id)
        {
            return GetAllWorkOrders().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetWorkOrderBy(int plotId)
        {
            return GetAllWorkOrders().Where(x => x.PlotId == plotId);
        }

        public IEnumerable<WorkOrderType> GetWorkOrderTypes()
        {
            return _context.WorkOrderTypes.ToList();
        }


    }
}
