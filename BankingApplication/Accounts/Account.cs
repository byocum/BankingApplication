using System;
using System.Collections.Generic;
using BankingApplication.Transactions;
using BankingApplication.AccountHolders;

namespace BankingApplication.Accounts
{
    public abstract class Account
    {
        private AccountHolder accountOwner;
        private List<Transaction> transactions;
        private float accountBalance;
        public AccountHolder AccountOwner
        {
            get { return accountOwner; }
            protected set { accountOwner = value; }
        }

        public List<Transaction> Transactions
        {
            get { return transactions; }
            protected set { transactions = value; }
        }

        public float AccountBalance
        {
            get { return accountBalance; }
            protected set { accountBalance = value; }
        }

        public virtual void Withdrawal(float amount, string description)
        {
            Transaction transaction = new Withdrawal(amount, description);
            float checkAmount = AccountBalance + transaction.Amount;

            if (checkAmount >= 0)
            {
                AccountBalance = checkAmount;
                Transactions.Add(transaction);
            }
            else
            {
                throw new ArgumentException("Adding this transaction will overdraft the account. Transaction not added.");
            }
        }

        public void Deposit(float amount)
        {
            Transaction transaction = new Deposit(amount);
            AccountBalance = AccountBalance + transaction.Amount;
            Transactions.Add(transaction);
        }

        public void Transfer(float amountToTransfer, Account transferToAccount)
        {
            Transaction toAccountTransaction = new Transfer(amountToTransfer);
            Transaction fromAccountTransaction = new Transfer(-amountToTransfer);

            float checkAmount = AccountBalance + fromAccountTransaction.Amount;

            if(checkAmount >= 0)
            {
                AccountBalance = checkAmount;
                this.Transactions.Add(fromAccountTransaction);            
                transferToAccount.AccountBalance = transferToAccount.accountBalance + toAccountTransaction.Amount;
                transferToAccount.Transactions.Add(toAccountTransaction);
            }
            else
            {
                throw new ArgumentException("Adding this transaction will overdraft the account. Transaction not added.");
            }
        }
    }
}
