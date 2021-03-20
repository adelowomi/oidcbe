using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    /// <summary>
    ///  LICENSE:   ALL RIGHT RESERVED TO COUSANT LIMITED (2020)
    /// </summary>
    public interface IUtilityRepository
    {
        /// <summary>
        /// Interface Abstract Method To Get Gender By Name
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Gender GetGenderByName(string gender);

        /// <summary>
        /// Interface Abstract Method To Get Gender By Its Id
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>
        Gender GetGenderById(int genderId);

        /// <summary>
        /// Interface Abstract Method To Insert New Next Of Kin
        /// </summary>
        /// <param name="nextOfKin"></param>
        /// <returns></returns>
        NextOfKin AddNextOfKin(NextOfKin nextOfKin);

        /// <summary>
        /// Interface Abstract Method To Get Organization Type By Its Id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        OrganizationType GetOrganizationType(int type);

        /// <summary>
        /// Interface Abstract Method Get All Available Payment Providers
        /// </summary>
        /// <returns></returns>
        ICollection<PaymentProvider> GetPaymentProviders();

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

        /// <summary>
        /// Get List Of Accounts
        /// </summary>
        /// <returns></returns>
        ICollection<Account> GetAccounts();

        /// <summary>
        /// Create new account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Account CreateNewAccount(Account account);
    }
}
