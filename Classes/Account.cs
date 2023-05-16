using Microsoft.VisualBasic.ApplicationServices;
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
        protected double Balance { get; set; }
        protected int UserID { get; set; }
        protected bool IsFree { get; set; }
        

        public Account(string name, string accountNumber, double balance, int userID, bool isfree)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.Balance = balance;
            this.UserID = userID;
            this.IsFree = isfree;
        }

        public void NewTransaction(int userFromID, int userToID, double amount)
        {
            // create data object 
            Data data = new Data();

            // DateTime is EU format, so create string with USA format to insert in DB
            DateTime date = DateTime.Now;
            string dateUSA = date.ToString("yyyy-MM-dd HH:mm:ss");

            
            int insertedId = data.InsertTransaction(userFromID,userToID,amount,dateUSA);

            // Check if the insertion was successful, -1 is default database error message 
            if (insertedId != -1)
            {
                Console.WriteLine("Transaction inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert transaction.");
            }
        }

        public List<Tuple<int, int, double, DateTime>> OverViewHistory(int UserID)
        {
            Data data = new Data();

            List<Tuple<int,int,double, DateTime>> transactions = data.SelectTransactionHistory(UserID);

            return transactions;
        } 

    }
}
