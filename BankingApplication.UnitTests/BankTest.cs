using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingApplication.Banks;


namespace BankingApplication.UnitTests
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void Bank_NameExists_NameIsNotNull()
        {
            Bank bank = new Bank("Fidelity Fiduciary Bank");

            Assert.IsNotNull(bank.Name);
        }

        [TestMethod]
        public void Bank_accountListExists_AccountListIsNotNull()
        {
            Bank bank = new Bank("Fidelity Fiduciary Bank");

            Assert.IsNotNull(bank.Accounts);
        }
    }
}
