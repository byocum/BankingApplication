using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication.Accounts;
using BankingApplication.AccountHolders;

namespace BankingApplication.UnitTests
{
    [TestClass]
    public class IndividualInvestmentTest
    {
        [TestMethod]
        public void Deposit_AmountSmallerThanAccountBalance_AccountBalanceEquals20()
        {
            Account account = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            account.Deposit(50);

            float accountBalance = account.AccountBalance;

            Assert.AreEqual(50, accountBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Adding this transaction will overdraft the account. Transaction not added.")]
        public void Withdrawal_AmountLargerThanAccountBalance_ArgumentExceptionThrown()
        {
            Account account = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            account.Deposit(50);
            account.Withdrawal(100, "Kroger");
        }

        [TestMethod]
        public void Withdrawal_AmountSmallerThanAccountBalance_AccountBalanceEquals20()
        {
            Account account = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            account.Deposit(50);
            account.Withdrawal(30, "Kroger");

            float accountBalance = account.AccountBalance;

            Assert.AreEqual(20, accountBalance);
        }

        [TestMethod]
        public void Withdrawal_AccountBalanceIsMade0_AccountBalanceEquals0()
        {
            Account account = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            account.Deposit(50);
            account.Withdrawal(50, "Kroger");

            float accountBalance = account.AccountBalance;

            Assert.AreEqual(0, accountBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Withdrawal cannot be more than $1,000. Transaction not added.")]
        public void Withdrawal_WithdrawalMoreThan1000Dollars_ArgumentExceptionThrown()
        {
            Account account = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            account.Deposit(2000);
            account.Withdrawal(1001, "Kroger");
        }

        [TestMethod]
        public void Transfer_ToAccountBalanceGreaterThanOriginalBalance_AccountBalanceEquals75()
        {
            Account account1 = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            Account account2 = new CorporateInvestment(new AccountHolder("Luke", "Skywalker"));

            account1.Deposit(50);
            account2.Deposit(50);
            account1.Transfer(25, account2);

            float accountBalance = account2.AccountBalance;

            Assert.AreEqual(75, accountBalance);
        }

        [TestMethod]
        public void Transfer_FromAccountBalanceLessThanOriginalBalance_AccountBalanceEquals25()
        {
            Account account1 = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            Account account2 = new CorporateInvestment(new AccountHolder("Luke", "Skywalker"));

            account1.Deposit(50);
            account2.Deposit(50);
            account1.Transfer(25, account2);

            float accountBalance = account1.AccountBalance;

            Assert.AreEqual(25, accountBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Adding this transaction will overdraft the account. Transaction not added.")]
        public void Transfer_TransferAmountGreaterThanFromAccountBalance_ArgumentExceptionThrown()
        {
            Account account1 = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            Account account2 = new CorporateInvestment(new AccountHolder("Luke", "Skywalker"));

            account1.Deposit(15);
            account2.Deposit(50);
            account1.Transfer(25, account2);
        }

        [TestMethod]
        public void Transfer_FromAccountBalanceIsMade0_AccountBalanceEquals0()
        {
            Account account1 = new IndividualInvestment(new AccountHolder("Obi-Wan", "Kenobi"));
            Account account2 = new Checking(new AccountHolder("Luke", "Skywalker"));

            account1.Deposit(50);
            account2.Deposit(50);
            account1.Transfer(50, account2);

            float accountBalance = account1.AccountBalance;

            Assert.AreEqual(0, accountBalance);
        }
    }
}
