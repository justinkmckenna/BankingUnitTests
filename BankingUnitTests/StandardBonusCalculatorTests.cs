using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class StandardBonusCalculatorTests
    {
        // balances below 1000 never get a bonus (either before or after cutoff)
        // balances at or over 1000
        //  - Before Cutoff get 10%
        //  - After Cutoff get 8%

        [Fact]
        public void BonusBeforeCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(true);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositFor(1000, 100);
            Assert.Equal(10, bonus);
        }

        [Fact]
        public void BonusAfterCutoff()
        {
            var cutoffClockStub = new Mock<IProvideTheCutoffClock>();
            cutoffClockStub.Setup(c => c.BeforeCutoff()).Returns(false);
            var calculator = new StandardBonusCalculator(cutoffClockStub.Object);
            var bonus = calculator.GetDepositFor(1000, 100);
            Assert.Equal(8, bonus);
        }
    }

    //public class BeforeCutoffBonusCalculator : StandardBonusCalculator
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return true;
    //    }
    //}
    //public class AfterCutoffBonusCalculator : StandardBonusCalculator
    //{
    //    protected override bool BeforeCutoff()
    //    {
    //        return false;
    //    }
    //}
}
