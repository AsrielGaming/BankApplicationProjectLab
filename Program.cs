using BankApplicationProjectLab.Classes;
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


            User user = new User("Pieter","Beelen","pieter",1234,1234);

            user.CreateUserAccount();
            user.EditProfilePic();
            
            

           
        }
    }
}
