using BankApplicationProjectLab.Classes;
using Project_InspirationLab_2023.Classes;
using System.Windows.Forms;
using System.Xml;

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


            User user = new User("Pieter","Beelen","pieter",1234,1234,155555);

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

            
            
            

           
        }
    }
}
