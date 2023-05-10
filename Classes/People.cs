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
        public int Pin { get; set; }
        protected int UserID { get; set; }

        public People(string firstName, string lastName, string email, int pin, int userID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Pin = pin;
            this.UserID = userID;
        }

        public void Login()
        {
            Console.WriteLine("login werkt");
        }

        public void EditFirstName()
        {
            Console.WriteLine("edit firstname werkt");
        }

        public void EditLastName()
        {
            Console.WriteLine("edit lastname werkt");
        }

        public void EditPIN()
        {
            Console.WriteLine("editPin werkt");
        }

        public void CreateUserAccount()
        {
            Console.WriteLine("CreateUserAccount werkt");
        }

        public void DeleteUserAccount()
        {
            Console.WriteLine("delete user account werkt");
        }

    }
}
