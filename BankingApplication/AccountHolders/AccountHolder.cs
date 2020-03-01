using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication.AccountHolders
{
    public class AccountHolder
    {
        private string firstName;
        private string lastName;

        public AccountHolder(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }
    }
}
