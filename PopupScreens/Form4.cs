using BankApplicationProjectLab.PageForms;
using Project_InspirationLab_2023.Classes;
using BankApplicationProjectLab.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplicationProjectLab.PopupScreens
{
    public partial class Form4 : Form
    {
        private string email;
        private int pin;

        public Form4(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Save changes
            People loggedInUser = People.Login(email, pin);
            string updatedLastname = textBox1.Text;
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            // Store the original first name for comparison
            string originalLastname = correctUser.LastName;

            // Check if the updated first name is a non-empty string and contains only letters
            if (!string.IsNullOrEmpty(updatedLastname) && IsAllLetters(updatedLastname))
            {
                // Update the first name
                loggedInUser.EditLastName(updatedLastname, correctUser);

                // Go to the user account page
                this.Hide();
                UserAccountPage userAccountPage = new UserAccountPage(email, pin);
                userAccountPage.Show();
            }
            else
            {
                // Stay on the current page or display an error message
                MessageBox.Show("Invalid last name. Please enter a valid name without numbers or special characters.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage(email, pin);
            userAccountPage.Show();
        }
    }
}
