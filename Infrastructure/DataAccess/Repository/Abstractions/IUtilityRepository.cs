using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IUtilityRepository
    {
        Gender GetGenderByName(string gender);
        Gender GetGenderById(int genderId);
        //BillerItem AddBillerItem(BillerItem billerItem, string bill);
        //Biller AddBiller(Biller item, string billerCategory);
        //BillerCategory AddBillerCategory(BillerCategory item);
        //IEnumerable<BillerItem> GetBillerItems();
        //IEnumerable<Biller> GetBillers();
        //IEnumerable<BillerCategory> GetBillerCategories();
        //BillerItem GetBillerItem(string billerItem);
        //IEnumerable<AppUser> GetAppUsers();
        //AppUser GetAppUserById(int userId);
        //IEnumerable<Role> GetRoles();
        //IEnumerable<PaymentMethod> GetPaymentMethods();
    }
}
