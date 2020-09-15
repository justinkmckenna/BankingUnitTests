using BankingDomain;
using Xunit;

namespace BankingUnitTests
{
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveCorrectBalance()
        {
            // WTCYWYH - write the code you wish you had
            // Given
            var account = new BankAccount();

            // When
            decimal balance = account.GetBalance();

            // Then
            Assert.Equal(1000M, balance);
        }
    }
}
