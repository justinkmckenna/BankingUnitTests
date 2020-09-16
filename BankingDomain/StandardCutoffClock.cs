﻿using BankingDomain;
using System;

namespace BankingUnitTests
{
    public class StandardCutoffClock : IProvideTheCutoffClock
    {
        ISystemTime _systemTime;

        public StandardCutoffClock(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public bool BeforeCutoff()
        {
            return _systemTime.GetCurrent().Hour < 17 ? true : false;
        }
    }
}