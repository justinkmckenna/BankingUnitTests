using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class BusinessDayCutoffClock
    {
        [Fact]
        public void BeforeFiveClock()
        {
            var fakeClock = new Mock<ISystemTime>();
            fakeClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 16, 59, 59));
            IProvideTheCutoffClock clock = new StandardCutoffClock(fakeClock.Object);

            Assert.True(clock.BeforeCutoff());
        }

        [Fact]
        public void AfterFiveClock()
        {
            var fakeClock = new Mock<ISystemTime>();
            fakeClock.Setup(c => c.GetCurrent()).Returns(new DateTime(1969, 4, 20, 17, 59, 59));
            IProvideTheCutoffClock clock = new StandardCutoffClock(fakeClock.Object);

            Assert.False(clock.BeforeCutoff());
        }
    }
}
