﻿using Microsoft.VisualBasic.ApplicationServices;
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
        public double Balance { get; set; }
        public int UserID { get; set; }
        public bool IsFree { get; set; }

        public Account(string name, string accountNumber, double balance, int userID, bool isfree)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.Balance = balance;
            this.UserID = userID;
            this.IsFree = isfree;
        }

        public void NewTransaction(User userFrom, User userTo, double amount)
        {
            // create data object 
            Data data = new Data();

            // DateTime is EU format, so create string with USA format to insert in DB
            DateTime date = DateTime.Now;
            string dateUSA = date.ToString("yyyy-MM-dd HH:mm:ss");

            // Call the InsertUser method to insert the new user into the database
            int insertedId = data.InsertTransaction(userFrom,userTo,amount,dateUSA);

            // Check if the insertion was successful, -1 is default database error message 
            if (insertedId != -1)
            {
                Console.WriteLine("Admin inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert admin.");
            }
        }

        public void OverViewHistory()
        {
            Console.WriteLine("overviewhistory werkt");
        }

        public Dictionary<string, double> CheckAccountBalance(User user)
        {
            Data data = new Data();

            Dictionary<string, double> balances = data.SelectAccountBalance(user);

            return balances;
        }

    }
}
