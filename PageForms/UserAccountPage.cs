﻿using System;
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
    }
}
