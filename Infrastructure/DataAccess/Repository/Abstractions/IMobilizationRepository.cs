﻿using System;
using System.Collections.Generic;
using Core.Model;

namespace Infrastructure.DataAccess.Repository.Abstractions
{
    public interface IMobilizationRepository
    {
        Mobilization CreateAndReturn(Mobilization mobilization);

        IEnumerable<Mobilization> GetAll();

        Mobilization GetById(int id);

        Mobilization Update(Mobilization mobilization);
    }
}