using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project_InspirationLab_2023.Classes
{
    class People
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        protected int Pin { get; set; }

        public People(string firstName, string lastName, string email, int pin)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Pin = pin;
        }

        public void Login()
        {

        }

        public void EditFirstName()
        {

        }

        public void EditLastName()
        {

        }

        public void EditPIN()
        {

        }

        public void DeleteUserAccount()
        {

        }

    }
}
