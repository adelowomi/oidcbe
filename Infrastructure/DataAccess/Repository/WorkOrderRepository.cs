using System;
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

        public WorkOrder CreateNewWorkOrder(WorkOrder workOrder)
        {
            var work = CreateAndReturn(workOrder);

            return GetAllWorkOrders().FirstOrDefault(x => x.Id == work.Id);
        }

        public IEnumerable<WorkOrder> GetAllByPlotId(int plotId)
        {
            return GetAll().Where(x => x.PlotId == plotId);
        }

        public IEnumerable<WorkOrder> GetAllByUserId(int userId)
        {
            return GetAll().Where(x => x.AppUserId == userId);
        }

        public IEnumerable<WorkOrder> GetAllWorkOrders()
        {
            return _context.WorkOrders.Include(x => x.WorkOrderType);
        }

        public WorkOrder GetByUserId(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<WorkOrder> GetWorkOrderBy(int plotId)
        {
            return GetAll().Where(x => x.PlotId == plotId);
        }

        public IEnumerable<WorkOrderType> GetWorkOrderTypes()
        {
            return _context.WorkOrderTypes.ToList();
        }
    }
}
