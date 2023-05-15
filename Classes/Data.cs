using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Transactions;

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
        public int InsertUser(User user)
        {
            string query = $"INSERT INTO user(Firstname,Lastname,Pin,Email) " +
              $"VALUES ('{user.FirstName}', " +
              $"'{user.LastName}'," +
              $"{user.Pin}, " +
              $"'{user.Email}');";


            return this.Insert(query);
        }

        // function to create a new savingsAccount in the database when creating a new savingsaccount in program
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

        // function to create a new currentAccount in the database when creating a new currentaccount in program
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

        // insert admin in the database when creating a new admin in program
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


        // select transaction history from certain user, both when he is "transaction_from" and "transaction_to"
        // getting all transaction data out of DB and putting them in a tuple, making a list named transactions from these tuples. so 1 tuple contains all data about 1 transaction


        public List<Tuple<int, int, double, DateTime>> SelectTransactionHistory(User user)
        {
            string query = $"SELECT* FROM `transaction` WHERE Transferred_from = {user.UserID} or Transferred_to = {user.UserID};";

            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            List<Tuple<int, int, double, DateTime>> transactions = new List<Tuple<int, int, double, DateTime>>(); ;

            try
            {
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int from = (int)reader["Transferred_from"];

                    int to = (int)reader["Transferred_to"];

                    double amount = reader.GetDouble(reader.GetOrdinal("Amount"));

                    DateTime date = reader.GetDateTime(reader.GetOrdinal("Date"));

                    Tuple<int, int, double, DateTime> transaction = Tuple.Create(from, to, amount, date);

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

        public Dictionary<string, double> SelectOverwiewSavingAccounts(User user)
        {
            string query = $"SELECT * FROM `account` WHERE UserID = {user.UserID} and isSavingsAccount = 1;";

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

        public Dictionary<string, double> SelectOverwiewCurrentAccounts(User user)
        {
            string query = $"SELECT * FROM `account` WHERE UserID = {user.UserID} and isSavingsAccount = 0;";

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
            string query = $"SELECT * FROM `user`;";

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




        //////////////////////////////////////////////     selecting     //////////////////////////////////////////////////////





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
    }

}   
