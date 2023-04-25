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
            this.driveDataGridView = new System.Windows.Forms.DataGridView();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.uploadButton = new System.Windows.Forms.Button();
            this.downloadButton = new System.Windows.Forms.Button();
            this.pathLabel = new System.Windows.Forms.Label();
            this.pathHintLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.parentButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.driveDataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // driveDataGridView
            // 
            this.driveDataGridView.AllowUserToOrderColumns = true;
            this.driveDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.driveDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.driveDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.driveDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.driveDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileName,
            this.MimeType,
            this.FileSize,
            this.OwnerInfo,
            this.ID});
            this.driveDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.driveDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.driveDataGridView.Location = new System.Drawing.Point(0, 0);
            this.driveDataGridView.Name = "driveDataGridView";
            this.driveDataGridView.RowHeadersVisible = false;
            this.driveDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.driveDataGridView.RowTemplate.Height = 24;
            this.driveDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.driveDataGridView.Size = new System.Drawing.Size(1182, 553);
            this.driveDataGridView.TabIndex = 0;
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
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.uploadButton);
            this.buttonPanel.Controls.Add(this.downloadButton);
            this.buttonPanel.Controls.Add(this.pathLabel);
            this.buttonPanel.Controls.Add(this.pathHintLabel);
            this.buttonPanel.Controls.Add(this.statusLabel);
            this.buttonPanel.Controls.Add(this.loginButton);
            this.buttonPanel.Controls.Add(this.logoutButton);
            this.buttonPanel.Controls.Add(this.parentButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanel.Location = new System.Drawing.Point(0, 507);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(1182, 46);
            this.buttonPanel.TabIndex = 1;
            // 
            // uploadButton
            // 
            this.uploadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.uploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadButton.Location = new System.Drawing.Point(442, 3);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(140, 40);
            this.uploadButton.TabIndex = 6;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.uploadButton_Click);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.Location = new System.Drawing.Point(296, 3);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(140, 40);
            this.downloadButton.TabIndex = 5;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathLabel.Location = new System.Drawing.Point(722, 11);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(45, 25);
            this.pathLabel.TabIndex = 4;
            this.pathLabel.Text = "Null";
            // 
            // pathHintLabel
            // 
            this.pathHintLabel.AutoSize = true;
            this.pathHintLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathHintLabel.Location = new System.Drawing.Point(588, 11);
            this.pathHintLabel.Name = "pathHintLabel";
            this.pathHintLabel.Size = new System.Drawing.Size(128, 25);
            this.pathHintLabel.TabIndex = 2;
            this.pathHintLabel.Text = "Current Path:";
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(940, 11);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(68, 25);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(4, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(140, 40);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoutButton.Location = new System.Drawing.Point(1039, 3);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(140, 40);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // parentButton
            // 
            this.parentButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.parentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parentButton.Location = new System.Drawing.Point(150, 3);
            this.parentButton.Name = "parentButton";
            this.parentButton.Size = new System.Drawing.Size(140, 40);
            this.parentButton.TabIndex = 0;
            this.parentButton.Text = "Parent";
            this.parentButton.UseVisualStyleBackColor = true;
            this.parentButton.Click += new System.EventHandler(this.parentButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 553);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.driveDataGridView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.driveDataGridView)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView driveDataGridView;
        private Panel buttonPanel;
        private Button parentButton;
        private Button logoutButton;
        private Button loginButton;
        private Label statusLabel;
        private Label pathHintLabel;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn MimeType;
        private DataGridViewTextBoxColumn FileSize;
        private DataGridViewTextBoxColumn OwnerInfo;
        private DataGridViewTextBoxColumn ID;
        private Label pathLabel;
        private Button uploadButton;
        private Button downloadButton;
    }
}

