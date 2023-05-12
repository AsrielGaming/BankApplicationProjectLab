using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    class CurrentAccount: Account
    {
        public CurrentAccount(string name, string accountNumber, int balance, int userID, bool isFree): base(name, accountNumber, balance, userID,isFree)
        {

        }

        public Dictionary<string, double> OverviewCurrentAccount(User user)
        {
            Data data = new Data();

            Dictionary<string, double> currentAccounts = data.SelectOverwiewCurrentAccounts(user);

            return currentAccounts;
        }

    }
}
