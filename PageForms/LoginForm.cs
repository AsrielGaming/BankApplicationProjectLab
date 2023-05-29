using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PageForms;
using Project_InspirationLab_2023.Classes;
using System.Text.RegularExpressions;

namespace BankApplicationProjectLab
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {


        }

        private void loginLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pinLabel_Click(object sender, EventArgs e)
        {

        }

        //private void pinTextBox_TextChanged(object sender, EventArgs e)
        //{

        //}

        private void loginButton_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void line_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pinLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {


            //ga naar signup page
            this.Hide();
            SignUpForm signupPage = new SignUpForm();
            signupPage.Show();
        }

        private void emailLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void loginLabel_Click_1(object sender, EventArgs e)
        {

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private bool IsValidEmail(string email)
        {
            // Regular expression pattern for validating email format
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            return Regex.IsMatch(email, pattern);
        }

        private void loginButton_Click_1(object sender, EventArgs e)
        {
            string email = textBox2.Text;
            string stringPin = textBox1.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(stringPin))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(stringPin, out int pin))
            {
                MessageBox.Show("Invalid PIN. PIN must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            People loggedInUser = People.Login(email, pin);

            if (loggedInUser is Admin)
            {
                //ga naar admin page
                this.Hide();
                AdminControls adminControls = new AdminControls();
                adminControls.Show();
            }
            else if (loggedInUser is User)
            {
                //ga naar homepage
                this.Hide();
                Homepage homepage = new Homepage();
                homepage.Show();
            }
            else
            {
                MessageBox.Show("Not a valid user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // temporary
        //private void button1_Click(object sender, EventArgs e)
        //{
            //ga naar admin pagina
        //    this.Hide();
        //    AdminControls adminControls = new AdminControls();
        //    adminControls.Show();
        //}

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}