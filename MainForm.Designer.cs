using System.Windows.Forms;

namespace MyUpload
{
    partial class MainForm
    {
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DriveDataGridView = new DataGridView();
            FileName = new DataGridViewTextBoxColumn();
            MimeType = new DataGridViewTextBoxColumn();
            FileSize = new DataGridViewTextBoxColumn();
            OwnerInfo = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            ButtonPanel = new Panel();
            DeleteButton = new Button();
            UploadButton = new Button();
            DownloadButton = new Button();
            PathLabel = new Label();
            PathHintLabel = new Label();
            StatusLabel = new Label();
            LoginButton = new Button();
            LogoutButton = new Button();
            ParentButton = new Button();
            ((System.ComponentModel.ISupportInitialize)DriveDataGridView).BeginInit();
            ButtonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // DriveDataGridView
            // 
            DriveDataGridView.AllowUserToAddRows = false;
            DriveDataGridView.AllowUserToDeleteRows = false;
            DriveDataGridView.AllowUserToOrderColumns = true;
            DriveDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DriveDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DriveDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DriveDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DriveDataGridView.Columns.AddRange(new DataGridViewColumn[] { FileName, MimeType, FileSize, OwnerInfo, ID });
            DriveDataGridView.Dock = DockStyle.Fill;
            DriveDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            DriveDataGridView.Location = new System.Drawing.Point(0, 0);
            DriveDataGridView.Margin = new Padding(3, 4, 3, 4);
            DriveDataGridView.Name = "DriveDataGridView";
            DriveDataGridView.RowHeadersVisible = false;
            DriveDataGridView.RowHeadersWidth = 51;
            DriveDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DriveDataGridView.RowTemplate.Height = 24;
            DriveDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DriveDataGridView.Size = new System.Drawing.Size(1182, 553);
            DriveDataGridView.TabIndex = 0;
            // 
            // FileName
            // 
            FileName.HeaderText = "File Name";
            FileName.MinimumWidth = 6;
            FileName.Name = "FileName";
            // 
            // MimeType
            // 
            MimeType.HeaderText = "Type";
            MimeType.MinimumWidth = 6;
            MimeType.Name = "MimeType";
            // 
            // FileSize
            // 
            FileSize.HeaderText = "Size";
            FileSize.MinimumWidth = 6;
            FileSize.Name = "FileSize";
            // 
            // OwnerInfo
            // 
            OwnerInfo.HeaderText = "Owner";
            OwnerInfo.MinimumWidth = 6;
            OwnerInfo.Name = "OwnerInfo";
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            // 
            // ButtonPanel
            // 
            ButtonPanel.Controls.Add(DeleteButton);
            ButtonPanel.Controls.Add(UploadButton);
            ButtonPanel.Controls.Add(DownloadButton);
            ButtonPanel.Controls.Add(PathLabel);
            ButtonPanel.Controls.Add(PathHintLabel);
            ButtonPanel.Controls.Add(StatusLabel);
            ButtonPanel.Controls.Add(LoginButton);
            ButtonPanel.Controls.Add(LogoutButton);
            ButtonPanel.Controls.Add(ParentButton);
            ButtonPanel.Dock = DockStyle.Bottom;
            ButtonPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ButtonPanel.Location = new System.Drawing.Point(0, 495);
            ButtonPanel.Margin = new Padding(3, 4, 3, 4);
            ButtonPanel.Name = "ButtonPanel";
            ButtonPanel.Size = new System.Drawing.Size(1182, 58);
            ButtonPanel.TabIndex = 1;
            // 
            // DeleteButton
            // 
            DeleteButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DeleteButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DeleteButton.Location = new System.Drawing.Point(588, 4);
            DeleteButton.Margin = new Padding(3, 4, 3, 4);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new System.Drawing.Size(140, 50);
            DeleteButton.TabIndex = 5;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UploadButton
            // 
            UploadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            UploadButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            UploadButton.Location = new System.Drawing.Point(442, 4);
            UploadButton.Margin = new Padding(3, 4, 3, 4);
            UploadButton.Name = "UploadButton";
            UploadButton.Size = new System.Drawing.Size(140, 50);
            UploadButton.TabIndex = 4;
            UploadButton.Text = "Upload";
            UploadButton.UseVisualStyleBackColor = true;
            UploadButton.Click += UploadButton_Click;
            // 
            // DownloadButton
            // 
            DownloadButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            DownloadButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            DownloadButton.Location = new System.Drawing.Point(296, 4);
            DownloadButton.Margin = new Padding(3, 4, 3, 4);
            DownloadButton.Name = "DownloadButton";
            DownloadButton.Size = new System.Drawing.Size(140, 50);
            DownloadButton.TabIndex = 3;
            DownloadButton.Text = "Download";
            DownloadButton.UseVisualStyleBackColor = true;
            DownloadButton.Click += DownloadButton_Click;
            // 
            // PathLabel
            // 
            PathLabel.AutoSize = true;
            PathLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PathLabel.Location = new System.Drawing.Point(864, 14);
            PathLabel.Name = "PathLabel";
            PathLabel.Size = new System.Drawing.Size(44, 28);
            PathLabel.TabIndex = 7;
            PathLabel.Text = "null";
            // 
            // PathHintLabel
            // 
            PathHintLabel.AutoSize = true;
            PathHintLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            PathHintLabel.Location = new System.Drawing.Point(734, 14);
            PathHintLabel.Name = "PathHintLabel";
            PathHintLabel.Size = new System.Drawing.Size(124, 28);
            PathHintLabel.TabIndex = 6;
            PathHintLabel.Text = "Current Path:";
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new System.Drawing.Point(968, 15);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.RightToLeft = RightToLeft.Yes;
            StatusLabel.Size = new System.Drawing.Size(65, 28);
            StatusLabel.TabIndex = 8;
            StatusLabel.Text = "Ready";
            StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LoginButton
            // 
            LoginButton.Location = new System.Drawing.Point(4, 4);
            LoginButton.Margin = new Padding(3, 4, 3, 4);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new System.Drawing.Size(140, 50);
            LoginButton.TabIndex = 1;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            LogoutButton.Location = new System.Drawing.Point(1039, 4);
            LogoutButton.Margin = new Padding(3, 4, 3, 4);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new System.Drawing.Size(140, 50);
            LogoutButton.TabIndex = 9;
            LogoutButton.Text = "Logout";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // ParentButton
            // 
            ParentButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ParentButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ParentButton.Location = new System.Drawing.Point(150, 4);
            ParentButton.Margin = new Padding(3, 4, 3, 4);
            ParentButton.Name = "ParentButton";
            ParentButton.Size = new System.Drawing.Size(140, 50);
            ParentButton.TabIndex = 2;
            ParentButton.Text = "Parent";
            ParentButton.UseVisualStyleBackColor = true;
            ParentButton.Click += ParentButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1182, 553);
            Controls.Add(ButtonPanel);
            Controls.Add(DriveDataGridView);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)DriveDataGridView).EndInit();
            ButtonPanel.ResumeLayout(false);
            ButtonPanel.PerformLayout();
            ResumeLayout(false);
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

