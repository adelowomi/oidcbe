﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IPaymentInstalmentRepository
    {

        /// <summary>
        /// Abstract Interface Method To Get All Installments In IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentInstalment> GetInstalments();

        /// <summary>
        /// Abstract Interface Method To Get All Due Installments In IEnumerable
        /// </summary>
        /// <returns></returns>
        IEnumerable<PaymentInstalment> GetDueInstalments();
    }
}
