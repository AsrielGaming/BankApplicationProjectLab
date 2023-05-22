using BankApplicationProjectLab.PageForms;

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

        private void pinTextBox_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void loginButton_Click_1(object sender, EventArgs e)
        {


            //ga naar homepage
            this.Hide();
            Homepage homepage = new Homepage();
            homepage.Show();
        }

        // temporary
        private void button1_Click(object sender, EventArgs e)
        {
            //ga naar admin pagina
            this.Hide();
            AdminControls adminControls = new AdminControls();
            adminControls.Show();
        }
    }
}