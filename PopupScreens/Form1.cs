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
    public partial class Form1 : Form
    {
        private string email;
        private int pin;
        private int userID;

        public Form1(string email, int pin, int userID)
        {
            InitializeComponent();

            this.email = email;
            this.pin = pin;
            this.userID = userID;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private bool IsAllLetters(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z\s]+$");
        }

        private bool IsAllDigits(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Save changes
            string chosenId = userID.ToString();
            int chosenIdInt = int.Parse(chosenId);

            string newFirstName = textBox1.Text;
            string newLastName = textBox6.Text;
            string newPin = textBox8.Text;

            // Retrieve the list of tuples from your backend function or wherever it's available
            List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

            // Check if there is a matching user with the given userID
            Tuple<int, string, string, int, string, bool> matchingUser = userList.FirstOrDefault(user => user.Item1 == chosenIdInt);

            if (matchingUser != null)
            {
                // Retrieve the variables from the matchingUser tuple
                int userId = matchingUser.Item1;
                string firstName = matchingUser.Item2;
                string lastName = matchingUser.Item3;
                int pin = matchingUser.Item4;
                string email = matchingUser.Item5;

                // Create a User object using the retrieved variables
                User userObject = new User(userId, firstName, lastName, email, pin);
                People chosenPerson = new People(firstName, lastName, email, pin);

                // Boolean flag to track the validity of all fields
                bool allFieldsValid = true;

                if (!string.IsNullOrEmpty(newFirstName) && IsAllLetters(newFirstName))
                {
                    if (!string.IsNullOrEmpty(newLastName) && IsAllLetters(newLastName))
                    {
                        if (!string.IsNullOrEmpty(newPin) && IsAllDigits(newPin))
                        {
                            // Edit the first name
                            chosenPerson.EditFirstName(newFirstName, userObject);

                            // Edit the last name
                            chosenPerson.EditLastName(newLastName, userObject);

                            // Edit the PIN
                            chosenPerson.EditPIN(newPin, userObject);

                            // Go back to admin page when all fields are valid
                            this.Hide();
                            AdminControls adminControls = new AdminControls();
                            adminControls.Show();
                        }
                        else
                        {
                            allFieldsValid = false;
                            // Display an error message for invalid PIN
                            MessageBox.Show("Invalid PIN. Please enter a numeric PIN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        allFieldsValid = false;
                        // Display an error message for invalid last name
                        MessageBox.Show("Invalid last name. Please enter a valid name without numbers or special characters.");
                    }
                }
                else
                {
                    allFieldsValid = false;
                    // Display an error message for invalid first name
                    MessageBox.Show("Invalid first name. Please enter a valid name without numbers or special characters.");
                }

                if (!allFieldsValid)
                {
                    // Stay on the current page or display an error message
                    //MessageBox.Show("Please correct the invalid fields before proceeding.");
                }

            }
            else
            {
                MessageBox.Show("No user found with the given UserID.");
            }

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string chosenId = userID.ToString();
            int chosenIdInt = int.Parse(chosenId);

            // Retrieve the list of tuples from your backend function or wherever it's available
            List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

            // Check if there is a matching user with the given userID
            Tuple<int, string, string, int, string, bool> matchingUser = userList.FirstOrDefault(user => user.Item1 == chosenIdInt);

            if (matchingUser != null)
            {
                // Retrieve the variables from the matchingUser tuple
                int userId = matchingUser.Item1;
                string firstName = matchingUser.Item2;
                string lastName = matchingUser.Item3;
                int pin = matchingUser.Item4;
                string email = matchingUser.Item5;

                // Create a User object using the retrieved variables
                User userObject = new User(userId, firstName, lastName, email, pin);

                // change label
                label2.Text = "UserId: " + userId + " Username: " + firstName;

            }
            else
            {
                MessageBox.Show("No user found with the given UserID.");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
