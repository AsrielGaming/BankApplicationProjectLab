using BankApplicationProjectLab.Classes;
using BankApplicationProjectLab.PopupScreens;
using Project_InspirationLab_2023.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApplicationProjectLab.PageForms
{
    public partial class Homepage : Form
    {
        private string email;
        private int pin;

        public Homepage(string email, int pin)
        {
            InitializeComponent();
            this.email = email;
            this.pin = pin;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {


            //go to current account popup form
            this.Hide();
            PopupCurrentAccount popupCurrentAccount = new PopupCurrentAccount(email, pin);
            popupCurrentAccount.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

            //go to savings account popup form
            this.Hide();
            PopupSavingsAccount popupSavingsAccount = new PopupSavingsAccount(email, pin);
            popupSavingsAccount.Show();

        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            // balance current
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
            Transaction transaction = new Transaction(email, pin);
            transaction.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            //ga naar user account pagina
            this.Hide();
            UserAccountPage userAccount = new UserAccountPage(email, pin);
            userAccount.Show();
        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            // veranderen van username in hello username
            People loggedInUser = People.Login(email, pin);
            label20.Text = "Hello " + loggedInUser.FirstName;
            label20.TextAlign = ContentAlignment.MiddleCenter;

            // User object aanmaken en id van nemen
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;



            // select overview of all current accounts
            Dictionary<string, double> CurrentAccountDictionary = CurrentAccount.OverviewCurrentAccount(loggedInUserUserId);

            DisplayCurrentAccounts(CurrentAccountDictionary.Take(1).ToDictionary(x => x.Key, x => x.Value));



            // select overview of all savings accounts
            Dictionary<string, double> SavingsAccountDictionary = SavingsAccount.OverviewSavingsAccount(loggedInUserUserId);

            DisplaySavingsAccounts(SavingsAccountDictionary.Take(1).ToDictionary(x => x.Key, x => x.Value));


            // select overview of transactions

            List<Tuple<string, string, string, double, DateTime>> OverviewTransactionsList = Classes.Account.OverViewHistory(loggedInUserUserId);

            DisplayTransactionHistory(OverviewTransactionsList.Take(2).ToList());

            //show the picture in the right top corner if there is a pp


            Image profilePic = correctUser.ShowProfilePic(correctUser);
            if (profilePic != null)
            {
                pictureBox4.Image = profilePic;
            }


            // make any automatic payments that need to happen?

        }

        // method to display all the current accounts
        private void DisplayCurrentAccounts(Dictionary<string, double> CurrentAccounts)
        {

            tableLayoutPanel5.Controls.Clear();

            int rowIndex = 0;
            foreach (var account in CurrentAccounts)
            {

                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "Wallet.png");
                PictureBox moneyPictureBox = new PictureBox();
                moneyPictureBox.Image = Image.FromFile(imagePath);
                moneyPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                moneyPictureBox.Size = new Size(60, 80); // Set the desired size of the picture box

                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");
                PictureBox logoPictureBox = new PictureBox();
                logoPictureBox.Image = Image.FromFile(imagePath2);
                logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                logoPictureBox.Size = new Size(60, 80); // Set the desired size of the picture box

                Label accountNameLabel = new Label();
                accountNameLabel.Text = account.Key;
                accountNameLabel.AutoSize = true;
                accountNameLabel.Anchor = AnchorStyles.None; // Center the label horizontally and vertically
                accountNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                accountNameLabel.Font = new Font(accountNameLabel.Font.FontFamily, 15, FontStyle.Bold); // Make the font bold

                Label balanceLabel = new Label();
                balanceLabel.Text = "€ " + account.Value.ToString();
                balanceLabel.AutoSize = true;
                balanceLabel.Anchor = AnchorStyles.None; // Center the label horizontally and vertically
                balanceLabel.TextAlign = ContentAlignment.MiddleCenter;
                balanceLabel.Font = new Font(balanceLabel.Font.FontFamily, 18, FontStyle.Bold); // Increase the font size and make it bold



                // Add the controls to the TableLayoutPanel
                tableLayoutPanel5.Controls.Add(moneyPictureBox, 0, rowIndex);
                tableLayoutPanel5.Controls.Add(accountNameLabel, 1, rowIndex);
                tableLayoutPanel5.Controls.Add(balanceLabel, 2, rowIndex);
                tableLayoutPanel5.Controls.Add(logoPictureBox, 3, rowIndex);


                rowIndex++;
            }

            // Set equal width for each column
            for (int i = 0; i < tableLayoutPanel5.ColumnCount; i++)
            {
                tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            }

            // Set equal height for each row
            float rowPercentage = 100f / tableLayoutPanel5.RowCount;
            for (int i = 0; i < tableLayoutPanel5.RowCount; i++)
            {
                tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, rowPercentage));
            }

            // Make the TableLayoutPanel scrollable
            tableLayoutPanel5.AutoScroll = true;

        }

        // method to display all the savingsaccounts
        private void DisplaySavingsAccounts(Dictionary<string, double> SavingsAccounts)
        {

            tableLayoutPanel6.Controls.Clear();

            int rowIndex = 0;
            foreach (var account in SavingsAccounts)
            {

                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "piggyBank.png");
                PictureBox piggyBankPictureBox = new PictureBox();
                piggyBankPictureBox.Image = Image.FromFile(imagePath);
                piggyBankPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                piggyBankPictureBox.Size = new Size(60, 80); // Set the desired size of the picture box

                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "logo.png");
                PictureBox logoPictureBox = new PictureBox();
                logoPictureBox.Image = Image.FromFile(imagePath2);
                logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                logoPictureBox.Size = new Size(60, 80); // Set the desired size of the picture box

                Label accountNameLabel = new Label();
                accountNameLabel.Text = account.Key;
                accountNameLabel.AutoSize = true;
                accountNameLabel.Anchor = AnchorStyles.None; // Center the label horizontally and vertically
                accountNameLabel.TextAlign = ContentAlignment.MiddleCenter;
                accountNameLabel.Font = new Font(accountNameLabel.Font.FontFamily, 15, FontStyle.Bold); // Make the font bold

                Label balanceLabel = new Label();
                balanceLabel.Text = "€ " + account.Value.ToString();
                balanceLabel.AutoSize = true;
                balanceLabel.Anchor = AnchorStyles.None; // Center the label horizontally and vertically
                balanceLabel.TextAlign = ContentAlignment.MiddleCenter;
                balanceLabel.Font = new Font(balanceLabel.Font.FontFamily, 18, FontStyle.Bold); // Increase the font size and make it bold



                // Add the controls to the TableLayoutPanel
                tableLayoutPanel6.Controls.Add(piggyBankPictureBox, 0, rowIndex);
                tableLayoutPanel6.Controls.Add(accountNameLabel, 1, rowIndex);
                tableLayoutPanel6.Controls.Add(balanceLabel, 2, rowIndex);
                tableLayoutPanel6.Controls.Add(logoPictureBox, 3, rowIndex);


                rowIndex++;
            }

            // Set equal width for each column
            for (int i = 0; i < tableLayoutPanel6.ColumnCount; i++)
            {
                tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            }

            // Set equal height for each row
            float rowPercentage = 100f / tableLayoutPanel6.RowCount;
            for (int i = 0; i < tableLayoutPanel6.RowCount; i++)
            {
                tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, rowPercentage));
            }

            // Make the TableLayoutPanel scrollable
            tableLayoutPanel6.AutoScroll = true;
        }

        // display overview transactions
        private void DisplayTransactionHistory(List<Tuple<string, string, string, double, DateTime>> transactions)
        {
            tableLayoutPanel7.Controls.Clear();
            tableLayoutPanel7.RowStyles.Clear();

            int rowIndex = 0;
            foreach (var transaction in transactions)
            {
                Label dateLabel = new Label();
                dateLabel.Text = transaction.Item5.ToString("yyyy-MM-dd");
                dateLabel.AutoSize = true;
                dateLabel.Anchor = AnchorStyles.None;
                dateLabel.TextAlign = ContentAlignment.MiddleCenter;
                dateLabel.Font = new Font(dateLabel.Font.FontFamily, 18);

                Label descriptionLabel = new Label();
                descriptionLabel.Text = $" From: {transaction.Item1}   To: {transaction.Item2}    Account name:  {transaction.Item3}";
                descriptionLabel.AutoSize = true;
                descriptionLabel.Anchor = AnchorStyles.None;
                descriptionLabel.TextAlign = ContentAlignment.MiddleCenter;
                descriptionLabel.Font = new Font(descriptionLabel.Font.FontFamily, 12);

                Label amountLabel = new Label();
                amountLabel.Text = "€ " + transaction.Item4.ToString();
                amountLabel.AutoSize = true;
                amountLabel.Anchor = AnchorStyles.None;
                amountLabel.TextAlign = ContentAlignment.MiddleCenter;
                amountLabel.Font = new Font(amountLabel.Font.FontFamily, 18);


                tableLayoutPanel7.Controls.Add(dateLabel, 0, rowIndex);
                tableLayoutPanel7.Controls.Add(descriptionLabel, 1, rowIndex);
                tableLayoutPanel7.Controls.Add(amountLabel, 2, rowIndex);

                rowIndex++;
            }

            // Set equal width for each column
            for (int i = 0; i < tableLayoutPanel7.ColumnCount; i++)
            {
                tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
            }

            // Set equal height for each row
            float rowPercentage = 100f / tableLayoutPanel7.RowCount;
            for (int i = 0; i < tableLayoutPanel7.RowCount; i++)
            {
                if (i < 2)
                {
                    tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                else
                {
                    tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, rowPercentage));
                }
            }

            // Make the TableLayoutPanel scrollable
            tableLayoutPanel7.AutoScroll = true;
        }


        private void label20_Click(object sender, EventArgs e)
        {
            // nameplate top right

        }

        private void label12_Click(object sender, EventArgs e)
        {
            //current account name
        }

        private void label14_Click(object sender, EventArgs e)
        {
            //savings account name
        }

        private void label15_Click(object sender, EventArgs e)
        {
            // balance savings
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // show all current accounts

            // login user again in order to retrieve userid later on
            People loggedInUser = People.Login(email, pin);

            // User object aanmaken en id van nemen
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;
            // select overview of all current accounts
            Dictionary<string, double> CurrentAccountDictionay = CurrentAccount.OverviewCurrentAccount(loggedInUserUserId);

            // display all current accounts
            DisplayCurrentAccounts(CurrentAccountDictionay);
        }

        private void tableLayoutPanel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            // show all savings accounts

            // login user again in order to retrieve userid later on
            People loggedInUser = People.Login(email, pin);

            // User object aanmaken en id van nemen
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;
            // select overview of all current accounts
            Dictionary<string, double> SavingsAccountDictionay = SavingsAccount.OverviewSavingsAccount(loggedInUserUserId);

            // display all current accounts
            DisplaySavingsAccounts(SavingsAccountDictionay);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //go to current account popup form
            this.Hide();
            PopupCurrentAccount popupCurrentAccount = new PopupCurrentAccount(email, pin);
            popupCurrentAccount.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // go to savings account popup form
            this.Hide();
            PopupSavingsAccount popupSavingsAccount = new PopupSavingsAccount(email, pin);
            popupSavingsAccount.Show();
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            // show all transactions

            // login user again in order to retrieve userid later on
            People loggedInUser = People.Login(email, pin);

            // User object aanmaken en id van nemen
            User correctUser = (User)loggedInUser;
            int loggedInUserUserId = correctUser.UserID;

            // retrieve all transactions from this user and display them
            List<Tuple<string, string, string, double, DateTime>> OverviewTransactionsList = Classes.Account.OverViewHistory(loggedInUserUserId);

            DisplayTransactionHistory(OverviewTransactionsList);


        }
    }
}
