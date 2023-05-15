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
            this.PinCheck = pincheck;
            this.UserID = data.InsertUser(firstName, lastName, pin, email);
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
