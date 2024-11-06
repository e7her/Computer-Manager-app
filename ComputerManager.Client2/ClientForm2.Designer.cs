namespace ComputerManager.Client2
{
    partial class ClientForm2
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
            C2_loginLogo = new PictureBox();
            C2_loginLabel = new Label();
            C2_studentIDTextbox = new TextBox();
            C2_passwordTextbox = new TextBox();
            c2_studentidLabel = new Label();
            c2_passwordLabel = new Label();
            c2_loginButton = new Button();
            ((System.ComponentModel.ISupportInitialize)C2_loginLogo).BeginInit();
            SuspendLayout();
            // 
            // C2_loginLogo
            // 
            C2_loginLogo.Image = Properties.Resources.MCMLogo;
            C2_loginLogo.Location = new Point(814, 312);
            C2_loginLogo.Name = "C2_loginLogo";
            C2_loginLogo.Size = new Size(249, 230);
            C2_loginLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            C2_loginLogo.TabIndex = 0;
            C2_loginLogo.TabStop = false;
            // 
            // C2_loginLabel
            // 
            C2_loginLabel.AutoSize = true;
            C2_loginLabel.Font = new Font("Arial", 48F, FontStyle.Bold);
            C2_loginLabel.Location = new Point(630, 181);
            C2_loginLabel.Name = "C2_loginLabel";
            C2_loginLabel.Size = new Size(607, 93);
            C2_loginLabel.TabIndex = 0;
            C2_loginLabel.Text = "PC - 02 LOG IN";
            // 
            // C2_studentIDTextbox
            // 
            C2_studentIDTextbox.Location = new Point(814, 610);
            C2_studentIDTextbox.Name = "C2_studentIDTextbox";
            C2_studentIDTextbox.Size = new Size(249, 27);
            C2_studentIDTextbox.TabIndex = 1;
            // 
            // C2_passwordTextbox
            // 
            C2_passwordTextbox.Location = new Point(814, 716);
            C2_passwordTextbox.Name = "C2_passwordTextbox";
            C2_passwordTextbox.PasswordChar = '*';
            C2_passwordTextbox.Size = new Size(249, 27);
            C2_passwordTextbox.TabIndex = 2;
            // 
            // c2_studentidLabel
            // 
            c2_studentidLabel.AutoSize = true;
            c2_studentidLabel.Location = new Point(896, 572);
            c2_studentidLabel.Name = "c2_studentidLabel";
            c2_studentidLabel.Size = new Size(79, 20);
            c2_studentidLabel.TabIndex = 3;
            c2_studentidLabel.Text = "Student ID";
            // 
            // c2_passwordLabel
            // 
            c2_passwordLabel.AutoSize = true;
            c2_passwordLabel.Location = new Point(896, 678);
            c2_passwordLabel.Name = "c2_passwordLabel";
            c2_passwordLabel.Size = new Size(70, 20);
            c2_passwordLabel.TabIndex = 4;
            c2_passwordLabel.Text = "Password";
            // 
            // c2_loginButton
            // 
            c2_loginButton.Location = new Point(887, 798);
            c2_loginButton.Name = "c2_loginButton";
            c2_loginButton.Size = new Size(100, 46);
            c2_loginButton.TabIndex = 5;
            c2_loginButton.Text = "Login";
            c2_loginButton.UseVisualStyleBackColor = true;
            c2_loginButton.Click += c2_loginButton_Click;
            // 
            // ClientForm2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1363, 952);
            Controls.Add(c2_loginButton);
            Controls.Add(c2_passwordLabel);
            Controls.Add(c2_studentidLabel);
            Controls.Add(C2_passwordTextbox);
            Controls.Add(C2_studentIDTextbox);
            Controls.Add(C2_loginLabel);
            Controls.Add(C2_loginLogo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClientForm2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PC-02 LOGIN";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)C2_loginLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox C2_loginLogo;
        private Label C2_loginLabel;
        private TextBox C2_studentIDTextbox;
        private TextBox C2_passwordTextbox;
        private Label c2_studentidLabel;
        private Label c2_passwordLabel;
        private Button c2_loginButton;
    }
}
