using BankApplicationProjectLab.PageForms;
using Project_InspirationLab_2023.Classes;
using BankApplicationProjectLab.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplicationProjectLab.PopupScreens
{

    public partial class Form2 : Form
    {
        private string email;
        private int pin;
        private int userID;

        public Form2(string email, int pin, int userID)
        {
            InitializeComponent();

            this.email = email;
            this.pin = pin;
            this.userID = userID;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete
            string chosenId = userID.ToString();
            int chosenIdInt = int.Parse(chosenId);

            // Retrieve the list of tuples from your backend function or wherever it's available
            List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

            // Check if there is a matching user with the given userID
            Tuple<int, string, string, int, string, bool> matchingUser = userList.FirstOrDefault(user => user.Item1 == chosenIdInt);

            if (matchingUser != null)
            {
                // Retrieve the variables from the matchingUser tuple
                int userId = matchingUser.Item1;
                string firstName = matchingUser.Item2;
                string lastName = matchingUser.Item3;
                int pin = matchingUser.Item4;
                string email = matchingUser.Item5;

                // Create a User object using the retrieved variables
                User userObject = new User(userId, firstName, lastName, email, pin);

                // delete user
                //get checkbox variable
                bool checkboxChecked = checkBox1.Checked;

                if (checkboxChecked == true)
                {
                    userObject.DeleteUserAccount(userObject);

                    MessageBox.Show("Account successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Go back to admin page
                    this.Hide();
                    AdminControls adminControls = new AdminControls();
                    adminControls.Show();
                }

                else
                {
                    MessageBox.Show("You must give consent to delete the account", "Consent Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("No user found with the given UserID.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string chosenId = userID.ToString();
            int chosenIdInt = int.Parse(chosenId);

            // Retrieve the list of tuples from your backend function or wherever it's available
            List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

            // Check if there is a matching user with the given userID
            Tuple<int, string, string, int, string, bool> matchingUser = userList.FirstOrDefault(user => user.Item1 == chosenIdInt);

            if (matchingUser != null)
            {
                // Retrieve the variables from the matchingUser tuple
                int userId = matchingUser.Item1;
                string firstName = matchingUser.Item2;
                string lastName = matchingUser.Item3;
                int pin = matchingUser.Item4;
                string email = matchingUser.Item5;

                // Create a User object using the retrieved variables
                User userObject = new User(userId, firstName, lastName, email, pin);

            }
            else
            {
                MessageBox.Show("No user found with the given UserID.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // admin password
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // label with user name and id
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
