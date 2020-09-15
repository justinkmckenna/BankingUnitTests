using BankingDomain;
using Xunit;

namespace BankingUnitTests
{
    public class AccountOverdraft
    {
        // given we have an account with a balance
        // when i take out more money than the balance
        // then : 
        //    - amount of withdrawl should not be removed from balance
        //    - there should be an exception thrown

        [Fact]
        public void BalanceStaysTheSame()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdrawl(openingBalance + 1M);
            }
            catch (OverdraftException)
            {
                // Gulp.
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        [Fact]
        public void OverdraftGivesException()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            Assert.Throws<OverdraftException>(() => account.Withdrawl(openingBalance + 1M));
        }
    }
}
