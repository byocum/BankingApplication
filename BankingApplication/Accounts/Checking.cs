using System.Collections.Generic;
using BankingApplication.AccountHolders;

namespace BankingApplication.Accounts
{
    public class Checking:Account
    {

        public Checking(AccountHolder accountOwner)
        {
            this.AccountOwner = accountOwner;
            this.Transactions = new List<Transactions.Transaction>();
            this.AccountBalance = 0;
        }
    }
}
