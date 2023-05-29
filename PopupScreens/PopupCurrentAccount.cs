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
    public partial class PopupCurrentAccount : Form
    {
        private string email;
        private int pin;

        public PopupCurrentAccount(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void PopupCurrentAccount_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // redirect to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }

        private void PopupCurrentAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            // redirect to homepage
            this.Hide();
            Homepage homepage = new Homepage(email, pin);
            homepage.Show();
        }
    }
}
