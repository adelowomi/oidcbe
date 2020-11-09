using System;
using Core.Model;

namespace BusinessLogic.Repository
{
    public interface IPlotService
    {
        Plot GetPlotBy(int subscriberId);
    }
}
