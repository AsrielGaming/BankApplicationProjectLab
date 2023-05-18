using BankApplicationProjectLab.PopupScreens;
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
    public partial class AdminControls : Form
    {
        public AdminControls()
        {
            InitializeComponent();
        }

        private void AdminControls_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            //ga naar login
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {


            //ga naar login
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //ga naar create user popup
            this.Hide();
            CreateUserPopup createUserPopup = new CreateUserPopup();
            createUserPopup.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ga naar edit user popup
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ga naar delete user popup
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
