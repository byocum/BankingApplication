using System.Collections.Generic;
using BankingApplication.Accounts;
using BankingApplication.AccountHolders;
using BankingApplication.Enum;

namespace BankingApplication.Banks
{
    public class Bank
    {
        private string name;
        private List<Account> accounts;

        public Bank(string bankName)
        {
            this.name = bankName;
            this.accounts = new List<Account>();
        }

        public string Name
        {
            get { return name; }
        }

        public List<Account> Accounts
        {
            get { return accounts; }
        }

        public void OpenAccount(AccountHolder owner, float beginningBalance, AccountType accountType )
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    Account newCheckingAccount = new Checking(owner);
                    newCheckingAccount.Deposit(beginningBalance);
                    accounts.Add(newCheckingAccount);
                    break;
                case AccountType.CorperateInvestment:
                    Account newCorperateInvestmentAccount = new CorporateInvestment(owner);
                    newCorperateInvestmentAccount.Deposit(beginningBalance);
                    accounts.Add(newCorperateInvestmentAccount);
                    break;
                case AccountType.IndividualInvestment:
                    Account newIndividualInvestmentAccount = new IndividualInvestment(owner);
                    newIndividualInvestmentAccount.Deposit(beginningBalance);
                    accounts.Add(newIndividualInvestmentAccount);
                    break;
            }

        }
    }
}
