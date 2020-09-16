using BankingDomain;
using BankingUnitTests.TestDoubles;
using Newtonsoft.Json.Bson;
using System.Threading;
using Xunit;

namespace BankingUnitTests
{
    public class AccountDeposits
    {
        [Fact]
         public void DepositIncreasedBalance()
        {
            // given
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToDeposit = 5M;

            // when
            account.Deposit(amountToDeposit);

            // then
            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
