using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class WorkOrderRepository : BaseRepository<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(AppDbContext context) : base(context)
        {

        }

        public WorkOrder CreateNewWorkOrder(WorkOrder workOrder)
        {
            return CreateAndReturn(workOrder);
        }

        public IEnumerable<WorkOrder> GetAllBySubscriptionId(int subscriptionId)
        {
            return GetAll().Where(x => x.SubscriptionId == subscriptionId);
        }

        public IEnumerable<WorkOrder> GetAllByUserId(int userId)
        {
            return GetAll().Where(x => x.AppUserId == userId);
        }

        public IEnumerable<WorkOrder> GetAllWorkOrders()
        {
            return GetAll();
        }

        public WorkOrder GetByUserId(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetWorkOrderBy(int subscriptionId)
        {
            return GetAll().Where(x => x.SubscriptionId == subscriptionId);
        }

        public IEnumerable<WorkOrderType> GetWorkOrderTypes()
        {
            return _context.WorkOrderTypes.ToList();
        }
    }
}
