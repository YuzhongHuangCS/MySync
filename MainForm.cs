﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Reflection;

namespace MyUpload {
    public partial class MainForm : Form {
        public static string FOLDER_MIME = "application/vnd.google-apps.folder";
        private Stack<Tuple<string, string>> PATH = new Stack<Tuple<string, string>>();
        private DriveService DRIVE_SERVICE;
        private string ROOT_ID;
        private Task<List<string>> ALL_FOLDERS_ID;

        public MainForm() {
            InitializeComponent();

            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               DriveDataGridView,
               new object[] { true }
            );

            DriveDataGridView.RowEnter += new DataGridViewCellEventHandler(DriveDataGridView_CellMouseEnter);
            DriveDataGridView.RowLeave += new DataGridViewCellEventHandler(DriveDataGridView_CellMouseLeave);
            DriveDataGridView.CellDoubleClick += new DataGridViewCellEventHandler(DriveDataGridView_CellDoubleClick);
        }

        private void DriveDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                DriveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
        }
  
        private void DriveDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                DriveDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private async void DriveDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex > -1) {
                var row = DriveDataGridView.Rows[e.RowIndex];
                if ((string) row.Cells[1].Value == FOLDER_MIME) {
                    var parentName = (string) row.Cells[0].Value;
                    var parentId = (string) row.Cells[4].Value;

                    PATH.Push(Tuple.Create(parentName, parentId));
                    PathLabel.Text = string.Join("/", PATH.Select(t => t.Item1).Reverse());

                    StatusLabel.Text = "Loading";
                    await Task.Run(() => ListDirectory(parentId));
                    StatusLabel.Text = "Done";
                }
            }
        }
 
        private async void ParentButton_Click(object sender, EventArgs e) {
            if (PATH.Count > 1) {
                PATH.Pop();
                var tuple = PATH.Peek();
                PathLabel.Text = string.Join("/", PATH.Select(t => t.Item1).Reverse());

                StatusLabel.Text = "Loading";
                var parent = tuple.Item2;
                await Task.Run(() => ListDirectory(parent));
                StatusLabel.Text = "Done";
            }
        }

        private async void LoginButton_Click(object sender, EventArgs e) {
            if (DRIVE_SERVICE == null) {
                await InitDriveService();
            }

            PATH.Clear();
            PATH.Push(Tuple.Create<string, string>("/", null));
            PathLabel.Text = string.Join("/", PATH.Select(t => t.Item1).Reverse());

            StatusLabel.Text = "Loading";
            await Task.Run(() => ListDirectory());
            StatusLabel.Text = "Done";
        }

        private async void LogoutButton_Click(object sender, EventArgs e) {
            var storage = new FileDataStore("MyUpload");
            await storage.ClearAsync();

            Application.Exit();
        }

        private async void DownloadButton_Click(object sender, EventArgs e) {
            if (DRIVE_SERVICE != null && DriveDataGridView.SelectedCells.Count > 0) {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    var indexSet = new HashSet<int>();
                    foreach (DataGridViewCell cell in DriveDataGridView.SelectedCells) {
                        indexSet.Add(cell.RowIndex);
                    }

                    StatusLabel.Text = "Downloading";
                    await Task.Run(() => {
                        var options = new ParallelOptions() { MaxDegreeOfParallelism = 10 };
                        Parallel.ForEach(indexSet, options, index => {
                            string ID = (string)DriveDataGridView.Rows[index].Cells[4].Value;
                            string filename = dialog.SelectedPath + "\\" + (string)DriveDataGridView.Rows[index].Cells[0].Value;
                            DownloadFile(ID, filename);
                        });
                    });
                    StatusLabel.Text = "Done";
                }
            } else {
                MessageBox.Show("Please Login First");
            }
        }

        private void DownloadFile(string ID, string filename) {
            var request = DRIVE_SERVICE.Files.Get(ID);
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

        private async void UploadButton_Click(object sender, EventArgs e) {
            const string dummyName = "Folder";
            if (DRIVE_SERVICE != null) {
                OpenFileDialog dialog = new OpenFileDialog {
                    ValidateNames = false,
                    CheckFileExists = false,
                    CheckPathExists = true,
                    FileName = dummyName,
                    Multiselect = true
                };
                if (dialog.ShowDialog() == DialogResult.OK) {
                    StatusLabel.Text = "Uploading";
                    var uploads = new List<Tuple<string, string>>();
                    foreach (var f in dialog.FileNames) {
                        if (File.Exists(f)) {
                            uploads.Add(Tuple.Create(f, PATH.Peek().Item2));
                        } else {
                            if (f.EndsWith(dummyName)) {
                                var folder = f.Substring(0, f.Length - dummyName.Length - 1);
                                var parent = PATH.Peek().Item2;
                                await WalkDirectory(folder, parent, uploads);
                            }
                        }
                    }

                    await Task.Run(() => {
                        var options = new ParallelOptions() { MaxDegreeOfParallelism = 10 };
                        Parallel.ForEach(uploads, options, tp => {
                            using (var stream = new FileStream(tp.Item1, FileMode.Open, FileAccess.Read)) {
                                var driveFile = new Google.Apis.Drive.v3.Data.File {
                                    Name = Path.GetFileName(tp.Item1)
                                };
                                if (tp.Item2 != null) {
                                    driveFile.Parents = new string[] { tp.Item2 };
                                }
                                var request = DRIVE_SERVICE.Files.Create(driveFile, stream, MimeMapping.MimeUtility.GetMimeMapping(tp.Item1));
                                request.Fields = "id";
                                request.Upload();

                                Console.WriteLine($"Upload successful. {tp.Item1} File ID: {request.ResponseBody.Id}");
                            }
                        });
                    });
                    StatusLabel.Text = "Done";
                }

            } else {
                MessageBox.Show("Please Login First");
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e) {
            if (DRIVE_SERVICE != null && DriveDataGridView.SelectedCells.Count > 0) {
                var indexSet = new HashSet<int>();
                foreach (DataGridViewCell cell in DriveDataGridView.SelectedCells) {
                    indexSet.Add(cell.RowIndex);
                }

                StatusLabel.Text = "Deleting";
                foreach (var index in indexSet) {
                    string fileName = (string)DriveDataGridView.Rows[index].Cells[0].Value;
                    string type = (string)DriveDataGridView.Rows[index].Cells[1].Value;
                    string ID = (string) DriveDataGridView.Rows[index].Cells[4].Value;
                    if (type != FOLDER_MIME) {
                        Console.WriteLine($"del: {fileName}");
                        var driveFile = new Google.Apis.Drive.v3.Data.File {
                            Trashed = true
                        };

                        var request = DRIVE_SERVICE.Files.Update(driveFile, ID);
                        await request.ExecuteAsync();
                    }
                }
                StatusLabel.Text = "Done";
            } else {
                MessageBox.Show("Please Login First");
            }
        }

        private async Task WalkDirectory(string folder, string parent, List<Tuple<string, string>> uploads) {
            var driveFolder = new Google.Apis.Drive.v3.Data.File {
                Name = Path.GetFileName(folder),
                MimeType = FOLDER_MIME
            };
            if (parent != null) {
                driveFolder.Parents = new string[] { parent };
            }
            var request = DRIVE_SERVICE.Files.Create(driveFolder);
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
            var fileList = DRIVE_SERVICE.Files.List();

            if (parent == null) {
                var parentList = await ALL_FOLDERS_ID;
                var parentString = string.Join(" and ", parentList.Select(p => $"not '{p}' in parents"));
                Console.WriteLine(parentString);
                fileList.Q = parentString;
            } else {
                fileList.Q = $"'{parent}' in parents";
            }
            fileList.Fields = "nextPageToken, files(name, mimeType, size, owners, id, parents)";
            fileList.Spaces = "drive";

            DriveDataGridView.Invoke((MethodInvoker)delegate {
                DriveDataGridView.Rows.Clear();

                if (parent == null) {
                    DriveDataGridView.Rows.Add(new string[] {
                        "My Drive",
                        FOLDER_MIME,
                        "",
                        "",
                        ROOT_ID,
                    });
                }
            });

            var rows = new List<DataGridViewRow>();
            do {
                var filesResult = await fileList.ExecuteAsync();
                foreach (var f in filesResult.Files) {
                    if (f.Parents == null || f.Parents.Contains(parent)) {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(DriveDataGridView);
                        row.DefaultCellStyle = DriveDataGridView.RowTemplate.DefaultCellStyle.Clone();
                        row.Height = DriveDataGridView.RowTemplate.Height;

                        row.Cells[0].Value = f.Name;
                        row.Cells[1].Value = f.MimeType;
                        row.Cells[2].Value = f.Size.HasValue ? $"{f.Size / 1024.0 / 1024.0:0.##} MB" : "";
                        row.Cells[3].Value = string.Join("; ", f.Owners.Select(o => $"{o.DisplayName} <{o.EmailAddress}>"));
                        row.Cells[4].Value = f.Id;
                        rows.Add(row);
                    }
                }

                DriveDataGridView.Invoke((MethodInvoker) delegate {
                    DriveDataGridView.Rows.AddRange(rows.ToArray());
                });
                rows.Clear();
                fileList.PageToken = filesResult.NextPageToken;
            } while (fileList.PageToken != null);
        }

        private async Task InitDriveService() {
            var storage = new FileDataStore("MyUpload");

            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile("credentials.json").Secrets,
                new[] { DriveService.Scope.Drive },
                "user",
                CancellationToken.None,
                storage
            );

            DRIVE_SERVICE = new DriveService(new BaseClientService.Initializer {
                HttpClientInitializer = credential,
            });

            ALL_FOLDERS_ID = ListAllFolders();

            ROOT_ID = (await DRIVE_SERVICE.Files.Get("root").ExecuteAsync()).Id;
        }

        private async Task<List<string>> ListAllFolders() {
            var parentList = new List<string> {
                "root"
            };

            var folderList = DRIVE_SERVICE.Files.List();
            folderList.Q = $"mimeType='{FOLDER_MIME}'";
            folderList.Fields = "nextPageToken, files(id)";
            folderList.Spaces = "drive";

            for (int i = 0; i < 5; i++) {
                var foldersResult = await folderList.ExecuteAsync();
                parentList.AddRange(foldersResult.Files.Select(f => f.Id));
                
                folderList.PageToken = foldersResult.NextPageToken;
                Console.WriteLine(folderList.PageToken);

                if (folderList.PageToken == null) {
                    break;
                }
            }

            return parentList;
        }
    }
}
