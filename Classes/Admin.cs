using Microsoft.VisualBasic.ApplicationServices;
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
        public Admin(string firstName, string lastName, string email, int pin, int userID): base(firstName, lastName, email, pin, userID)
        {
            
        }

        public List<Tuple<int, string, string, int, string, bool>> GiveUserAccountOverview()
        {
            Data data = new Data();

            List<Tuple<int, string, string, int, string, bool>> users = data.SelectUserOverview();

            return users;
        }

        

    }
}
