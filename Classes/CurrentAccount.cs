using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    class CurrentAccount: Account
    {
        public CurrentAccount(string name, string accountNumber, int saldo, int userID, bool isFree): base(name, accountNumber, saldo, userID,isFree)
        {

        }

        public void OverviewCurrentAccount()
        {
            Console.WriteLine("overview current account werkt");
        }

    }
}
