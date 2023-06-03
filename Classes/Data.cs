﻿using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Transactions;
using System.Security.Cryptography.X509Certificates;

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

        // function to create a new user in the database when creating a new user in the program
        public int InsertUser(string Firstname, string Lastname, int Pin, string Email)
        {
            string query = $"INSERT INTO user(Firstname,Lastname,Pin,Email) " +
              $"VALUES ('{Firstname}', " +
              $"'{Lastname}'," +
              $"{Pin}, " +
              $"'{Email}');";


            return this.Insert(query);
        }

        // function to create a new savingsAccount in the database when creating a new savingsaccount in program
        public void InsertSavingsAccount(int UserID, string Name, double Balance, bool isFree)
        {
            string query = $"INSERT INTO account(UserID,Name,Balance,isFree,isSavingsAccount) " +
              $"VALUES ('{UserID}', " +
              $"'{Name}'," +
              $"{Balance}, " +
              $"{isFree}, " +
              $"1);";


             this.Insert(query);
        }

        // function to create a new currentAccount in the database when creating a new currentaccount in program
        public int InsertCurrentAccount(int UserID, string Name, double Balance, bool isFree)
        {
            string query = $"INSERT INTO account(UserID,Name,Balance,isFree,isSavingsAccount) " +
              $"VALUES ('{UserID}', " +
              $"'{Name}'," +
              $"{Balance}, " +
              $"{isFree}, " +
              $"0);";


            return this.Insert(query);
        }

        // insert admin in the database when creating a new admin in program
        /*
        public int InsertAdmin(Admin admin)
        {
            string query = $"INSERT INTO admin(Firstname,Lastname,Pin,Email) " +
              $"VALUES ('{admin.FirstName}', " +
              $"'{admin.LastName}'," +
              $"{admin.Pin}, " +
              $"'{admin.Email}');";


            return this.Insert(query);
        }
        */

        

        public int InsertTransaction(int accountFromID, int accountToID, double amount, string date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Start the database transaction
                //this is a way to handle all db operations as one and if one fails, all the others are turned back
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        if (accountFromID != accountToID)
                        {
                            string query = $"INSERT INTO transaction(Transferred_from,Transferred_to,Amount,Date) " +
                                       $"VALUES ('{accountFromID}', '{accountToID}', {amount}, '{date}');";

                            int transactionID = Insert(query);

                            // Update the account balances based on the transaction

                            // Get the account balance of the user sending the transaction
                            double balanceFrom = GetAccountBalance(accountFromID);

                            // Update the balance of the account sending the transaction
                            double newBalanceFrom = balanceFrom - amount;

                            // only execute transaction when accountbalance is sufficient
                            if (newBalanceFrom < 0) 
                            {
                                throw new Exception();
                            }

                            UpdateAccountBalance(accountFromID, newBalanceFrom);

                            // Check if the user sending the transaction is transferring to their own account


                            // Get the account balance of the user receiving the transaction
                            double balanceTo = GetAccountBalance(accountToID);

                            // Update the balance of the account receiving the transaction
                            double newBalanceTo = balanceTo + amount;
                            UpdateAccountBalance(accountToID, newBalanceTo);


                            // Commit the transaction if all updates were successful
                            transaction.Commit();

                            return transactionID;
                        }
                        else
                        {
                            throw new Exception();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        // An error occurred, rollback the transaction
                        transaction.Rollback();
                        Console.WriteLine("Transaction failed: " + ex.Message);
                        return -1; // or throw an exception
                    }
                }
            }
        }

        public void InsertAutoTransaction(int accountFromID, int accountToID, double amount, string scheduledDate)
        {
            string query = $"INSERT INTO `auto_transaction` (Transferred_from, Transferred_to, Amount, Scheduled_date, isExecuted ) " +
                           $"VALUES ({accountFromID}, {accountToID}, {amount}, '{scheduledDate}', 0)";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                if(accountFromID != accountToID)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Console.WriteLine("Auto transaction inserted successfully.");
                }
                else
                { 
                    throw new Exception(); 
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //////////////////////////////////////////////     selecting     //////////////////////////////////////////////////////


        public double GetAccountBalance(int accountFromID)
        {
            string query = $"SELECT Balance FROM Account WHERE ID = {accountFromID}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double balance = reader.GetDouble("Balance");
                            return balance;
                        }
                    }
                }
            }

            // Return a default balance if the user or account is not found
            return 0.0;
        }





        // select transaction history from certain user, both when he is "transaction_from" and "transaction_to"
        // getting all transaction data out of DB and putting them in a tuple, making a list named transactions from these tuples. so 1 tuple contains all data about 1 transaction


        public List<Tuple<string, string, string, double, DateTime>> SelectTransactionHistory(int userID)
        {
            string query = $@"
                SELECT
                    CONCAT(sender.FirstName, ' ', sender.LastName) AS SenderName,
                    (CASE WHEN sender.ID = @UserID THEN senderAccount.Name ELSE receiverAccount.Name END) AS AccountName,
                    CONCAT(receiver.FirstName, ' ', receiver.LastName) AS ReceiverName,
                    t.Amount,
                    t.Date
                FROM
                    `transaction` AS t
                    INNER JOIN Account AS senderAccount ON t.Transferred_from = senderAccount.ID
                    INNER JOIN Account AS receiverAccount ON t.Transferred_to = receiverAccount.ID
                    INNER JOIN User AS sender ON senderAccount.UserID = sender.ID
                    INNER JOIN User AS receiver ON receiverAccount.UserID = receiver.ID
                WHERE
                    senderAccount.UserID = @UserID
                    OR receiverAccount.UserID = @UserID;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", userID);

            List<Tuple<string, string, string, double, DateTime>> transactions = new List<Tuple<string, string, string, double, DateTime>>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string senderName = reader.GetString("SenderName");
                    
                    string receiverName = reader.GetString("ReceiverName");

                    string accountName = reader.GetString("AccountName");

                    double amount = reader.GetDouble("Amount");

                    DateTime date = reader.GetDateTime("Date");

                    Tuple<string, string, string, double, DateTime> transaction = Tuple.Create(senderName, receiverName, accountName, amount, date);
                    transactions.Add(transaction);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return transactions;
        }




        // select name and balance from all Savingsaccounts
        // select savingsaccounts out of database and put them in to dictionary

        public Dictionary<string, double> SelectOverwiewSavingAccounts(int UserID)
        {
            string query = $"SELECT * FROM `account` WHERE UserID = {UserID} and isSavingsAccount = 1;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            Dictionary<string, double> savingsAccounts = new Dictionary<string, double>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];

                    double balanceDB = reader.GetDouble(reader.GetOrdinal("Balance"));

                    savingsAccounts[name] = balanceDB;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            return savingsAccounts;

        }




        // select name and balance from all Currentaccounts
        // select currentaccounts out of database and put them in to dictionary

        public Dictionary<string, double> SelectOverwiewCurrentAccounts(int UserID)
        {
            string query = $"SELECT * FROM `account` WHERE UserID = {UserID} and isSavingsAccount = 0;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            Dictionary<string, double> currentAccounts = new Dictionary<string, double>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string name = (string)reader["Name"];

                    double balanceDB = reader.GetDouble(reader.GetOrdinal("Balance"));

                    currentAccounts[name] = balanceDB;
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            return currentAccounts;

        }



        // select user info to give an admin overview of all users


        public List<Tuple<int, string, string, int, string, bool>> SelectUserOverview()
        {
            string query = $"SELECT * FROM `user` WHERE isActive = 1;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            List<Tuple<int, string, string, int, string, bool>> users = new List<Tuple<int, string, string, int, string, bool>>();

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ID = (int)reader["ID"];

                    string Firstname = (string)reader["Firstname"];

                    string Lastname = (string)reader["Lastname"];

                    int PIN = (int)reader["PIN"];

                    string Email = (string)reader["Email"];

                    bool isActive = (bool)reader["isActive"];

                    Tuple<int, string, string, int, string, bool> user = Tuple.Create(ID, Firstname, Lastname, PIN, Email, isActive);

                    users.Add(user);
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            return users;

        }



        public Image SelectProfilePicture(int UserID)
        {
            string query = $"SELECT ProfilePicture FROM user WHERE ID = {UserID}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read() && !reader.IsDBNull(0))
                {
                    byte[] profilePictureData = (byte[])reader["ProfilePicture"];
                    MemoryStream ms = new MemoryStream(profilePictureData);
                       

                    return Image.FromStream(ms);
                    

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            
            return null;

        }




        public User LoginAttempt(string email, int pin)
        {
            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM User WHERE Email = @Email";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    connection.Open();

                    int userCount = Convert.ToInt32(command.ExecuteScalar());
                    if (userCount == 0)
                    {
                        // User not found, return null
                        return null;
                    }
                }

                query = "SELECT ID, FirstName, LastName, isActive FROM User WHERE Email = @Email AND PIN = @PIN";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PIN", pin);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve user information from the database
                            int userID = (int)reader["ID"];

                            string firstName = reader.GetString("FirstName");

                            string lastName = reader.GetString("LastName");

                            bool isActive = (bool)reader["isActive"];

                            if(isActive) 
                            {

                                // Create a new User object with the retrieved information
                                User user = new User(userID, firstName, lastName, email, pin);

                                // Return the user object
                                return user;
                            }
                            else
                            {
                                return null;
                            }
                            
                        }
                    }
                }
            }

            // Invalid login credentials or other errors occurred
            return null;
        }



        public Admin SelectAdmin(string email, int pin)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT  FirstName, LastName, PIN, Email FROM Admin WHERE Email = @Email AND PIN = @PIN";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PIN", pin);

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            string firstName = reader.GetString("FirstName");
                            string lastName = reader.GetString("LastName");
                            string adminEmail = reader.GetString("Email");
                            int adminPIN = (int)reader["PIN"];

                            // Create a new Admin object with the retrieved information
                            Admin admin = new Admin( firstName, lastName, adminEmail, adminPIN);

                            // Return the Admin object
                            return admin;
                        }
                    }
                }
            }

            // Admin not found
            return null;
        }

        public List<Tuple<int, int, int, double, DateTime>> SelectAutoTransactions()
        {
            List<Tuple<int, int, int, double, DateTime>> autoTransactions = new List<Tuple<int, int, int, double, DateTime>>();

            
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT ID, Transferred_from, Transferred_to, Amount, Scheduled_date FROM auto_transaction WHERE isExecuted = 0;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int autoTransactionID = reader.GetInt32("ID");
                                int accountFromID = reader.GetInt32("Transferred_from");
                                int accountToID = reader.GetInt32("Transferred_to");
                                double amount = reader.GetDouble("Amount");
                                DateTime scheduledDate = reader.GetDateTime(reader.GetOrdinal("Scheduled_date"));

                                autoTransactions.Add(Tuple.Create(autoTransactionID,accountFromID, accountToID, amount, scheduledDate));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred while retrieving auto transactions: " + e.Message);
                    }
                }
            }

            return autoTransactions;
        }

        public bool CheckIfAccountExistsInDatabase(string userFirstname, string userLastname, int accountID)
        {
            string query = $"SELECT Account.ID, User.Firstname, User.Lastname FROM Account INNER JOIN User ON User.ID = Account.UserID WHERE User.FirstName = '{userFirstname}' AND User.LastName = '{userLastname}' AND account.ID = {accountID};";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();

                return count > 0; // Return true if count is greater than 0, indicating a record is found
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; // Return false if an exception occurs
            }

        }




        //////////////////////////////////////////////     updating     //////////////////////////////////////////////////////





        public void UpdateProfilePicture(int userId)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Profile Picture";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Read the selected image file
                byte[] newPictureData = File.ReadAllBytes(openFileDialog.FileName);

                using (var connection = new MySqlConnection(connectionString))
                {
                    string query = $"UPDATE user SET ProfilePicture = @newPictureData WHERE ID = @userId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newPictureData", newPictureData);
                        command.Parameters.AddWithValue("@userId", userId);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Profile picture updated successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while updating the profile picture: " + ex.Message);
                        }
                    }
                }
            }

            

        }


        public void Update(string whatToUpdate, string updatedValue, int UserID)
        {
            string query = $"UPDATE user SET {whatToUpdate.ToLower()} = '{updatedValue}' WHERE ID = {UserID}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        public void MakeUserAccountInActive(int UserID)
        {
            string query = $"UPDATE user SET isActive = 0 WHERE ID = {UserID}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void UpdateAccountBalance(int accountID, double newBalance)
        {
            string query = $"UPDATE Account SET Balance = {newBalance} WHERE ID = {accountID}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }



        public void UpdateAutoTransactionExecutedStatus(int autoTransactionID)
        {
            string query = $"UPDATE auto_transaction SET isExecuted = 1 WHERE ID = {autoTransactionID}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Updated {rowsAffected} row(s).");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error updating auto transaction executed status: " + e.Message);
                    }
                }
            }
        }







    }

}   
