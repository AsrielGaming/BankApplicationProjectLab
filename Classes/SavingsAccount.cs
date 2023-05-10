using BankApplicationProjectLab.Classes;
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

        public void OverviewSavingsAccount()
        {
            Console.WriteLine("overview savings account werkt");
        }

    }
}
