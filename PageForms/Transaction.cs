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



            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {



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
            label20.Text = "Hello " + loggedInUser.FirstName;
        }
    }
}
