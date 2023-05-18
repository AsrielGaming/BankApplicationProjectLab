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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //save changes
            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage();
            userAccountPage.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage();
            userAccountPage.Show();
        }
    }
}
