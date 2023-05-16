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
        private Data data = new Data();
        public CurrentAccount(string name, string accountNumber, double balance, int userID, bool isFree): base(name, accountNumber, balance, userID,isFree)
        {
            data.InsertCurrentAccount(UserID, Name, Balance, isFree);
        }

        public Dictionary<string, double> OverviewCurrentAccount(int UserID)
        {
            Data data = new Data();

            Dictionary<string, double> currentAccounts = data.SelectOverwiewCurrentAccounts(UserID);

            return currentAccounts;
        }

    }
}
