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
    public partial class UserAccountPage : Form
    {
        public UserAccountPage()
        {
            InitializeComponent();
        }

        private void UserAccountPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //editFirstname
            this.Hide();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //editLastname
            this.Hide();
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //editEmail
            this.Hide();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //editPin
            this.Hide();
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //delete account
            this.Hide();
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
