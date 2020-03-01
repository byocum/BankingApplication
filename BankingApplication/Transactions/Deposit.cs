using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.Transactions
{
    public class Deposit:Transaction
    {
        public Deposit(float amount)
        {
            this.Amount = amount;
            this.Description = "Deposit";
            this.DateOfTransaction = DateTime.Now;
        }
    }
}
