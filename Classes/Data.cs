using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    class Data
    {
        private string connectionString = 
            "datasource=127.0.0.1;" +
            "port=3306;" +
            "username=root;" +
            "password=;" +
            "database=bankingapp;";



        //////////////////////////////////////////////   inserting   //////////////////////////////////////////////////////

        private int Insert(string query)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                int result = commandDatabase.ExecuteNonQuery();
                return (int)commandDatabase.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return -1;
        }

        public int InsertUser(User user)
        {
            string query = $"INSERT INTO user(Firstname,Lastname,Pin,Email) " +
              $"VALUES ('{user.FirstName}', " +
              $"'{user.LastName}'," +
              $"{user.Pin}, " +
              $"'{user.Email}');";
              

            return this.Insert(query);
        }

        public int InsertSavingsAccount(SavingsAccount savingsAccount)
        {
            string query = $"INSERT INTO account(UserID,Name,Balance,isFree,isSavingsAccount) " +
              $"VALUES ('{savingsAccount.UserID}', " +
              $"'{savingsAccount.Name}'," +
              $"{savingsAccount.Balance}, " +
              $"{savingsAccount.IsFree}, " +
              $"1);";


            return this.Insert(query);
        }

        public int InsertCurrentAccount(CurrentAccount currentAccount)
        {
            string query = $"INSERT INTO account(UserID,Name,Balance,isFree,isSavingsAccount) " +
              $"VALUES ('{currentAccount.UserID}', " +
              $"'{currentAccount.Name}'," +
              $"{currentAccount.Balance}, " +
              $"{currentAccount.IsFree}, " +
              $"0);";


            return this.Insert(query);
        }

        public int InsertAdmin(Admin admin)
        {
            string query = $"INSERT INTO admin(Firstname,Lastname,Pin,Email) " +
              $"VALUES ('{admin.FirstName}', " +
              $"'{admin.LastName}'," +
              $"{admin.Pin}, " +
              $"'{admin.Email}');";


            return this.Insert(query);
        }

        public int InsertTransaction(User userFrom, User userTo, double amount, string date)
        {
            

            string query = $"INSERT INTO transaction(Transferred_from,Transferred_to,Amount,Date) " +
              $"VALUES ('{userFrom.UserID}', " +
              $"'{userTo.UserID}'," +
              $"{amount}, " +
              $"'{date}');";


            return this.Insert(query);
        }


        //////////////////////////////////////////////     selecting     //////////////////////////////////////////////////////
        


        // select account balances from all accounts a user has
        // put it into a dictionary with the account's name and balance
        public Dictionary<string,double> SelectAccountBalance(User user)
        {
            string query = $"SELECT * FROM `account` WHERE UserID = {user.UserID};";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            Dictionary<string,double> balances = new Dictionary<string, double>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];

                    double balanceDB = reader.GetDouble(reader.GetOrdinal("Balance"));

                    balances[name] = balanceDB;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

            return balances;
            
        }
    }
}
