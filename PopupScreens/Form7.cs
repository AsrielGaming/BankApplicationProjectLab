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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

        private void button6_Click(object sender, EventArgs e)
        {
            //delete
            // go back to user account page
            People loggedInUser = People.Login(email, pin);
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            //get checkbox variable
            bool checkboxChecked = checkBox1.Checked;

            if (checkboxChecked == true)
            {
                correctUser.DeleteUserAccount(correctUser);

                MessageBox.Show("Account successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Go to the user account page
                this.Hide();
                LoginForm loginform = new LoginForm();
                loginform.Show();
            }

            else
            {
                MessageBox.Show("You must give consent to delete your account", "Consent Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //consent checkbox
        }
    }
}
