using System;
using BusinessLogic.Repository.Abstractions;
using Core.Model;
using Infrastructure.DataAccess.Repository.Abstractions;

namespace BusinessLogic.Repository
{
    public class UtilityService : IUtilityService
    {
        private readonly IUtilityRepository _utilityRepository;

        public UtilityService(IUtilityRepository utilityRepository)
        {
            _utilityRepository = utilityRepository;
        }
        public Gender GetGender(int id)
        {
            return _utilityRepository.GetGenderById(id);
        }

        public Gender GetGender(string name)
        {
            return _utilityRepository.GetGenderByName(name);
        }
    }
}
