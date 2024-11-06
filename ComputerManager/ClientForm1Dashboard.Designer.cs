namespace ComputerManager.Client1
{
    partial class ClientForm1Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientpc1logoutButton = new Button();
            c1_userlogLabel = new Label();
            SuspendLayout();
            // 
            // clientpc1logoutButton
            // 
            clientpc1logoutButton.Location = new Point(113, 80);
            clientpc1logoutButton.Name = "clientpc1logoutButton";
            clientpc1logoutButton.Size = new Size(94, 29);
            clientpc1logoutButton.TabIndex = 0;
            clientpc1logoutButton.Text = "Logout";
            clientpc1logoutButton.UseVisualStyleBackColor = true;
            clientpc1logoutButton.Click += c1_logoutButton_Click;
            // 
            // c1_userlogLabel
            // 
            c1_userlogLabel.AutoSize = true;
            c1_userlogLabel.Location = new Point(37, 21);
            c1_userlogLabel.Name = "c1_userlogLabel";
            c1_userlogLabel.Size = new Size(170, 20);
            c1_userlogLabel.TabIndex = 1;
            c1_userlogLabel.Text = "User currently logged in:";
            // 
            // ClientForm1Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 142);
            Controls.Add(c1_userlogLabel);
            Controls.Add(clientpc1logoutButton);
            Name = "ClientForm1Dashboard";
            Text = "PC - 01 ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientpc1logoutButton;
        private Label c1_userlogLabel;
    }
}