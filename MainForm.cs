using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Reflection;

namespace MyUpload {
    public partial class MainForm : Form {
        private DriveService service;
        private Stack<Tuple<string, string>> path = new Stack<Tuple<string, string>>();

        public MainForm() {
            InitializeComponent();

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               driveDataGridView,
               new object[] { true }
            );

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
                    var parentName = (string) row.Cells[0].Value;
                    var parentId = (string) row.Cells[4].Value;

                    path.Push(Tuple.Create(parentName, parentId));
                    pathLabel.Text = string.Join("/", path.Select(t => t.Item1).Reverse());

                    statusLabel.Text = "Loading";
                    await Task.Run(() => ListDirectory(parentId));
                    statusLabel.Text = "Done";
                }
            }
        }
 
        private async void parentButton_Click(object sender, EventArgs e) {
            if (path.Count > 1) {
                path.Pop();
                var tuple = path.Peek();
                pathLabel.Text = string.Join("/", path.Select(t => t.Item1).Reverse());

                statusLabel.Text = "Loading";
                var parent = tuple.Item2;
                await Task.Run(() => ListDirectory(parent));
                statusLabel.Text = "Done";
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            path.Clear();
            path.Push(Tuple.Create<string, string>("/", null));
            pathLabel.Text = string.Join("/", path.Select(t => t.Item1).Reverse());

            statusLabel.Text = "Loading";
            await Task.Run(() => ListDirectory());
            statusLabel.Text = "Done";
        }

        private async void logoutButton_Click(object sender, EventArgs e) {
            var storage = new FileDataStore("MyUpload");
            await storage.ClearAsync();

            Application.Exit();
        }

        private async void downloadButton_Click(object sender, EventArgs e) {
            if (service != null && driveDataGridView.SelectedCells.Count > 0) {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    var indexSet = new HashSet<int>();
                    foreach (DataGridViewCell cell in driveDataGridView.SelectedCells) {
                        indexSet.Add(cell.RowIndex);
                    }

                    statusLabel.Text = "Downloading";
                    await Task.Run(() => {
                        var options = new ParallelOptions() { MaxDegreeOfParallelism = 10 };
                        Parallel.ForEach(indexSet, options, index => {
                            string ID = (string)driveDataGridView.Rows[index].Cells[4].Value;
                            string filename = dialog.SelectedPath + "\\" + (string)driveDataGridView.Rows[index].Cells[0].Value;
                            DownloadFile(ID, filename);
                        });
                    });
                    statusLabel.Text = "Done";
                }
            } else {
                MessageBox.Show("Please Login First");
            }
        }

        private void DownloadFile(string ID, string filename) {
            var request = service.Files.Get(ID);
            using (var stream = new FileStream(filename, FileMode.Create)) {
                request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) => {
                    switch (progress.Status) {
                        case Google.Apis.Download.DownloadStatus.Downloading: {
                                Console.WriteLine($"{filename}: {progress.BytesDownloaded} Bytes");
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Completed: {
                                Console.WriteLine($"{filename}: Download complete.");
                                break;
                            }
                        case Google.Apis.Download.DownloadStatus.Failed: {
                                Console.WriteLine($"{filename}: Download failed.");
                                break;
                            }
                    }
                };
                request.Download(stream);
            }
        }

        private async void uploadButton_Click(object sender, EventArgs e) {
            const string dummyName = "Folder";
            if (service != null) {
                OpenFileDialog dialog = new OpenFileDialog {
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    FileName = dummyName,
                    Multiselect = true
                };
                if (dialog.ShowDialog() == DialogResult.OK) {
                    statusLabel.Text = "Uploading";
                    var uploads = new List<Tuple<string, string>>();
                    foreach (var f in dialog.FileNames) {
                        if (File.Exists(f)) {
                            uploads.Add(Tuple.Create(f, path.Peek().Item2));
                        } else {
                            if (f.EndsWith(dummyName)) {
                                var folder = f.Substring(0, f.Length - dummyName.Length - 1);
                                var parent = path.Peek().Item2;
                                await WalkDirectory(folder, parent, uploads);
                            }
                        }
                    }

                    await Task.Run(() => {
                        var options = new ParallelOptions() { MaxDegreeOfParallelism = 10 };
                        Parallel.ForEach(uploads, options, tp => {
                            using (var stream = new FileStream(tp.Item1, FileMode.Open)) {
                                var driveFile = new Google.Apis.Drive.v3.Data.File {
                                    Name = Path.GetFileName(tp.Item1)
                                };
                                if (tp.Item2 != null) {
                                    driveFile.Parents = new string[] { tp.Item2 };
                                }
                                var request = service.Files.Create(driveFile, stream, MimeMapping.GetMimeMapping(tp.Item1));
                                request.Fields = "id";
                                request.Upload();

                                Console.WriteLine($"Upload successful. {tp.Item1} File ID: {request.ResponseBody.Id}");
                            }
                        });
                    });
                    statusLabel.Text = "Done";
                }

            } else {
                MessageBox.Show("Please Login First");
            }
        }

        private async Task WalkDirectory(string folder, string parent, List<Tuple<string, string>> uploads) {
            var driveFolder = new Google.Apis.Drive.v3.Data.File {
                Name = Path.GetFileName(folder),
                MimeType = "application/vnd.google-apps.folder"
            };
            if (parent != null) {
                driveFolder.Parents = new string[] { parent };
            }
            var request = service.Files.Create(driveFolder);
            var response = await request.ExecuteAsync();

            Console.WriteLine($"Create successful. {folder} File ID: {response.Id}");

            var files = Directory.EnumerateFiles(folder);
            foreach (var file in files) {
                uploads.Add(Tuple.Create(file, response.Id));
                Console.WriteLine($"file: {file}");
            }

            var dirs = Directory.GetDirectories(folder);
            var tasks = new List<Task>();
            foreach (var dir in dirs) {
                tasks.Add(WalkDirectory(dir, response.Id, uploads));
                Console.WriteLine($"dir: {dir}");
            }
            await Task.WhenAll(tasks);
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

            var rows = new List<DataGridViewRow>();
            do {
                var filesResult = fileList.Execute();
                var files = filesResult.Files;
                foreach (var f in files) {
                    if (f.Parents == null || f.Parents.Contains(parent)) {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(driveDataGridView);
                        row.DefaultCellStyle = driveDataGridView.RowTemplate.DefaultCellStyle.Clone();
                        row.Height = driveDataGridView.RowTemplate.Height;

                        row.Cells[0].Value = f.Name;
                        row.Cells[1].Value = f.MimeType;
                        row.Cells[2].Value = f.Size.HasValue ? $"{f.Size / 1024.0 / 1024.0:0.##} MB" : "";
                        row.Cells[3].Value = string.Join("; ", f.Owners.Select(o => $"{o.DisplayName} <{o.EmailAddress}>"));
                        row.Cells[4].Value = f.Id;
                        rows.Add(row);
                    }
                }

                driveDataGridView.Invoke((MethodInvoker) delegate {
                    driveDataGridView.Rows.AddRange(rows.ToArray());
                });
                rows.Clear();
                fileList.PageToken = filesResult.NextPageToken;
            } while (fileList.PageToken != null);
        }

        private async Task<DriveService> GetDriveService() {
            var storage = new FileDataStore("MyUpload");

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
