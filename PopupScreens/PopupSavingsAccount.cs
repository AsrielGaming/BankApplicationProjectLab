using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PageForms;
using Project_InspirationLab_2023.Classes;
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
    public partial class PopupSavingsAccount : Form
    {

        private string email;
        private int pin;

        public PopupSavingsAccount(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PopupSavingsAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z\s]+$");
        }

        private bool IsDouble(string value)
        {
            return double.TryParse(value, out _);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // submit 
            string accountName = textBox5.Text;
            string startingBalance = textBox6.Text;

            //check dat niets leeg is
            if (string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(startingBalance))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check of names string zijn
            if (!IsAllLetters(accountName))
            {
                MessageBox.Show("Account name must be a string.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double balanceValue = double.Parse(startingBalance);
            //check of balance double is
            if (!IsDouble(startingBalance))
            {
                MessageBox.Show("Starting balance must be a double.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //aanmaken nieuw account
            Data data = new Data();
            People loggedInUser = People.Login(email, pin);
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            if (loggedInUserUserId != -1)
            {
                // Aanmaken default accounts
                data.InsertSavingsAccount(loggedInUserUserId, accountName, balanceValue, true);

                MessageBox.Show("Account inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // redirect to homepage
                this.Hide();
                Homepage homepage = new Homepage(email, pin);
                homepage.Show();

            }
            else
            {
                MessageBox.Show("Error occurred while inserting the account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel
            //rederict to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // account name
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            // balance
        }
    }
}
