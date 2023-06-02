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

namespace BankApplicationProjectLab.PageForms
{
    public partial class Transaction : Form
    {
        private string email;
        private int pin;

        public Transaction(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            // give in amount of money
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Transaction_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //make transaction
            People loggedInUser = People.Login(email, pin);
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            //get variables
            // Checkboxs
            bool checkboxOwnAccount = checkBox1.Checked;
            bool checkboxOtherAccount = checkBox2.Checked;
            bool checkboxAutoPayment = checkBox3.Checked;

            // Dropdown Lists
            //string dropdownFromAccount = comboBox1.SelectedItem.ToString();
            //string dropdownToAccount= comboBox2.SelectedItem.ToString(); //cannot be from account

            // Textboxes
            string accountHolder = textBox1.Text;
            string accountNumber = textBox2.Text;

            // Date Picker
            DateTime dateAutoPayment = dateTimePicker1.Value;

            // balance
            decimal numericUpDownBalance = numericUpDown1.Value;

            // check correctness of all inputs



            // make the transaction happen + add to transactions 



            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            // hello name label
        }

        private void Transaction_Load(object sender, EventArgs e)
        {
            // veranderen van username in hello username
            People loggedInUser = People.Login(email, pin);
            User correctUser = (User)loggedInUser;

            label20.Text = "Hello " + loggedInUser.FirstName;

            //show the picture
            Image profilePic = correctUser.ShowProfilePic(correctUser);
            pictureBox4.Image = profilePic;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // account list
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox own account
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox other person's account
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //checkbox automatic payment
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // dropdown own accounts (without from account)
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // name account holder
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // account number
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // date chooser
        }
    }
}
