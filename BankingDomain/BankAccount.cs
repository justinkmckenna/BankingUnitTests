﻿using System;

namespace BankingDomain
{
    public class BankAccount
    {


        private decimal _balance = 1000M;
        private ICalculateBankAccountBonuses _bonusCalculator;
        private INotifyTheFeds _fedNotifier;

        public BankAccount(ICalculateBankAccountBonuses bonusCalculator, INotifyTheFeds fedNotifier)
        {
            _bonusCalculator = bonusCalculator;
            _fedNotifier = fedNotifier;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            decimal bonus = _bonusCalculator.GetDepositFor(_balance, amountToDeposit);
            _balance += amountToDeposit + bonus;
        }

        public void Withdrawl(decimal amountToWithdrawl)
        {
            if(amountToWithdrawl > _balance)
            {
                throw new OverdraftException();
            }
            _balance -= amountToWithdrawl;

            // notify the feds
            _fedNotifier.NotifyOfWithdrawl(this, amountToWithdrawl);
        }
    }
}