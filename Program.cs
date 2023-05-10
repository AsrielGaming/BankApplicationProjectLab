using BankApplicationProjectLab.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using Project_InspirationLab_2023.Classes;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

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


            //User user = new User("Pieter","Beelen","pieter",1234,1234,155555);

            Admin admin = new Admin("Pieter", "Beelen", "pieter@", 1234,155555);

            Account account = new Account("Pieter","BE823405851", 500, 1, true);


            CurrentAccount currentAccount = new CurrentAccount("rek1","BE048456", -5000, 59, false);

            SavingsAccount savingsAccount = new SavingsAccount("rek1", "BE048456", -5000, 59, false);


            // tests to check whether the fucntions work or not and if the inheritance works properly or not
            /*
            savingsAccount.NewTransaction();
            savingsAccount.OverViewHistory();
            savingsAccount.CheckAccountBalance();

            
            admin.GiveUserAccountOverview();

            currentAccount.OverviewCurrentAccount();

            savingsAccount.OverviewSavingsAccount();

            admin.Login();
            admin.EditFirstName();
            admin.EditLastName();
            admin.EditPIN();
            admin.CreateUserAccount();
            admin.DeleteUserAccount();
            

            user.EditProfilePic();

            admin.GiveUserAccountOverview();
            */





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



        }
    }
}
