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
        public SavingsAccount(string name, string accountNumber, int balance, int userID, bool isFree): base(name,accountNumber, balance, userID,isFree)
        {

        }

        public Dictionary<string, double> OverviewSavingsAccount(BankApplicationProjectLab.Classes.User user)
        {
            Data data = new Data();

            Dictionary<string, double> savingsAccounts = data.SelectOverwiewSavingAccounts(user);

            return savingsAccounts;
        }

    }
}
