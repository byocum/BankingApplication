using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.Transactions
{
    public class Withdrawal:Transaction
    {
        public Withdrawal(float amount)
        {
            this.Amount = -Math.Abs(amount);
            this.Description = "WithDrawal";
            this.DateOfTransaction = DateTime.Now;
        }

        public Withdrawal(float amount, string description)
        {
            this.Amount = -Math.Abs(amount);
            this.Description = description;
            this.DateOfTransaction = DateTime.Now;
        }
    }
}
