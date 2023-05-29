using BankApplicationProjectLab.PageForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplicationProjectLab.PopupScreens
{
    public partial class PopupSavingsAccount : Form
    {

        private string email;
        private int pin;

        public PopupSavingsAccount(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PopupSavingsAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //rederict to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //rederict to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }
    }
}
