﻿using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PageForms;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplicationProjectLab.PopupScreens
{
    public partial class Form3 : Form
    {
        private string email;
        private int pin;

        public Form3(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save changes
            People loggedInUser = People.Login(email, pin);
            string updatedFirstname = textBox1.Text;

            //Probleem
            //People.EditFirstName(updatedFirstname, User loggedInUser);

            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage(email, pin);
            userAccountPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            // go back to user account page
            this.Hide();
            UserAccountPage userAccountPage = new UserAccountPage(email, pin);
            userAccountPage.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //firstname
        }
    }
}
