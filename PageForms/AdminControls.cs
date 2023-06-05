using BankApplicationProjectLab.PopupScreens;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BankApplicationProjectLab.PageForms
{
    public partial class AdminControls : Form
    {
        private string email;
        private int pin;

        public AdminControls()
        {
            InitializeComponent();

            this.Load += AdminControls_Load;

            this.email = email;
            this.pin = pin;

        }
        private void AdminControls_Load(object sender, EventArgs e)
        {
            // Retrieve the list of tuples from your backend function or wherever it's available
            List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

            // Create a new DataTable to store the user data
            DataTable dataTable = new DataTable();

            // Add columns to the DataTable
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Firstname", typeof(string));
            dataTable.Columns.Add("Lastname", typeof(string));
            dataTable.Columns.Add("PIN", typeof(int));
            dataTable.Columns.Add("Email", typeof(string));

            // Iterate over the list of tuples and add rows to the DataTable
            foreach (var user in userList)
            {
                Console.WriteLine(user.Item1 + " " + user.Item2 + " " + user.Item3 + " " + user.Item4);
                dataTable.Rows.Add(user.Item1, user.Item2, user.Item3, user.Item4, user.Item5);
            }

            // Set the DataGridView's DataSource to the DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void AdminControls_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            //ga naar login
            //this.Hide();
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show();
        }

        private void label18_Click(object sender, EventArgs e)
        {


            //ga naar login
            //this.Hide();
            //LoginForm loginForm = new LoginForm();
            //loginForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create new user


            //ga naar create user popup
            this.Hide();
            CreateUserPopup createUserPopup = new CreateUserPopup();
            createUserPopup.Show();

        }



        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // button to delete user
        private void button3_Click_1(object sender, EventArgs e)
        {
            int userID;
            if (int.TryParse(textBox1.Text, out userID))
            {
                this.Hide();
                Form2 form2 = new Form2(email, pin, userID);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid user ID.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int userID;
            if (int.TryParse(textBox1.Text, out userID))
            {
                // Get the list of tuples from your backend function or wherever it's available
                List<Tuple<int, string, string, int, string, bool>> userList = People.GetAllUsers();

                // Check if there is a matching user with the given userID
                Tuple<int, string, string, int, string, bool> matchingUser = userList.FirstOrDefault(user => user.Item1 == userID);

                if (matchingUser != null)
                {
                    // Set the necessary values
                    string email = matchingUser.Item5;
                    int pin = matchingUser.Item4;

                    // Hide AdminControls and show Form1 with the necessary values
                    this.Hide();
                    Form1 form1 = new Form1(email, pin, userID);
                    form1.Show();
                }
                else
                {
                    MessageBox.Show("No user found with the given UserID.");
                }
            }
            else
            {
                MessageBox.Show("Invalid user ID.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // textbox with id
        }
    }
}
