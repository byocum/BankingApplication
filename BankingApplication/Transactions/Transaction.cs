using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.Transactions
{
    public abstract class Transaction
    {
        private float amount;
        private string description;
        private DateTime dateOfTransaction;

        public float Amount
        {
            get { return amount; }
            protected set { amount = value; }
        }

        public string Description
        {
            get { return description; }
            protected set { description = value; }
        }

        public DateTime DateOfTransaction
        {
            get { return dateOfTransaction; }
            protected set { dateOfTransaction = value; }
        }
    }
}
