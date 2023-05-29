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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankApplicationProjectLab.PageForms
{
    public partial class UserAccountPage : Form
    {
        private string email;
        private int pin;

        public UserAccountPage(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void UserAccountPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            // email
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //editFirstname
            this.Hide();
            Form3 form3 = new Form3(email, pin);
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //editLastname
            this.Hide();
            Form4 form4 = new Form4(email, pin);
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //editEmail
            this.Hide();
            Form5 form5 = new Form5(email, pin);
            form5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //editPin
            this.Hide();
            Form6 form6 = new Form6(email, pin);
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete account
            this.Hide();
            Form7 form7 = new Form7(email, pin);
            form7.Show();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            // hello name label
        }

        private void UserAccountPage_Load(object sender, EventArgs e)
        {
            // veranderen van username in hello username
            People loggedInUser = People.Login(email, pin);
            label20.Text = "Hello " + loggedInUser.FirstName;
            label6.Text = loggedInUser.FirstName;
            label7.Text = loggedInUser.LastName;
            label8.Text = email;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            // firstname
        }

        private void label7_Click(object sender, EventArgs e)
        {
            // lastname
        }
    }
}
