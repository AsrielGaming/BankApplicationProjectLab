using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationProjectLab.Classes
{
    class Admin: People
    {
        public Admin(string firstName, string lastName, string email, int pin, int userID): base(firstName, lastName, email,pin, userID)
        {
            
        }

        public void GiveUserAccountOverview()
        {
            Console.WriteLine("giveuseraccountoverview werkt");
        }

        

    }
}
