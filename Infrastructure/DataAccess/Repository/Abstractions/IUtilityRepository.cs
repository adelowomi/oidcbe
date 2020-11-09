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

        NextOfKin AddNextOfKin(NextOfKin nextOfKin);

        OrganizationType GetOrganizationType(int type);
    }
}
