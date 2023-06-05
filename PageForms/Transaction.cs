using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PopupScreens;
using MySqlConnector;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
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
            try
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

                // Inside the button2_Click event handler

                // Account dropdown
                int? selectedAccountIdFrom = null;
                string selectedAccountNameFrom = string.Empty;
                int? selectedAccountIdTo = null;
                string selectedAccountNameTo = string.Empty;

                if (checkboxOwnAccount && comboBox1.SelectedValue != null)
                {
                    selectedAccountIdFrom = (int)comboBox1.SelectedValue;
                    selectedAccountNameFrom = comboBox1.SelectedItem.ToString();
                }

                if (checkboxOtherAccount && comboBox2.SelectedValue != null)
                {
                    selectedAccountIdTo = (int)comboBox2.SelectedValue;
                    selectedAccountNameTo = comboBox2.SelectedItem.ToString();
                }

                // Textboxes
                string accountHolderFirstname = null;
                string accountHolderLastname = null;
                string accountID = null;
                int intAccountID = 0;

                if (checkboxOtherAccount)
                {
                    accountHolderFirstname = textBox1.Text;
                    accountHolderLastname = textBox2.Text;
                    accountID = textBox3.Text;
                    int.TryParse(accountID, out intAccountID);
                }

                // Check correctness of all inputs
                bool isAutoTransaction = checkboxAutoPayment;

                double numericUpDownBalance = 0.0;
                int amountOfTimesInt = 0;

                //checks that always need to happen
                if (comboBox1.SelectedValue == null || numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Please select an account and amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!double.TryParse(numericUpDown1.Value.ToString(), out numericUpDownBalance))
                {
                    MessageBox.Show("The amount must be a valid numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //checks for checkbox 1
                if (checkBox1.Checked)
                {
                    //gives error
                    if (selectedAccountIdFrom == null || selectedAccountIdTo == null)
                    {
                        MessageBox.Show("Please select all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (selectedAccountIdFrom == selectedAccountIdTo)
                    {
                        MessageBox.Show("Please select a different account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                //checks for checkbox 2
                else if (checkBox2.Checked)
                {
                    if (checkboxOtherAccount && (string.IsNullOrEmpty(accountHolderFirstname) || string.IsNullOrEmpty(accountHolderLastname) || string.IsNullOrEmpty(accountID)))
                    {
                        MessageBox.Show("Please provide values for all three textboxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (!IsAllLetters(accountHolderFirstname) || !IsAllLetters(accountHolderLastname))
                    {
                        MessageBox.Show("First and lastname must be strings.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (checkboxOtherAccount && !int.TryParse(accountID, out intAccountID))
                    {
                        MessageBox.Show("Account ID must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //checks for checkbox 3
                if (checkBox3.Checked)
                {
                    if (checkboxAutoPayment && comboBox3.SelectedValue == null)
                    {
                        MessageBox.Show("Please select how much you'd like to repeat this transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (checkboxAutoPayment && !int.TryParse(comboBox3.SelectedValue.ToString(), out amountOfTimesInt))
                    {
                        MessageBox.Show("Please enter a valid numeric value for the amount of times.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Make the transaction happen + add to transactions 
                if (isAutoTransaction)
                {
                    // Call auto-transaction function
                    string selectedFrequency = comboBox3.SelectedItem?.ToString();

                    Account.NewAutoTransaction(selectedAccountIdFrom.Value, selectedAccountIdTo.Value, numericUpDownBalance, selectedFrequency, amountOfTimesInt);

                    // Go to homepage
                    this.Hide();
                    Homepage homepage = new Homepage(email, pin);
                    homepage.Show();
                }
                else
                {
                    if (checkboxOwnAccount)
                    {
                        // Get the account ID from the dropdown
                        Account.NewTransaction(selectedAccountIdFrom.Value, selectedAccountIdTo.Value, numericUpDownBalance);
                    }
                    else if (checkBox2.Checked)
                    {
                        // Use accountID as the variable
                        int accountIdTo;
                        int.TryParse(accountID, out accountIdTo);
                        Account.NewTransaction(selectedAccountIdFrom.Value, accountIdTo, numericUpDownBalance);
                    }

                    // Go to homepage
                    this.Hide();
                    Homepage homepage = new Homepage(email, pin);
                    homepage.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            //show the picture in the right top corner if there is a pp
            Image profilePic = correctUser.ShowProfilePic(correctUser);
            if (profilePic != null)
            {
                pictureBox4.Image = profilePic;
            }
            else
            {
                string defaultImagePath = Path.Combine("Images", "profileIcon.png");
                if (File.Exists(defaultImagePath))
                {
                    Image defaultProfileIcon = Image.FromFile(defaultImagePath);
                    pictureBox4.Image = defaultProfileIcon;
                }
                else
                {
                    MessageBox.Show("Profile icon image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Give list of accounts
            Dictionary<int, string> accountDictionary = Account.OverViewAllAccountsFromUser(loggedInUserUserId);

            // Populate comboBox1 with Account IDs and Names
            comboBox1.DataSource = new BindingSource(accountDictionary, null);
            comboBox1.DisplayMember = "Value"; // Display the account name
            comboBox1.ValueMember = "Key"; // Use the account ID as the underlying value

            // Populate comboBox2 with Account IDs and Names
            comboBox2.DataSource = new BindingSource(accountDictionary, null);
            comboBox2.DisplayMember = "Value"; // Display the account name
            comboBox2.ValueMember = "Key"; // Use the account ID as the underlying value

            // Populate frequencey box
            comboBox3.Items.AddRange(new object[] { "daily", "weekly", "monthly" });

            //checking and unchecking 
            // Check checkbox 1 and uncheck checkboxes 2 and 3
            checkBox1.Checked = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            // Disable TextBox controls and enable ComboBox control for checkbox 1
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox2.Enabled = true;

            // Disable DateTimePicker and NumericUpDown controls for checkbox 3
            dateTimePicker1.Enabled = false;
            numericUpDown2.Enabled = false;
            comboBox3.Enabled = false;
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
            // Disable or enable controls based on checkbox state
            if (checkBox1.Checked)
            {
                // Checkbox 1 is checked, disable TextBox controls and enable ComboBox control
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = true;

                // Uncheck checkbox 2
                checkBox2.Checked = false;
            }
            else
            {
                // Checkbox 1 is unchecked, enable TextBox controls and disable ComboBox control
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Disable or enable controls based on checkbox state
            if (checkBox2.Checked)
            {
                // Checkbox 2 is checked, enable TextBox controls and disable ComboBox control
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox2.Enabled = false;

                // Uncheck checkbox 1
                checkBox1.Checked = false;
            }
            else
            {
                // Checkbox 2 is unchecked, disable TextBox controls and enable ComboBox control
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Disable or enable controls based on checkbox state
            if (checkBox3.Checked)
            {
                // Checkbox 3 is checked, enable DateTimePicker and NumericUpDown controls
                dateTimePicker1.Enabled = true;
                numericUpDown2.Enabled = true;
                comboBox3.Enabled = true;
            }
            else
            {
                // Checkbox 3 is unchecked, disable DateTimePicker and NumericUpDown controls
                dateTimePicker1.Enabled = false;
                numericUpDown2.Enabled = false;
                comboBox3.Enabled = false;
            }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // account id
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // frequency dropdown

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            // amount of times auto payment
        }
    }
}