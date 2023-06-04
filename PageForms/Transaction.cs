using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PopupScreens;
//using Microsoft.VisualBasic.ApplicationServices;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.VisualBasic.ApplicationServices;

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

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z\s]+$");
        }

        private bool IsAllDigits(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Make transaction
            People loggedInUser = People.Login(email, pin);
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            // Get variables
            // Checkboxes
            bool checkboxOwnAccount = checkBox1.Checked;
            bool checkboxOtherAccount = checkBox2.Checked;
            bool checkboxAutoPayment = checkBox3.Checked;

            Account dropdownFromAccount = (Account)comboBox1.SelectedItem;
            Account dropdownToAccount = (Account)comboBox2.SelectedItem;

            // Textboxes
            string accountHolderFirstname = textBox1.Text;
            string accountHolderLastname = textBox2.Text;
            string accountID = textBox3.Text;
            int intAccountID = int.Parse(accountID);

            // Date Picker
            DateTime dateAutoPayment = dateTimePicker1.Value;

            // Balance
            decimal numericUpDownBalance;

            // Check correctness of all inputs
            bool isAutoTransaction = false;

            bool exists = Account.CheckIfAccountExists(accountHolderFirstname, accountHolderLastname, intAccountID);

            if (checkboxAutoPayment)
            {
                // Checkbox 3 is checked, set isAutoTransaction to true
                isAutoTransaction = true;
            }

            if (checkboxOwnAccount && dropdownToAccount == null)
            {
                MessageBox.Show("Please choose an account to send money to.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkboxOtherAccount && (string.IsNullOrEmpty(accountHolderFirstname) || string.IsNullOrEmpty(accountHolderLastname) || string.IsNullOrEmpty(accountID)))
            {
                MessageBox.Show("Please provide both the account holder's name and account ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (dropdownFromAccount == dropdownToAccount)
            {
                MessageBox.Show("You cannot send money to and from the same account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!decimal.TryParse(numericUpDown1.Value.ToString(), out numericUpDownBalance))
            {
                //not a valid number
                MessageBox.Show("The balance is not a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsAllLetters(accountHolderFirstname) || !IsAllLetters(accountHolderLastname))
            {
                MessageBox.Show("First name and last name must contain only letters.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!IsAllDigits(accountID))
            {
                MessageBox.Show("Account ID must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (exists == false)
            {
                MessageBox.Show("The Account you are trying to send money to doesn't exist in our database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Make the transaction happen + add to transactions 
                if (isAutoTransaction)
                {
                    // Call auto-transaction function

                }
                else
                {
                    // Call transaction function
                    //Account.NewTransaction(accountFromID, accountToID, amount);
                }
            }

            // Go to homepage
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
            int loggedInUserUserId = correctUser.UserID;
            //Console.WriteLine(loggedInUserUserId);

            label20.Text = "Hello " + loggedInUser.FirstName;

            // Show the picture
            Image profilePic = correctUser.ShowProfilePic(correctUser);
            pictureBox4.Image = profilePic;

            // Give list of accounts
            //Dictionary<double, string> accountDictionary = GetAllAccountsOfUser(loggedInUserUserId);

            //if (accountDictionary != null && accountDictionary.Count > 0)
            //{
            // Bind the account dictionary to comboBox1 and comboBox2
            //    comboBox1.DataSource = new BindingSource(accountDictionary, null);
            //    comboBox1.DisplayMember = "Key";
            //    comboBox1.ValueMember = "Value";

            //    comboBox2.DataSource = new BindingSource(accountDictionary, null);
            //    comboBox2.DisplayMember = "Key";
            //    comboBox2.ValueMember = "Value";
            //}
            //else
            //{
            // Handle the case when the account dictionary is empty or null
            //    MessageBox.Show("The account dictionary is empty or null.", "Empty or Null Dictionary");
            //}
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
            // give list of accounts 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // firstname account holder
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // lastname account holder
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // date chooser
        }

        //public Dictionary<double, string> GetAllAccountsOfUser(int userID)
        //{
        //    Dictionary<string, string> accountDictionary = new Dictionary<string, string>();
        //    People loggedInUser = People.Login(email, pin);

        //    Dictionary<string, double> savingsAccounts = SavingsAccount.OverviewSavingsAccount(userID);
        //    Dictionary<string, double> currentAccounts = CurrentAccount.OverviewCurrentAccount(userID);

        // Add savings accounts to accountDictionary
        //    foreach (var account in savingsAccounts)
        //    {
        //string accountName = account.Key;
        //        string betterAccountName = "Savings Account " + loggedInUser.FirstName;
        //        double accountId = GetAccountIdFromName(accountName); //get account ID 
        //        accountDictionary[accountId] = betterAccountName;
        //    }

        // Add current accounts to accountDictionary
        //    foreach (var account in currentAccounts)
        //    {
        //string accountName = account.Key;
        //        string betterAccountName = "Current Account " + loggedInUser.FirstName;
        //        double accountId = GetAccountIdFromName(accountName); //get account ID 
        //        accountDictionary[accountId] = betterAccountName;
        //    }
        //    return accountDictionary;
        //}

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // account id
        }
    }
}