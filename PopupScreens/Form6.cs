using BankApplicationProjectLab.PageForms;
using BankApplicationProjectLab.Classes;
using Project_InspirationLab_2023.Classes;
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
    public partial class Form6 : Form
    {
        private string email;
        private int pin;

        public Form6(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

        }

        private bool IsAllDigits(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Save changes
            People loggedInUser = People.Login(email, pin);
            string updatedFirstname = textBox1.Text;
            User correctUser = (User)loggedInUser;
            //int loggedInUserUserId = correctUser.UserID;

            string oldPin = textBox1.Text;
            string updatedPin = textBox2.Text;
            string updatedPinCheck = textBox3.Text;

            // Check if the updatedPin and updatedPinCheck are not empty and are numeric
            if (string.IsNullOrEmpty(updatedPin) || string.IsNullOrEmpty(updatedPinCheck) || !int.TryParse(updatedPin, out int updatedPinInt))
            {
                MessageBox.Show("Invalid PIN. Please enter a numeric PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if old pin is correct
            bool answer = correctUser.IsPinEqual(updatedPinInt);
            if (answer == false)
            {
                MessageBox.Show("Old PIN is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if updatedPin and checkUpdated pin are the same
            if (updatedPin != updatedPinCheck)
            {
                MessageBox.Show("PIN and PIN confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Update the PIN
            correctUser.EditPIN(updatedPin, correctUser);

            People loggedInUser2 = People.Login(email, updatedPinInt);

            // Go to the user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage(email, updatedPinInt);
            userAccountPage.Show();

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
            // old pin
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // new pin
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // new pin check
        }
    }
}
