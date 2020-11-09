using System;
using System.Linq;
using Core.Model;
using Infrastructure.DataAccess.DataContext;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace Infrastructure.DataAccess.Repository
{
    public class UtilityRepository : BaseRepository<Gender>, IUtilityRepository
    {
        public UtilityRepository(AppDbContext context) : base(context)
        {

        }

        public NextOfKin AddNextOfKin(NextOfKin nextOfKin)
        {
            _context.NextOfKins.Add(nextOfKin);
            _context.SaveChanges();

            return nextOfKin;
        }

        public Gender GetGenderById(int genderId)
        {
            return GetById(genderId);
        }

        public Gender GetGenderByName(string gender)
        {
            return GetAll().FirstOrDefault(g => g.Name == gender);
        }

        public OrganizationType GetOrganizationType(int type)
        {
            return _context.OrganizationTypes.FirstOrDefault(x => x.Id == type);
        }
    }
}
