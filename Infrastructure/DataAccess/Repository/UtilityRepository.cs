﻿using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Add Next Of Kin
        /// </summary>
        /// <param name="nextOfKin"></param>
        /// <returns></returns>
        public NextOfKin AddNextOfKin(NextOfKin nextOfKin)
        {
            _context.NextOfKins.Add(nextOfKin);
            _context.SaveChanges();

            return nextOfKin;
        }

        /// <summary>
        /// Get Gender By It's Id
        /// </summary>
        /// <param name="genderId"></param>
        /// <returns></returns>
        public Gender GetGenderById(int genderId)
        {
            return GetById(genderId);
        }

        /// <summary>
        /// Get Gender By Name
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public Gender GetGenderByName(string gender)
        {
            return GetAll().FirstOrDefault(g => g.Name == gender);
        }

        /// <summary>
        /// Get Organization Type by Id
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public OrganizationType GetOrganizationType(int type)
        {
            return _context.OrganizationTypes.FirstOrDefault(x => x.Id == type);
        }

        /// <summary>
        /// Get Payment Providers
        /// </summary>
        /// <returns></returns>
        public ICollection<PaymentProvider> GetPaymentProviders()
        {
            return (ICollection<PaymentProvider>)_context.PaymentMethods;
        }
    }
}
