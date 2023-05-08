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
        public Homepage()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

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
            Transaction transaction = new Transaction();
            transaction.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {


            //ga naar user account pagina
            this.Hide();
            UserAccountPage userAccount = new UserAccountPage();
            userAccount.Show();
        }
    }
}
