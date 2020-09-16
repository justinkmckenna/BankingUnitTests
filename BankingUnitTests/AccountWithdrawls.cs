using BankingDomain;
using BankingUnitTests.TestDoubles;
using Moq;
using Xunit;

namespace BankingUnitTests
{
    public class AccountWithdrawls
    {
        [Fact]
        public void WithdrawlDecreasesBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();
            var amountToWithdrawl = 1M;

            account.Withdrawl(amountToWithdrawl);

            Assert.Equal(openingBalance - amountToWithdrawl, account.GetBalance());
        }

        [Fact]
        public void CanTakeAllYourMoney()
        {
            var account = new BankAccount(new DummyBonusCalculator(), new Mock<INotifyTheFeds>().Object);

            account.Withdrawl(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
        }
    }
}
