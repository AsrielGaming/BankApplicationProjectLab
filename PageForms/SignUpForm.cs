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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankApplicationProjectLab
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // firstname

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // secondname

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // email
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // pin
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // pincode
        }

        // waar kunnen we deze 3 methoden plaatsen om ze te hergebruiken?
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

        private void button1_Click(object sender, EventArgs e)
        {
            string firstname = textBox1.Text;
            string lastname = textBox2.Text;
            string email = textBox3.Text;
            string pin = textBox4.Text;
            string pinCheck = textBox5.Text;

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

            // add the user to the database and go to login page
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
                // Go to the login page
                this.Hide();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else
            {
                MessageBox.Show("Error occurred while inserting the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            //ga naar login pagina
            this.Hide();
            LoginForm loginPage = new LoginForm();
            loginPage.Show();
        }

        private void SignUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }
    }
}
