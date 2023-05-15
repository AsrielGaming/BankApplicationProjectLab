﻿using BankApplicationProjectLab.Classes;
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
        public string Email { get; set; }
        public int Pin { get; set; }
        public int UserID { get; set; }

        public People(string firstName, string lastName, string email, int pin, int userID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Pin = pin;
            this.UserID = userID;
        }

        public void Login(string Email, int PIN)
        {
            Data data = new Data();
            
            bool loginSuccessful = data.LoginAttempt(Email, PIN);

            if (loginSuccessful)
            {
                Console.WriteLine("login succesful");
            }
            else
            {
                Console.WriteLine("login failed, provide correct credentials or sign up");
            }
        }

        public void EditFirstName(string updatedFirstname, People user)
        {
            Data data = new Data();

            data.Update("FirstName", updatedFirstname, user.UserID);
        }

        public void EditLastName(string updatedLastname, People user)
        {
            Data data = new Data();

            data.Update("Lastname", updatedLastname, user.UserID);
        }

        public void EditPIN(string updatedPIN, People user)
        {
            Data data = new Data();

            data.Update("PIN", updatedPIN, user.UserID);
        }

        public void CreateUserAccount()
        {
            // this function is not necessary because a new user will be added via the constructor
        }

        public void DeleteUserAccount(People user)
        {
            Data data = new Data();

            data.MakeUserAccountInActive(user.UserID);
        }

    }
}
