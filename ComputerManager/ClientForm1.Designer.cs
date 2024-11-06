namespace ComputerManager.Client1
{
    partial class ClientForm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            C1_loginLabel = new Label();
            C1_loginLogo = new PictureBox();
            C1_studentIDtextbox = new TextBox();
            c1_passwordTextbox = new TextBox();
            c1_loginButton = new Button();
            c1_studentidLabel = new Label();
            c1_passwordLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)C1_loginLogo).BeginInit();
            SuspendLayout();
            // 
            // C1_loginLabel
            // 
            C1_loginLabel.AutoSize = true;
            C1_loginLabel.Font = new Font("Arial", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            C1_loginLabel.Location = new Point(635, 198);
            C1_loginLabel.Name = "C1_loginLabel";
            C1_loginLabel.Size = new Size(607, 93);
            C1_loginLabel.TabIndex = 0;
            C1_loginLabel.Text = "PC - 01 LOG IN";
            // 
            // C1_loginLogo
            // 
            C1_loginLogo.Image = Properties.Resources.MCMLogo;
            C1_loginLogo.Location = new Point(814, 312);
            C1_loginLogo.Name = "C1_loginLogo";
            C1_loginLogo.Size = new Size(249, 230);
            C1_loginLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            C1_loginLogo.TabIndex = 1;
            C1_loginLogo.TabStop = false;
            // 
            // C1_studentIDtextbox
            // 
            C1_studentIDtextbox.Location = new Point(795, 603);
            C1_studentIDtextbox.Name = "C1_studentIDtextbox";
            C1_studentIDtextbox.Size = new Size(287, 27);
            C1_studentIDtextbox.TabIndex = 2;
            // 
            // c1_passwordTextbox
            // 
            c1_passwordTextbox.Location = new Point(795, 694);
            c1_passwordTextbox.Name = "c1_passwordTextbox";
            c1_passwordTextbox.PasswordChar = '*';
            c1_passwordTextbox.Size = new Size(287, 27);
            c1_passwordTextbox.TabIndex = 3;
            // 
            // c1_loginButton
            // 
            c1_loginButton.Location = new Point(878, 784);
            c1_loginButton.Name = "c1_loginButton";
            c1_loginButton.Size = new Size(121, 52);
            c1_loginButton.TabIndex = 4;
            c1_loginButton.Text = "Login";
            c1_loginButton.UseVisualStyleBackColor = true;
            c1_loginButton.Click += c1_loginButton_Click;
            // 
            // c1_studentidLabel
            // 
            c1_studentidLabel.AutoSize = true;
            c1_studentidLabel.Location = new Point(899, 566);
            c1_studentidLabel.Name = "c1_studentidLabel";
            c1_studentidLabel.Size = new Size(79, 20);
            c1_studentidLabel.TabIndex = 5;
            c1_studentidLabel.Text = "Student ID";
            // 
            // c1_passwordLabel
            // 
            c1_passwordLabel.AutoSize = true;
            c1_passwordLabel.Location = new Point(903, 655);
            c1_passwordLabel.Name = "c1_passwordLabel";
            c1_passwordLabel.Size = new Size(70, 20);
            c1_passwordLabel.TabIndex = 6;
            c1_passwordLabel.Text = "Password";
            // 
            // ClientForm1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1381, 999);
            Controls.Add(c1_passwordLabel);
            Controls.Add(c1_studentidLabel);
            Controls.Add(c1_loginButton);
            Controls.Add(c1_passwordTextbox);
            Controls.Add(C1_studentIDtextbox);
            Controls.Add(C1_loginLogo);
            Controls.Add(C1_loginLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientForm1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PC-01 LOGIN";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)C1_loginLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label C1_loginLabel;
        private PictureBox C1_loginLogo;
        private TextBox C1_studentIDtextbox;
        private TextBox c1_passwordTextbox;
        private Button c1_loginButton;
        private Label c1_studentidLabel;
        private Label c1_passwordLabel;
    }
}
