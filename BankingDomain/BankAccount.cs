using System;

namespace BankingDomain
{
    public class BankAccount
    {
        public BankAccount()
        {
        }

        private decimal _balance = 1000M;

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public void Withdrawl(decimal amountToWithdrawl)
        {
            if(amountToWithdrawl > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdrawl;
        }
    }
}