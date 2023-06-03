using Microsoft.VisualBasic.ApplicationServices;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    class User: People
    {

        private int PinCheck { get; set; }
        public int UserID { get; set; }

        private Data data = new Data();
        public User(string firstName, string lastName, string email, int pin, int pincheck) : base(firstName, lastName, email, pin)
        {
            try
            {
                this.PinCheck = pincheck;
                if (PinCheck == pin)
                {
                    this.Pin = pin;
                }
                else
                {
                    throw new Exception();
                }
                this.UserID = data.InsertUser(FirstName, LastName, Pin, Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Pin does not match");

            }
            
        }

        // second constructor, when user logs in, user can't be added again to the database
        // and user attributes come out of database
        public User(int userID, string firstName, string lastName,string email, int pin) : base(firstName, lastName, email, pin)
        {
            this.UserID = userID; 
        }



        public void EditProfilePic(User user)
        {
            Data data = new Data();

            data.UpdateProfilePicture(user.UserID);
        }

        public Image ShowProfilePic(User user)
        {
            Data data = new Data();

            Image image = data.SelectProfilePicture(user.UserID);

            return image;


        }

    }
}
