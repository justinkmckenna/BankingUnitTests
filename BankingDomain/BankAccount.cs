using System;

namespace BankingDomain
{
    public enum AccountType { Standard, Gold }
    public class BankAccount
    {
        public BankAccount()
        {
        }

        public AccountType AccountType;
        private decimal _balance = 1000M;

        public decimal GetBalance()
        {
            return _balance;
        }

        public virtual void Deposit(decimal amountToDeposit)
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