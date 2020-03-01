using System;
using System.Collections.Generic;
using BankingApplication.AccountHolders;
using BankingApplication.Transactions;

namespace BankingApplication.Accounts
{
    public class CorporateInvestment:Account
    {
        public CorporateInvestment(AccountHolder accountOwner)
        {
            this.AccountOwner = accountOwner;
            this.Transactions = new List<Transactions.Transaction>();
            this.AccountBalance = 0;
        }
    }
}
