using System.Collections.Generic;
using Core.Model;

/// <summary>
///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
/// </summary>
namespace BusinessLogic.Repository.Abstractions
{
    public interface IUtilityService
    {
        /// <summary>
        /// Abstraction Interface Method To Get Gender By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Gender GetGender(int id);

        /// <summary>
        /// Abstraction Interface Method To Get Gender By Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Gender GetGender(string name);

        /// <summary>
        /// Abstraction Interface Method To Get All Payment Providers
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentProvider> GetPaymentProviders();

        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        ICollection<Department> Departments();

        /// <summary>
        /// Get Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Department DepartmentBy(int id);

        /// <summary>
        /// Get Department By Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Department DepartmentBy(int id, string name);

        /// <summary>
        /// Get Users By Department Id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        ICollection<AppUser> GetUsersBy(int departmentId);
    }
}
