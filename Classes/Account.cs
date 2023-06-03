using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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

        public static void NewTransaction(int accountFromID, int accountToID, double amount)
        {
            // create data object 
            Data data = new Data();

            // DateTime is EU format, so create string with USA format to insert in DB
            DateTime date = DateTime.Now;
            string dateUSA = date.ToString("yyyy-MM-dd HH:mm:ss");

            
            int insertedId = data.InsertTransaction(accountFromID, accountToID, amount,dateUSA);

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

        public static void NewAutoTransaction(int accountFromID, int accountToID, double amount, string repeatability, int numberOfTransactions)
        {
            Data data = new Data();

            // Determine the current date
            DateTime currentDate = DateTime.Now;

            // Calculate the scheduled dates for auto transactions based on repeatability
            List<DateTime> scheduledDates = CalculateScheduledDates(currentDate, repeatability, numberOfTransactions);

            // Create and insert auto transactions into the auto transaction table
            foreach (DateTime scheduledDate in scheduledDates)
            {
                data.InsertAutoTransaction(accountFromID, accountToID, amount, scheduledDate.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        // Helper function (for NewAutoTransaction function) to calculate scheduled dates based on repeatability
        private static List<DateTime> CalculateScheduledDates(DateTime startDate, string repeatability, int numberOfTransactions)
        {
            List<DateTime> scheduledDates = new List<DateTime>();

            switch (repeatability)
            {
                case "daily":
                    for (int i = 0; i < numberOfTransactions; i++)
                    {
                        scheduledDates.Add(startDate.AddDays(i));
                    }
                    break;
                case "weekly":
                    for (int i = 0; i < numberOfTransactions; i++)
                    {
                        scheduledDates.Add(startDate.AddDays(i * 7));
                    }
                    break;
                case "monthly":
                    for (int i = 0; i < numberOfTransactions; i++)
                    {
                        scheduledDates.Add(startDate.AddMonths(i));
                    }
                    break;
                
                
            }

            return scheduledDates;
        }

        public static void ExecutePossibleAutoTransaction()
        {   
            Data data = new Data();
            List<Tuple<int, int, int, double, DateTime>> autoTransactions = data.SelectAutoTransactions();
            DateTime now = DateTime.Now;

            foreach (Tuple<int, int, int, double, DateTime> autoTransaction in autoTransactions)
            {
                int autoTransactionID = autoTransaction.Item1;
                int accountFromID = autoTransaction.Item2;
                int accountToID = autoTransaction.Item3;
                double amount = autoTransaction.Item4;
                DateTime scheduledDate = autoTransaction.Item5;

                
                try
                {
                    if (scheduledDate <= now)
                    {
                        // Execute the regular transaction
                        NewTransaction(accountFromID, accountToID, amount);
                        Console.WriteLine("Auto transaction executed for account " + accountFromID);

                        data.UpdateAutoTransactionExecutedStatus(autoTransactionID);

                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message + " " + "Invalid scheduled date format for auto transaction.");
                }
            }
        }



        public static List<Tuple<string, string, string, double, DateTime>> OverViewHistory(int userID)
        {
            Data data = new Data();

            List<Tuple<string, string, string, double, DateTime>> transactions = data.SelectTransactionHistory(userID);

            return transactions;
        } 

        public static bool CheckIfAccountExists(string userFirstname, string userLastname, int accountID)
        {
            Data data = new Data();

            bool existsInDatabase = data.CheckIfAccountExistsInDatabase(userFirstname, userLastname, accountID);

            return existsInDatabase;
        }

    }
}
