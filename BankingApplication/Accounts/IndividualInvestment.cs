using System;
using System.Collections.Generic;
using BankingApplication.AccountHolders;
using BankingApplication.Transactions;

namespace BankingApplication.Accounts
{
    public class IndividualInvestment:Account
    {

        public IndividualInvestment(AccountHolder accountOwner)
        {
            this.AccountOwner = accountOwner;
            this.Transactions = new List<Transaction>();
            this.AccountBalance = 0;
        }

        public override void Withdrawal(float amount, string description)
        {
            Transaction transaction = new Withdrawal(amount, description);

            if (transaction.Amount >= -1000)
            {
                base.Withdrawal(amount, description);
            }
            else
            {
                throw new ArgumentException("Withdrawal cannot be more than $1,000. Transaction not added.");
            }

        }
    }
}

