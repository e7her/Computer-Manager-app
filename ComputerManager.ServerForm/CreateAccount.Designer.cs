namespace ComputerManager.ServerForm
{
    partial class CreateAccount
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
            CA_createAccountlabel = new Label();
            firstnameTextbox = new TextBox();
            lastnameTextbox = new TextBox();
            programTextbox = new TextBox();
            firstnameLabel = new Label();
            lastnameLabel = new Label();
            programLabel = new Label();
            emailTextbox = new TextBox();
            emailLabel = new Label();
            studentidLabel = new Label();
            studentidTextbox = new TextBox();
            CA_studentaccountLabel = new Label();
            desiredpasswordTextbox = new TextBox();
            passwordLabel = new Label();
            confirmpasswordLabel = new Label();
            confirmpasswordTextbox = new TextBox();
            createaccountButton = new Button();
            SuspendLayout();
            // 
            // CA_createAccountlabel
            // 
            CA_createAccountlabel.AutoSize = true;
            CA_createAccountlabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CA_createAccountlabel.Location = new Point(76, 9);
            CA_createAccountlabel.Name = "CA_createAccountlabel";
            CA_createAccountlabel.Size = new Size(136, 54);
            CA_createAccountlabel.TabIndex = 0;
            CA_createAccountlabel.Text = "Profile";
            // 
            // firstnameTextbox
            // 
            firstnameTextbox.Location = new Point(39, 89);
            firstnameTextbox.Name = "firstnameTextbox";
            firstnameTextbox.Size = new Size(202, 27);
            firstnameTextbox.TabIndex = 1;
            // 
            // lastnameTextbox
            // 
            lastnameTextbox.Location = new Point(39, 170);
            lastnameTextbox.Name = "lastnameTextbox";
            lastnameTextbox.Size = new Size(202, 27);
            lastnameTextbox.TabIndex = 2;
            // 
            // programTextbox
            // 
            programTextbox.Location = new Point(39, 263);
            programTextbox.Name = "programTextbox";
            programTextbox.Size = new Size(202, 27);
            programTextbox.TabIndex = 3;
            // 
            // firstnameLabel
            // 
            firstnameLabel.AutoSize = true;
            firstnameLabel.Location = new Point(99, 66);
            firstnameLabel.Name = "firstnameLabel";
            firstnameLabel.Size = new Size(83, 20);
            firstnameLabel.TabIndex = 4;
            firstnameLabel.Text = "First Name:";
            // 
            // lastnameLabel
            // 
            lastnameLabel.AutoSize = true;
            lastnameLabel.Location = new Point(99, 147);
            lastnameLabel.Name = "lastnameLabel";
            lastnameLabel.Size = new Size(82, 20);
            lastnameLabel.TabIndex = 5;
            lastnameLabel.Text = "Last Name:";
            // 
            // programLabel
            // 
            programLabel.AutoSize = true;
            programLabel.Location = new Point(106, 240);
            programLabel.Name = "programLabel";
            programLabel.Size = new Size(69, 20);
            programLabel.TabIndex = 6;
            programLabel.Text = "Program:";
            // 
            // emailTextbox
            // 
            emailTextbox.Location = new Point(39, 348);
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new Size(202, 27);
            emailTextbox.TabIndex = 7;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(91, 325);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(98, 20);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "School Email:";
            // 
            // studentidLabel
            // 
            studentidLabel.AutoSize = true;
            studentidLabel.Location = new Point(467, 66);
            studentidLabel.Name = "studentidLabel";
            studentidLabel.Size = new Size(82, 20);
            studentidLabel.TabIndex = 9;
            studentidLabel.Text = "Student ID:";
            // 
            // studentidTextbox
            // 
            studentidTextbox.Location = new Point(407, 89);
            studentidTextbox.Name = "studentidTextbox";
            studentidTextbox.Size = new Size(202, 27);
            studentidTextbox.TabIndex = 10;
            // 
            // CA_studentaccountLabel
            // 
            CA_studentaccountLabel.AutoSize = true;
            CA_studentaccountLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CA_studentaccountLabel.Location = new Point(357, 9);
            CA_studentaccountLabel.Name = "CA_studentaccountLabel";
            CA_studentaccountLabel.Size = new Size(295, 54);
            CA_studentaccountLabel.TabIndex = 11;
            CA_studentaccountLabel.Text = "Account details";
            // 
            // desiredpasswordTextbox
            // 
            desiredpasswordTextbox.Location = new Point(407, 170);
            desiredpasswordTextbox.Name = "desiredpasswordTextbox";
            desiredpasswordTextbox.PasswordChar = '*';
            desiredpasswordTextbox.Size = new Size(202, 27);
            desiredpasswordTextbox.TabIndex = 12;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(443, 147);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(130, 20);
            passwordLabel.TabIndex = 13;
            passwordLabel.Text = "Desired password:";
            // 
            // confirmpasswordLabel
            // 
            confirmpasswordLabel.AutoSize = true;
            confirmpasswordLabel.Location = new Point(442, 240);
            confirmpasswordLabel.Name = "confirmpasswordLabel";
            confirmpasswordLabel.Size = new Size(132, 20);
            confirmpasswordLabel.TabIndex = 14;
            confirmpasswordLabel.Text = "Confirm password:";
            // 
            // confirmpasswordTextbox
            // 
            confirmpasswordTextbox.Location = new Point(407, 263);
            confirmpasswordTextbox.Name = "confirmpasswordTextbox";
            confirmpasswordTextbox.PasswordChar = '*';
            confirmpasswordTextbox.Size = new Size(202, 27);
            confirmpasswordTextbox.TabIndex = 15;
            // 
            // createaccountButton
            // 
            createaccountButton.Location = new Point(434, 348);
            createaccountButton.Name = "createaccountButton";
            createaccountButton.Size = new Size(140, 36);
            createaccountButton.TabIndex = 16;
            createaccountButton.Text = "Create Account";
            createaccountButton.UseVisualStyleBackColor = true;
            createaccountButton.Click += createaccountButton_Click;
            // 
            // CreateAccount
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 434);
            Controls.Add(createaccountButton);
            Controls.Add(confirmpasswordTextbox);
            Controls.Add(confirmpasswordLabel);
            Controls.Add(passwordLabel);
            Controls.Add(desiredpasswordTextbox);
            Controls.Add(CA_studentaccountLabel);
            Controls.Add(studentidTextbox);
            Controls.Add(studentidLabel);
            Controls.Add(emailLabel);
            Controls.Add(emailTextbox);
            Controls.Add(programLabel);
            Controls.Add(lastnameLabel);
            Controls.Add(firstnameLabel);
            Controls.Add(programTextbox);
            Controls.Add(lastnameTextbox);
            Controls.Add(firstnameTextbox);
            Controls.Add(CA_createAccountlabel);
            Name = "CreateAccount";
            Text = "CREATE ACCOUNT";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CA_createAccountlabel;
        private TextBox firstnameTextbox;
        private TextBox lastnameTextbox;
        private TextBox programTextbox;
        private Label firstnameLabel;
        private Label lastnameLabel;
        private Label programLabel;
        private TextBox emailTextbox;
        private Label emailLabel;
        private Label studentidLabel;
        private TextBox studentidTextbox;
        private Label CA_studentaccountLabel;
        private TextBox desiredpasswordTextbox;
        private Label passwordLabel;
        private Label confirmpasswordLabel;
        private TextBox confirmpasswordTextbox;
        private Button createaccountButton;
    }
}