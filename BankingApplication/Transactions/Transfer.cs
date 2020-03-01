using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.Transactions
{
    public class Transfer:Transaction
    {
        public Transfer(float amount)
        {
            this.Amount = amount;
            this.Description = "Transfer";
            this.DateOfTransaction = DateTime.Now;
        }
    }
}
