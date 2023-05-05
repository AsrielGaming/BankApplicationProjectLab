namespace BankApplicationProjectLab
{
    partial class LoginForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private Panel line; //panel 1

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            line = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            loginLabel = new Label();
            textBox2 = new TextBox();
            emailLabel = new Label();
            textBox1 = new TextBox();
            pinLabel = new Label();
            loginButton = new Button();
            linkLabel1 = new LinkLabel();
            emailTextBox = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // line
            // 
            line.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            line.BackColor = SystemColors.ActiveCaptionText;
            line.Location = new Point(402, 0);
            line.Margin = new Padding(0);
            line.Name = "line";
            line.Size = new Size(2, 450);
            line.TabIndex = 1;
            line.Paint += line_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.207756F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.955677F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.8365688F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(loginLabel, 1, 1);
            tableLayoutPanel1.Controls.Add(textBox2, 1, 2);
            tableLayoutPanel1.Controls.Add(emailLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(textBox1, 1, 3);
            tableLayoutPanel1.Controls.Add(pinLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(loginButton, 1, 4);
            tableLayoutPanel1.Controls.Add(linkLabel1, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(408, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 9.96585F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.9447231F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.26924F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.60454F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.0555744F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2577267F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.90234F));
            tableLayoutPanel1.Size = new Size(389, 444);
            tableLayoutPanel1.TabIndex = 10;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // loginLabel
            // 
            loginLabel.Anchor = AnchorStyles.None;
            loginLabel.AutoSize = true;
            loginLabel.Font = new Font("Barlow Condensed", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point);
            loginLabel.Location = new Point(166, 60);
            loginLabel.Name = "loginLabel";
            loginLabel.Size = new Size(80, 42);
            loginLabel.TabIndex = 4;
            loginLabel.Text = "Login";
            loginLabel.Click += loginLabel_Click_1;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(130, 137);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(152, 27);
            textBox2.TabIndex = 13;
            // 
            // emailLabel
            // 
            emailLabel.Anchor = AnchorStyles.Right;
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(43, 140);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(52, 20);
            emailLabel.TabIndex = 7;
            emailLabel.Text = "E-mail";
            emailLabel.Click += emailLabel_Click_1;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(130, 200);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 27);
            textBox1.TabIndex = 10;
            // 
            // pinLabel
            // 
            pinLabel.Anchor = AnchorStyles.Right;
            pinLabel.AutoSize = true;
            pinLabel.Location = new Point(26, 204);
            pinLabel.Name = "pinLabel";
            pinLabel.Size = new Size(69, 20);
            pinLabel.TabIndex = 8;
            pinLabel.Text = "PIN code";
            pinLabel.Click += pinLabel_Click_1;
            // 
            // loginButton
            // 
            loginButton.Anchor = AnchorStyles.None;
            loginButton.AutoSize = true;
            loginButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            loginButton.Location = new Point(159, 257);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(95, 48);
            loginButton.TabIndex = 11;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(118, 317);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(177, 20);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Make a new account here";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = AnchorStyles.Left;
            emailTextBox.Location = new Point(638, 138);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(159, 27);
            emailTextBox.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.50505F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 3F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.49495F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 2, 0);
            tableLayoutPanel2.Controls.Add(line, 1, 0);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(800, 450);
            tableLayoutPanel2.TabIndex = 11;
            tableLayoutPanel2.Paint += tableLayoutPanel2_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(402, 450);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Name = "LoginForm";
            Text = "loginForm";
            FormClosed += LoginForm_FormClosed;
            Load += LoginForm_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private TableLayoutPanel tableLayoutPanel1;
        private Label loginLabel;
        private Label emailLabel;
        private Label pinLabel;
        private TextBox emailTextBox;
        private TextBox textBox1;
        private Button loginButton;
        private LinkLabel linkLabel1;
        private TextBox textBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private PictureBox pictureBox1;
    }
}