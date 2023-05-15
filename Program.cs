using BankApplicationProjectLab.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using Project_InspirationLab_2023.Classes;
using System.Security.Policy;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankApplicationProjectLab
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());




            // eigen deel: NIET VERGETEN OUTPUT TYPE TERUG TE ZETTEN NAAR WINDOWS APPLICATION
            // WANT NU NAAR CONSOLE APPLICATION GEZET OM PRINTEN TE KUNNEN DOEN NAAR GEWONE CONSOLE OM CODE TE TESTEN




            /////////////////////////////// test to insert a user ////////////////////////////////////////////////////

            /*
            Data data = new Data();

            // Create a new User object with the necessary data
            User newUser = new User("Arne", "Vernaillen", "arnevernaillen@hotmail.com", 4321, 4321, 1);
            

            // Call the InsertUser method to insert the new user into the database
            int insertedId = data.InsertUser(newUser);

            // Check if the insertion was successful
            if (insertedId != -1)
            {
                Console.WriteLine("User inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert user.");
            } */


            ///////////////////////////// test to insert a Savings account ////////////////////////////////////////////////

            /*
            Data data = new Data();

            // Create a new User object with the necessary data
            SavingsAccount newsavingsAccount = new SavingsAccount("spaarboekje", "BE5816518161", 51565, 1, true);


            // Call the InsertUser method to insert the new user into the database
            int insertedId = data.InsertSavingsAccount(newsavingsAccount);

            // Check if the insertion was successful
            if (insertedId != -1)
            {
                Console.WriteLine("Savings account inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert savings account.");
            } */

            ///////////////////////////// test to insert a current account ////////////////////////////////////////////////

            /*
            Data data = new Data();

            // Create a new User object with the necessary data
            CurrentAccount newcurrentAccount = new CurrentAccount("zichtrekening", "BE5816518161", 51565, 2, false);


            // Call the InsertUser method to insert the new user into the database
            int insertedId = data.InsertCurrentAccount(newcurrentAccount);

            // Check if the insertion was successful
            if (insertedId != -1)
            {
                Console.WriteLine("Current account inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert current account.");
            }
            */


            ////////////////////////// test to insert an admin ////////////////////////////////////////////////////////////////////////

            /*

            Data data = new Data();

            // Create a new User object with the necessary data
            Admin newAdmin = new Admin("admin", "admin", "admin@admin.com", 4321, 1);


            // Call the InsertUser method to insert the new user into the database
            int insertedId = data.InsertAdmin(newAdmin);

            // Check if the insertion was successful
            if (insertedId != -1)
            {
                Console.WriteLine("Admin inserted successfully. ID: " + insertedId);
            }
            else
            {
                Console.WriteLine("Failed to insert admin.");
            }
            */




            ////////////////////////// test to execute transaction ////////////////////////////////////////////////////////////////////////



            // Classes before user because name user is ambigiuous.
            // Create two users and an account to test the transaction creation and input into database.
            // Works with Account, savings-and currentaccount
            /*
            Classes.User userFrom = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 9);
            Classes.User userTo = new Classes.User("Daniel", "Janssens", "Danny@gmail.com", 1234, 1234, 56);

            SavingsAccount newAccount = new SavingsAccount("Zichtrekening", "BE5285315", 500500, 1, true);

            newAccount.NewTransaction(userFrom, userTo, 985224) ;
            */




            ////////////////////////// test to check transaction history ///////////////////////////////////////////////////////////////////////////

            /*
            
            Classes.User user = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 9);

            CurrentAccount currentaccount = new CurrentAccount("Zichtrekening", "BE5285315", 500500, 1, true);

            List<Tuple<int, int, double, DateTime>> transactions = currentaccount.OverViewHistory(user);

            // loopen over list met tuples erin. .item om verschillende items (transactiegegevens) uit de tuple te halen
            foreach (Tuple<int, int, double, DateTime> transaction in transactions)
            {
                int from = transaction.Item1;
                int to = transaction.Item2;
                double amount = transaction.Item3;
                DateTime date = transaction.Item4;

                Console.WriteLine("From: " + from + ", To: " + to + ", Amount: " + amount + ", Date: " + date);
            }
            */




            ////////////////////////// test to give overview of accounts ///////////////////////////////////////////////////////////////////////////

            // works both for  savings and current accounts



            /*
            Classes.User user = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 2);

            CurrentAccount account = new CurrentAccount("spaarrekening", "BE5285315", 500500, 1, true);

            Dictionary<string, double> currentAccounts = account.OverviewCurrentAccount(user);


            foreach (KeyValuePair<string, double> entry in currentAccounts)
            {
                string name = entry.Key;
                double balance = entry.Value;
                Console.WriteLine("Name: " + name + " ---> Account Balance: " + balance);
            }

            */

            ////////////////////////// test to give admin's overview of users ///////////////////////////////////////////////////////////////////////////

            /* 
             Admin admin = new Admin("admin", "admin", "admin@admin.com", 4321, 1);

             List<Tuple<int, string, string, int, string, bool>> users = admin.GiveUserAccountOverview();


             foreach (Tuple<int, string, string, int, string, bool> user in users)
             {
                 int ID = user.Item1;
                 string Firstname = user.Item2;
                 string Lastname = user.Item3;
                 int PIN = user.Item4;
                 string Email = user.Item5;
                 bool isActive = user.Item6;

                 Console.WriteLine("ID: " + ID + ", Firstname: " + Firstname + ", Lastname: " + Lastname + ", PIN: " + PIN + ", Email: " + Email + ", isActive: " + isActive);


             }

             */



            ///////////////////////////////////////  test to update profile picture  ////////////////////////////////////


            /*
            Classes.User user = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 7);

            user.EditProfilePic(user);
            */


            ///////////////////////////////////////  test to select profile picture out of database  ////////////////////////////////////

            /*

            Classes.User user = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 8);
            Image image = user.ShowProfilePic(user);

            string filePath = @"C:\Users\piete\OneDrive - Thomas More\Thomas More-Pieter\Semester 2\Project Lab\testFolderTosaveProfilePics\profile.jpg";

            if(image != null)
            { 
                
                image.Save(filePath); 
            
            }
            else
            {
                Console.WriteLine("no profile Picture");
            }
            
            */



            ///////////////////////////////////////  test to update user info  ////////////////////////////////////

            /*
            Admin admin = new Admin("Jefke", "Peeters", "Jefke@gmail.com", 1234, 8);
            Classes.User user = new Classes.User("Jefke", "Peeters", "Jefke@gmail.com", 1234, 1234, 6);

            user.DeleteUserAccount(user);
            */







            ///////////////////////////////////////  test to login  ////////////////////////////////////

            /*
            Classes.User user = new Classes.User("Jefke", "Peeters", "jefkepeeters@gmail.com", 4566, 4566, 8);

            user.Login(user.Email, user.Pin);

            */

            ///////////////////////////////////////  test insert user via createUseraccount ////////////////////////////////////
            /*
            Classes.User user = new Classes.User("Tjaja", "Tjajalana", "Tjajalanatjaja@gmail.com", 6527, 6527, 10);

            user.CreateUserAccount(user);
            */


            //Classes.User user = new Classes.User("Mona", "Moons", "mm@gmail.com", 8712, 8712);

            //Admin admin = new Admin("Pieter", "Beelen", "admin@admin.be", 1234);

            //admin.CreateUserAccount("Jos", "Lembrechts", 6385, "joslemme@gmail.com");


            
        }
    }
}
