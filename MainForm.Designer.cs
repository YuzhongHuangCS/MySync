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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.driveDataGridView = new System.Windows.Forms.DataGridView();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.deleteRowButton = new System.Windows.Forms.Button();
            this.addNewRowButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MimeType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.driveDataGridView)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // driveDataGridView
            // 
            this.driveDataGridView.AllowUserToOrderColumns = true;
            this.driveDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.driveDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.driveDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.driveDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.driveDataGridView.Size = new System.Drawing.Size(942, 553);
            this.driveDataGridView.TabIndex = 0;
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.statusLabel);
            this.buttonPanel.Controls.Add(this.loginButton);
            this.buttonPanel.Controls.Add(this.deleteRowButton);
            this.buttonPanel.Controls.Add(this.addNewRowButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanel.Location = new System.Drawing.Point(0, 507);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(942, 46);
            this.buttonPanel.TabIndex = 1;
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteRowButton.Location = new System.Drawing.Point(296, 3);
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(140, 40);
            this.deleteRowButton.TabIndex = 1;
            this.deleteRowButton.Text = "Delete Row";
            this.deleteRowButton.UseVisualStyleBackColor = true;
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // addNewRowButton
            // 
            this.addNewRowButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.addNewRowButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewRowButton.Location = new System.Drawing.Point(150, 3);
            this.addNewRowButton.Name = "addNewRowButton";
            this.addNewRowButton.Size = new System.Drawing.Size(140, 40);
            this.addNewRowButton.TabIndex = 0;
            this.addNewRowButton.Text = "Add Row";
            this.addNewRowButton.UseVisualStyleBackColor = true;
            this.addNewRowButton.Click += new System.EventHandler(this.addNewRowButton_Click);
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
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(442, 11);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(68, 25);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Ready";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 553);
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
        private Button addNewRowButton;
        private Button deleteRowButton;
        private Button loginButton;
        private DataGridViewTextBoxColumn FileName;
        private DataGridViewTextBoxColumn MimeType;
        private DataGridViewTextBoxColumn FileSize;
        private DataGridViewTextBoxColumn OwnerInfo;
        private DataGridViewTextBoxColumn ID;
        private Label statusLabel;
    }
}

