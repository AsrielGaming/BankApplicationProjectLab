using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    internal class Account
    {
        public string Name { get; set; }
        protected double Saldo { get; set; }
        public int UserID { get; set; }
        public bool IsFree { get; set; }

        public Account(string name, double saldo, int userID, bool isfree)
        {
            Name = name;
            Saldo = saldo;
            UserID = userID;
            IsFree = isfree;
        }

        public void newTransaction()
        {

        }

        public void overViewHistory()
        {

        }

        public void checkAccountBalance()
        {

        }

    }
}
