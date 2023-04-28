using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_InspirationLab_2023.Classes
{
    internal class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        protected int Pin { get; set; }

        public People(string firstName, string lastName, string email, int pin)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Pin = pin;
        }

        public void login()
        {

        }

        public void editFirstName()
        {

        }

        public void editLastName()
        {

        }

        public void editPIN()
        {

        }

        public void deleteUserAccount()
        {

        }

    }
}
