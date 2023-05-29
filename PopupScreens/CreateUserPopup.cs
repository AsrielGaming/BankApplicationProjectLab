using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PageForms;
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
    public partial class CreateUserPopup : Form
    {
        public CreateUserPopup()
        {
            InitializeComponent();
        }

        private void CreateUserPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating email format
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        private bool IsAllDigits(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //create user
            string firstname = textBox1.Text;
            string lastname = textBox6.Text;
            string email = textBox7.Text;
            string pin = textBox8.Text;
            string pinCheck = textBox4.Text;

            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pin) || string.IsNullOrEmpty(pinCheck))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if first name and last name are strings
            if (!IsAllLetters(firstname) || !IsAllLetters(lastname))
            {
                MessageBox.Show("First name and last name must contain only letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if PIN and PIN confirmation are numbers
            if (!IsAllDigits(pin) || !IsAllDigits(pinCheck))
            {
                MessageBox.Show("PIN and PIN confirmation must contain only numbers.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if PIN and PIN confirmation are the same
            if (pin != pinCheck)
            {
                MessageBox.Show("PIN and PIN confirmation do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if email is valid
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //na checks aanmaken nieuwe user
            int pinValue = int.Parse(pin);
            Data data = new Data();
            int userId = data.InsertUser(firstname, lastname, pinValue, email);

            string name = firstname + " " + lastname;

            if (userId != -1)
            {
                // Aanmaken default accounts
                data.InsertCurrentAccount(userId, name, 1000, true);
                data.InsertSavingsAccount(userId, name, 1000, true);

                MessageBox.Show("User inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Go to admin page
                this.Hide();
                AdminControls adminControls1 = new AdminControls();
                adminControls1.Show();
            }
            else
            {
                MessageBox.Show("Error occurred while inserting the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //firstname
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //lastname
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //email
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //pin
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //pin check
        }
    }
}
