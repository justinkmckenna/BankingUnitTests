using BankingDomain;
using BankingUnitTests;
using System;
using System.Windows.Forms;

namespace BankKiosk
{
    public partial class Form1 : Form, INotifyTheFeds
    {
        BankAccount _account;
        public Form1()
        {
            InitializeComponent();
            _account = new BankAccount(new StandardBonusCalculator(new StandardCutoffClock(new SystemTime())), this);
            UpdateUi();
        }

        private void UpdateUi()
        {
            this.Text = $"Your balance is {_account.GetBalance():c}";
        }

        public void NotifyOfWithdrawl(BankAccount bankAccount, decimal amountToWithdrawl)
        {
            MessageBox.Show($"Notifying the feds of your withdrawl of {amountToWithdrawl:c}");
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Deposit);
        }

        private void btnWithdrawl_Click(object sender, EventArgs e)
        {
            DoTransaction(_account.Withdrawl);
        }

        private void DoTransaction(Action<decimal> op)
        {
            try
            {
                var amount = int.Parse(txtAmount.Text);
                op(amount);
                UpdateUi();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a number.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OverdraftException)
            {
                MessageBox.Show("You don't have enough money.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NoNegativeTransactionException)
            {
                MessageBox.Show("Must enter positive number.", "Bad Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtAmount.SelectAll();
                txtAmount.Focus();
            }
        }
    }
}
