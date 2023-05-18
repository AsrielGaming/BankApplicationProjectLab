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
    public partial class CreateUserPopup : Form
    {
        public CreateUserPopup()
        {
            InitializeComponent();
        }

        private void CreateUserPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // go back to admin page
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }
    }
}
