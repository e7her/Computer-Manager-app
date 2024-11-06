namespace ComputerManager.ServerForm
{
    partial class LockedAccounts
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
            lockedAccountsGridView = new DataGridView();
            LA_unlockaccountButton = new Button();
            ((System.ComponentModel.ISupportInitialize)lockedAccountsGridView).BeginInit();
            SuspendLayout();
            // 
            // lockedAccountsGridView
            // 
            lockedAccountsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            lockedAccountsGridView.Location = new Point(6, 12);
            lockedAccountsGridView.Name = "lockedAccountsGridView";
            lockedAccountsGridView.RowHeadersWidth = 51;
            lockedAccountsGridView.Size = new Size(713, 547);
            lockedAccountsGridView.TabIndex = 0;
            // 
            // LA_unlockaccountButton
            // 
            LA_unlockaccountButton.Location = new Point(289, 565);
            LA_unlockaccountButton.Name = "LA_unlockaccountButton";
            LA_unlockaccountButton.Size = new Size(150, 29);
            LA_unlockaccountButton.TabIndex = 1;
            LA_unlockaccountButton.Text = "Unlock Account";
            LA_unlockaccountButton.UseVisualStyleBackColor = true;
            LA_unlockaccountButton.Click += LA_unlockaccountButton_Click;
            // 
            // LockedAccounts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(725, 616);
            Controls.Add(LA_unlockaccountButton);
            Controls.Add(lockedAccountsGridView);
            Name = "LockedAccounts";
            Text = "LOCKED ACCOUNTS DASHBOARD";
            ((System.ComponentModel.ISupportInitialize)lockedAccountsGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView lockedAccountsGridView;
        private Button LA_unlockaccountButton;
    }
}