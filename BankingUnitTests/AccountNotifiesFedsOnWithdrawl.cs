using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BankingUnitTests
{
    public class AccountNotifiesFedsOnWithdrawl
    {
        [Fact]
        public void FedIsNotifiedOnWithdrawl()
        {
            var mockedFed = new Mock<INotifyTheFeds>();
            var account = new BankAccount(new Mock<ICalculateBankAccountBonuses>().Object, mockedFed.Object);

            account.Withdrawl(1);

            mockedFed.Verify(f => f.NotifyOfWithdrawl(account, 1m), Times.Once); 
            // can test if called once, n, never
            // can test on any bank account, not necessarily THIS account
        }
    }
}
