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

        public User(string firstName, string lastName, string email, int pin, int pincheck, int userID) : base(firstName, lastName, email, pin, userID)
        {
            this.PinCheck = pincheck;
        }


        public void EditProfilePic()
        {
            Console.WriteLine("editProfilePic werkt");
        }


    }
}
