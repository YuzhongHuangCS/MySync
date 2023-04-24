using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace MyUpload {
    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            //PopulateDataGridView();

            //driveDataGridView.CellMouseEnter += new DataGridViewCellEventHandler(songsDataGridView_CellMouseEnter);
            //driveDataGridView.CellMouseLeave += new DataGridViewCellEventHandler(songsDataGridView_CellMouseLeave);
        }

        private void songsDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                driveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }

        }
  
        private void songsDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                driveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
   
        private void addNewRowButton_Click(object sender, EventArgs e) {
            this.driveDataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventArgs e) {
            if (this.driveDataGridView.SelectedRows.Count > 0 &&
                this.driveDataGridView.SelectedRows[0].Index !=
                this.driveDataGridView.Rows.Count - 1) {
                this.driveDataGridView.Rows.RemoveAt(
                    this.driveDataGridView.SelectedRows[0].Index);
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            statusLabel.Text = "Start";
            await Task.Run(() => DoLogin());
            statusLabel.Text = "Done";
        }

        private async Task DoLogin() {
            var service = await GetDriveService();
            var fileList = service.Files.List();
            fileList.Q = $"";
            fileList.Fields = "nextPageToken, files(id, name, mimeType, size, parents, owners)";
            fileList.Spaces = "drive";

            var rows = new List<string[]>();
            string pageToken = null;
            do {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                foreach (var f in files) {
                    if (f.Parents == null) {
                        rows.Add(new string[] {
                            f.Name,
                            f.MimeType,
                            f.Size.ToString() + " Bytes",
                            String.Join("; ", f.Owners.Select(o => $"{o.DisplayName} <{o.EmailAddress}>")),
                            f.Id
                        });
                    }
                }

                driveDataGridView.Invoke((MethodInvoker) delegate {
                    foreach (var r in rows) {
                        driveDataGridView.Rows.Add(r);
                    }
                });
                rows.Clear();
                pageToken = filesResult.NextPageToken;
            } while (pageToken != null);
        }

        private async Task<DriveService> GetDriveService() {
            var storage = new FileDataStore("MyUpload");
            // await storage.ClearAsync();

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile("credentials.json").Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                storage
            );

            var service = new DriveService(new BaseClientService.Initializer {
                HttpClientInitializer = credential,
            });

            return service;
        }
    }
}
