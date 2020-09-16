using BankingDomain;
using BankingUnitTests.TestDoubles;
using Xunit;

namespace BankingUnitTests
{
    public class AccountWithdrawls
    {
        [Fact]
        public void WithdrawlDecreasesBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToWithdrawl = 1M;

            account.Withdrawl(amountToWithdrawl);

            Assert.Equal(openingBalance - amountToWithdrawl, account.GetBalance());
        }

        [Fact]
        public void CanTakeAllYourMoney()
        {
            var account = new BankAccount(new DummyBonusCalculator());

            account.Withdrawl(account.GetBalance());

            Assert.Equal(0, account.GetBalance());
        }
    }
}
