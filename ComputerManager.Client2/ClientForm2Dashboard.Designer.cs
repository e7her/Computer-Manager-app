namespace ComputerManager.Client2
{
    partial class ClientForm2Dashboard
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
            clientpc2logoutButton = new Button();
            c2_userlogLabel = new Label();
            SuspendLayout();
            // 
            // clientpc2logoutButton
            // 
            clientpc2logoutButton.Location = new Point(116, 87);
            clientpc2logoutButton.Name = "clientpc2logoutButton";
            clientpc2logoutButton.Size = new Size(94, 29);
            clientpc2logoutButton.TabIndex = 0;
            clientpc2logoutButton.Text = "Logout";
            clientpc2logoutButton.UseVisualStyleBackColor = true;
            clientpc2logoutButton.Click += clientpc2logoutButton_Click;
            // 
            // c2_userlogLabel
            // 
            c2_userlogLabel.AutoSize = true;
            c2_userlogLabel.Location = new Point(40, 20);
            c2_userlogLabel.Name = "c2_userlogLabel";
            c2_userlogLabel.Size = new Size(170, 20);
            c2_userlogLabel.TabIndex = 1;
            c2_userlogLabel.Text = "User currently logged in:";
            // 
            // ClientForm2Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 142);
            Controls.Add(c2_userlogLabel);
            Controls.Add(clientpc2logoutButton);
            Name = "ClientForm2Dashboard";
            Text = "PC - 02 ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientpc2logoutButton;
        private Label c2_userlogLabel;
    }
}