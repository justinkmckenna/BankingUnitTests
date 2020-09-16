namespace BankingDomain
{
    public interface ICalculateBankAccountBonuses
    {
        decimal GetDepositFor(decimal balance, decimal amountToDeposit);
    }
}