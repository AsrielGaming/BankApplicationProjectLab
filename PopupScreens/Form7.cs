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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BankApplicationProjectLab.PopupScreens
{
    public partial class Form7 : Form
    {
        private string email;
        private int pin;

        public Form7(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void Form7_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

        }

        private bool IsAllDigits(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            // go back to user account page
            People loggedInUser = People.Login(email, pin);
            string updatedFirstname = textBox1.Text;
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            string oldPin = textBox1.Text;
            int.TryParse(oldPin, out int oldPinInt);

            // Check if the updated PIN is a non-empty string and contains only numbers
            if (string.IsNullOrEmpty(oldPin) || !IsAllDigits(oldPin))
            {
                MessageBox.Show("Invalid PIN. Please enter a valid numeric PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if old pin is correct
            bool answer = correctUser.IsPinEqual(oldPinInt);
            //if (answer == false)
            //{
            //    MessageBox.Show("Old PIN is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (!string.IsNullOrEmpty(oldPin) && IsAllDigits(oldPin))
            {
                correctUser.DeleteUserAccount(correctUser);

                MessageBox.Show("Account successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Go to the user account page
                this.Hide();
                LoginForm loginform = new LoginForm();
                loginform.Show();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage(email, pin);
            userAccountPage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // pin box
        }
    }
}
