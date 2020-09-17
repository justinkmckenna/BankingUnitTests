using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class CannotDoTransactionsWithNegativeAmounts
    {

        // This test will fail until I fix the bug that the STE told me about.
        // It shows I understand the undesirable behaviour.
        // I delete this after I fix the bug.
        //[Fact]
        //public void DepositsAllowNegativeNumbers()
        //{
        //    var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
        //    var openingBalance = account.GetBalance();

        //    account.Deposit(-100);

        //    Assert.Equal(openingBalance - 100, account.GetBalance());
        //}

        [Fact]
        public void DepositsDontAllowNegativeNumbers()
        {
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, new Mock<INotifyTheFeds>().Object);
            var openingBalance = account.GetBalance();

            Assert.Throws<NoNegativeTransactionException>(() => account.Deposit(-100));

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
