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
        private DriveService service;
        private List<Tuple<string, string>> path = new List<Tuple<string, string>>();

        public MainForm() {
            InitializeComponent();

            driveDataGridView.RowEnter += new DataGridViewCellEventHandler(driveDataGridView_CellMouseEnter);
            driveDataGridView.RowLeave += new DataGridViewCellEventHandler(driveDataGridView_CellMouseLeave);
            driveDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(driveDataGridView_CellDoubleClick);
        }

        private void driveDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                driveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }
  
        private void driveDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                driveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private async void driveDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                var row = driveDataGridView.Rows[e.RowIndex];
                if ((string) row.Cells[1].Value == "application/vnd.google-apps.folder") {
                    var parent = (string) row.Cells[4].Value;

                    path.Add(Tuple.Create(parent, (string)row.Cells[0].Value));
                    pathLabel.Text = path.Count > 1 ? String.Join("/", path.Select(t => t.Item2)) : "/";

                    statusLabel.Text = "Loading";
                    await Task.Run(() => ListDirectory(parent));
                    statusLabel.Text = "Done";
                }
            }
        }
 
        private async void upButton_Click(object sender, EventArgs e) {
            if (path.Count > 1) {
                path.RemoveAt(path.Count - 1);
                var tuple = path[path.Count - 1];
                pathLabel.Text = path.Count > 1 ? String.Join("/", path.Select(t => t.Item2)) : "/";

                statusLabel.Text = "Loading";
                var parent = tuple.Item1;
                if (parent == "") {
                    parent = null;
                }
                await Task.Run(() => ListDirectory(parent));
                statusLabel.Text = "Done";
            }
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
            path.Clear();
            path.Add(Tuple.Create("", ""));
            pathLabel.Text = path.Count > 1 ? String.Join("/", path.Select(t => t.Item2)) : "/";

            statusLabel.Text = "Loading";
            await Task.Run(() => ListDirectory());
            statusLabel.Text = "Done";
        }

        private async Task ListDirectory(string parent = null) {
            if (service == null) {
                service = await GetDriveService();
            }
            var fileList = service.Files.List();

            if (parent == null) {
                fileList.Q = $"";
            } else {
                fileList.Q = $"'{parent}' in parents";
            }
            fileList.Fields = "nextPageToken, files(name, mimeType, size, owners, id, parents)";
            fileList.Spaces = "drive";

            driveDataGridView.Invoke((MethodInvoker)delegate {
                driveDataGridView.Rows.Clear();
            });

            var rows = new List<string[]>();
            string pageToken = null;
            do {
                fileList.PageToken = pageToken;
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                foreach (var f in files) {
                    if (f.Parents == null || f.Parents.Contains(parent)) {
                        rows.Add(new string[] {
                            f.Name,
                            f.MimeType,
                            f.Size.HasValue ? f.Size.ToString() + " Bytes" : "",
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
