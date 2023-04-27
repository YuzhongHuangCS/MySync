using System.Windows.Forms;

namespace MyUpload {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DriveDataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.PathLabel = new System.Windows.Forms.Label();
            this.PathHintLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.ParentButton = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DriveDataGridView)).BeginInit();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // DriveDataGridView
            // 
            this.DriveDataGridView.AllowUserToOrderColumns = true;
            this.DriveDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DriveDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DriveDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DriveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DriveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.MimeType,
            this.FileSize,
            this.OwnerInfo,
            this.ID});
            this.DriveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DriveDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DriveDataGridView.Location = new System.Drawing.Point(0, 0);
            this.DriveDataGridView.Name = "DriveDataGridView";
            this.DriveDataGridView.RowHeadersVisible = false;
            this.DriveDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveDataGridView.RowTemplate.Height = 24;
            this.DriveDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DriveDataGridView.Size = new System.Drawing.Size(1582, 753);
            this.DriveDataGridView.TabIndex = 0;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.DeleteButton);
            this.ButtonPanel.Controls.Add(this.UploadButton);
            this.ButtonPanel.Controls.Add(this.DownloadButton);
            this.ButtonPanel.Controls.Add(this.PathLabel);
            this.ButtonPanel.Controls.Add(this.PathHintLabel);
            this.ButtonPanel.Controls.Add(this.StatusLabel);
            this.ButtonPanel.Controls.Add(this.LoginButton);
            this.ButtonPanel.Controls.Add(this.LogoutButton);
            this.ButtonPanel.Controls.Add(this.ParentButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPanel.Location = new System.Drawing.Point(0, 707);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1582, 46);
            this.ButtonPanel.TabIndex = 1;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(588, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(140, 40);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.Location = new System.Drawing.Point(442, 3);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(140, 40);
            this.UploadButton.TabIndex = 6;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DownloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadButton.Location = new System.Drawing.Point(296, 3);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(140, 40);
            this.DownloadButton.TabIndex = 5;
            this.DownloadButton.Text = "Download";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathLabel.Location = new System.Drawing.Point(858, 11);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(45, 25);
            this.PathLabel.TabIndex = 4;
            this.PathLabel.Text = "Null";
            // 
            // PathHintLabel
            // 
            this.PathHintLabel.AutoSize = true;
            this.PathHintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathHintLabel.Location = new System.Drawing.Point(724, 11);
            this.PathHintLabel.Name = "PathHintLabel";
            this.PathHintLabel.Size = new System.Drawing.Size(128, 25);
            this.PathHintLabel.TabIndex = 2;
            this.PathHintLabel.Text = "Current Path:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(1340, 11);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(68, 25);
            this.StatusLabel.TabIndex = 3;
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(4, 3);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(140, 40);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutButton.Location = new System.Drawing.Point(1439, 3);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(140, 40);
            this.LogoutButton.TabIndex = 1;
            this.LogoutButton.Text = "Logout";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // ParentButton
            // 
            this.ParentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ParentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParentButton.Location = new System.Drawing.Point(150, 3);
            this.ParentButton.Name = "ParentButton";
            this.ParentButton.Size = new System.Drawing.Size(140, 40);
            this.ParentButton.TabIndex = 0;
            this.ParentButton.Text = "Parent";
            this.ParentButton.UseVisualStyleBackColor = true;
            this.ParentButton.Click += new System.EventHandler(this.ParentButton_Click);
            // 
            // FileName
            // 
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            // 
            // MimeType
            // 
            this.MimeType.HeaderText = "Type";
            this.MimeType.Name = "MimeType";
            // 
            // FileSize
            // 
            this.FileSize.HeaderText = "Size";
            this.FileSize.Name = "FileSize";
            // 
            // OwnerInfo
            // 
            this.OwnerInfo.HeaderText = "Owner";
            this.OwnerInfo.Name = "OwnerInfo";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 753);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.DriveDataGridView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.DriveDataGridView)).EndInit();
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView DriveDataGridView;
        private Panel ButtonPanel;
        private Button ParentButton;
        private Button LogoutButton;
        private Button LoginButton;
        private Label StatusLabel;
        private Label PathHintLabel;
        private Label PathLabel;
        private Button UploadButton;
        private Button DownloadButton;
        private Button DeleteButton;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn MimeType;
        private DataGridViewTextBoxColumn FileSize;
        private DataGridViewTextBoxColumn OwnerInfo;
        private DataGridViewTextBoxColumn ID;
    }
}

