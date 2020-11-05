﻿using System;
using Core.Model;

namespace BusinessLogic.Repository.Abstractions
{
    public interface IOTPService
    {
        string GenerateCode(int appUserId, int expirationInMunites);

        OTP ConfirmToken(int appUserId, string token);
    }
}