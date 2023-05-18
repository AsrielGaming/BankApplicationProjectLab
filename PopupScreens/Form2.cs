﻿using BankApplicationProjectLab.PageForms;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //delete
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }
    }
}
