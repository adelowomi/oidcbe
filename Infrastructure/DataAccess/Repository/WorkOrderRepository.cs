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

        public IEnumerable<WorkOrder> GetWorkOrderBy(int userId)
        {
            return GetAll().Where(x => x.SubscriptionId == userId);
        }

        public IEnumerable<WorkOrderType> GetWorkOrderTypes()
        {
            return _context.WorkOrderTypes.ToList();
        }
    }
}
