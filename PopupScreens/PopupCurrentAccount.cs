using BankApplicationProjectLab.Classes;
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
using System.Xml.Linq;

namespace BankApplicationProjectLab.PageForms
{
    public partial class PopupCurrentAccount : Form
    {
        private string email;
        private int pin;

        public PopupCurrentAccount(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void PopupCurrentAccount_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        private bool IsDouble(string value)
        {
            return double.TryParse(value, out _);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // submit 

            string accountHolder = textBox1.Text;
            string accountName = textBox3.Text;
            string startingBalance = textBox2.Text;

            //check dat niets leeg is
            if (string.IsNullOrEmpty(accountHolder) || string.IsNullOrEmpty(accountName) || string.IsNullOrEmpty(startingBalance))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check of names string zijn
            if (!IsAllLetters(accountHolder) || !IsAllLetters(accountName))
            {
                MessageBox.Show("First name and last name must contain only letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string name = loggedInUser.FirstName + " " + loggedInUser.LastName;

            //if (userId != -1)
            //{
                // Aanmaken default accounts
                //data.InsertCurrentAccount(userId, name, 1000, true);

                MessageBox.Show("User inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // redirect to homepage
                this.Hide();
                Homepage homepage = new Homepage(email, pin);
                homepage.Show();

            //}
            //else
            //{
                //MessageBox.Show("Error occurred while inserting the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void PopupCurrentAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // redirect to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // name account holder
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // name account
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // starting balance
        }
    }
}
