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

        public Gender GetGenderById(int genderId)
        {
            return GetById(genderId);
        }

        public Gender GetGenderByName(string gender)
        {
            return GetAll().FirstOrDefault(g => g.Name == gender);
        }
    }
}
