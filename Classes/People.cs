using BankApplicationProjectLab.Classes;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_InspirationLab_2023.Classes
{
    class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        protected string Email { get; set; }
        protected int Pin { get; set; }
        //public int UserID { get; set; }

        public People(string firstName, string lastName, string email, int pin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Pin = pin;
            //this.UserID = userID;
        }

        public static BankApplicationProjectLab.Classes.User Login(string email, int pin)
        {
            Data data = new Data();

            BankApplicationProjectLab.Classes.User loggedInUser = data.LoginAttempt(email, pin);

            if (loggedInUser != null)
            {
                Console.WriteLine("Login successful");
                return loggedInUser;
            }
            else
            {
                Console.WriteLine("Login failed. Provide correct credentials or sign up.");
                return null;
            }
        }


        public void EditFirstName(string updatedFirstname, BankApplicationProjectLab.Classes.User user)
        {
            Data data = new Data();

            data.Update("FirstName", updatedFirstname, user.UserID);
        }

        public void EditLastName(string updatedLastname, BankApplicationProjectLab.Classes.User user)
        {
            Data data = new Data();

            data.Update("Lastname", updatedLastname, user.UserID);
        }

        public void EditPIN(string updatedPIN, BankApplicationProjectLab.Classes.User user)
        {
            Data data = new Data();

            data.Update("PIN", updatedPIN, user.UserID);
        }

        

        public void DeleteUserAccount(BankApplicationProjectLab.Classes.User user)
        {
            Data data = new Data();

            data.MakeUserAccountInActive(user.UserID);
        }

    }
}
