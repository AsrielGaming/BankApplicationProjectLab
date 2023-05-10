using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace BankApplicationProjectLab.Classes
{
    class Account
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        protected double Saldo { get; set; }
        public int UserID { get; set; }
        public bool IsFree { get; set; }

        public Account(string name, string accountNumber, double saldo, int userID, bool isfree)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.Saldo = saldo;
            this.UserID = userID;
            this.IsFree = isfree;
        }

        public void NewTransaction()
        {
            Console.WriteLine("new transaction werkt");
        }

        public void OverViewHistory()
        {
            Console.WriteLine("overviewhistory werkt");
        }

        public void CheckAccountBalance()
        {
            Console.WriteLine("check accountBalance werkt");

        }

    }
}
