using BankApplicationProjectLab.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_InspirationLab_2023.Classes
{
    class SavingsAccount: Account
    {
        private Data data = new Data();
        public SavingsAccount(string name, string accountNumber, double balance, int userID, bool isFree): base(name,accountNumber, balance, userID,isFree)
        {
            data.InsertSavingsAccount(UserID,Name,Balance,isFree);
        }


        public Dictionary<string, double> OverviewSavingsAccount(int UserID)
        {
            Data data = new Data();

            Dictionary<string, double> savingsAccounts = data.SelectOverwiewSavingAccounts(UserID);

            return savingsAccounts;
        }

    }
}
