using BankApplicationProjectLab.PopupScreens;
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

namespace BankApplicationProjectLab.PageForms
{
    public partial class Homepage : Form
    {
        private string email;
        private int pin;

        public Homepage(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {


            //go to current account popup form
            this.Hide();
            PopupCurrentAccount popupCurrentAccount = new PopupCurrentAccount(email, pin);
            popupCurrentAccount.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

            //go to savings account popup form
            this.Hide();
            PopupSavingsAccount popupSavingsAccount = new PopupSavingsAccount(email, pin);
            popupSavingsAccount.Show();

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

            //Environment.Exit();
        }

        private void label19_Click(object sender, EventArgs e)
        {



            //ga naar transaction pagina
            this.Hide();
            Transaction transaction = new Transaction(email, pin);
            transaction.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {


            //ga naar user account pagina
            this.Hide();
            UserAccountPage userAccount = new UserAccountPage(email, pin);
            userAccount.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            // veranderen van username in hello username
            People loggedInUser = People.Login(email, pin);
            label20.Text = "Hello " + loggedInUser.FirstName;

            //current account
            label12.Text = loggedInUser.FirstName + "'s current account";
            //savings account
            label14.Text = loggedInUser.FirstName + "'s savings account";
        }

        private void label20_Click(object sender, EventArgs e)
        {
            // nameplate top right

        }

        private void label12_Click(object sender, EventArgs e)
        {
            //current account name
        }

        private void label14_Click(object sender, EventArgs e)
        {
            //savings account name
        }
    }
}
