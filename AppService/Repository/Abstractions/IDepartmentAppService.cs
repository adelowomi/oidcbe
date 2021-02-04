using System;
using AppService.AppModel.ViewModel;

namespace AppService.Repository.Abstractions
{
    public interface  IDepartmentAppService
    {
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        ResponseViewModel Departments();

        /// <summary>
        /// Get Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ResponseViewModel DepartmentBy(int id);

        /// <summary>
        /// Get Department By Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ResponseViewModel DepartmentBy(int id, string name);

        /// <summary>
        /// Get Users By Department Id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        ResponseViewModel GetUsersBy(int departmentId);
    }
}
