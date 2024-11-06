namespace ComputerManager.ServerForm
{
    partial class ClientPC2Details
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
            clientPC2Datagridview2 = new DataGridView();
            clientPC1Datagridview = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)clientPC2Datagridview2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)clientPC1Datagridview).BeginInit();
            SuspendLayout();
            // 
            // clientPC2Datagridview2
            // 
            clientPC2Datagridview2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientPC2Datagridview2.Location = new Point(101, 60);
            clientPC2Datagridview2.Name = "clientPC2Datagridview2";
            clientPC2Datagridview2.RowHeadersWidth = 51;
            clientPC2Datagridview2.Size = new Size(712, 78);
            clientPC2Datagridview2.TabIndex = 0;
            // 
            // clientPC1Datagridview
            // 
            clientPC1Datagridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientPC1Datagridview.Location = new Point(101, 190);
            clientPC1Datagridview.Name = "clientPC1Datagridview";
            clientPC1Datagridview.RowHeadersWidth = 51;
            clientPC1Datagridview.Size = new Size(712, 188);
            clientPC1Datagridview.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(411, 26);
            label1.Name = "label1";
            label1.Size = new Size(93, 20);
            label1.TabIndex = 1;
            label1.Text = "Current User:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(411, 156);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 2;
            label2.Text = "PC - 02 History:";
            // 
            // ClientPC2Details
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(957, 427);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clientPC1Datagridview);
            Controls.Add(clientPC2Datagridview2);
            Name = "ClientPC2Details";
            Text = "CLIENT 2 DETAILS";
            ((System.ComponentModel.ISupportInitialize)clientPC2Datagridview2).EndInit();
            ((System.ComponentModel.ISupportInitialize)clientPC1Datagridview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView clientPC2Datagridview2;
        private DataGridView clientPC1Datagridview;
        private Label label1;
        private Label label2;
    }
}