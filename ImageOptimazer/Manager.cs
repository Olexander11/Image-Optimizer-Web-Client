using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOptimizer
{
    internal class Manager
    {
        public delegate void MessangerHandler(object sender, string e);
        public delegate void RowChangeStateHandler(object sender, TableItem e);
        public delegate void RowsStateHandler(object sender, List<TableItem> e);

        private static readonly object Locker = new object();
        private static bool _isProgramClosing;
        private readonly DBService _bService;
        private bool _krakenIsStarting;


        public Manager()
        {
            _bService = new DBService();
        }

        public List<TableItem> RowItem { get; private set; }
        public Dictionary<string, string> Settings { get; set; }
        public Dictionary<string, string> Parametrs { get; set; }
        public event RowsStateHandler AddingRows;
        public event RowChangeStateHandler ChangingRow;
        public event MessangerHandler Messaging;

        public void InitializationOldData()
        {
            RowItem = _bService.DataInitialization();
            AddingRows?.Invoke(this, RowItem);

            Task.Run(() => GetStartedWithKraken());
        }

        /// <summary>
        /// close program
        /// </summary>
        public void CloseOptimization()
        {
            lock (Locker)
            {
                _isProgramClosing = true;
            }
            foreach (TableItem item in RowItem)
            {
                if (item.StatusItem == TableItem.StatusType.Downloading)
                {
                    item.StatusItem = TableItem.StatusType.Sended;
                    _bService.UpdateImageData(item);
                }
                if (item.StatusItem == TableItem.StatusType.Sending)
                {
                    item.StatusItem = TableItem.StatusType.NotSent;
                    _bService.UpdateImageData(item);
                }
            }
        }


        /// <summary>
        /// delete row from table
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteRow(string fileName)
        {
            TableItem itemToRemove = RowItem.Single(r => r.FileName.FullName == fileName);
            if (itemToRemove != null)
            {
                RowItem.Remove(itemToRemove);
                _bService.DeleteImadgeData(fileName);
            }
        }

        /// <summary>
        /// make optimization
        /// </summary>
        private void GetStartedWithKraken()
        {
            InitializationSettings();
            if (Settings["keyAPI"] == "Type your - api - key" || Settings["secret"] == "Type your-api-secret")
            {
                Messaging?.Invoke(this, "Plese set you key and(or) secret key for kraken.io");
                return;
            }
            _krakenIsStarting = true;
            int currentProcessUnloading = 0;
            int currentProcessDownload = 0;

            while (true)
            {
                int countSetDownloading = Int32.Parse(Settings["Threads"]);
                int countSetUploading = Int32.Parse(Settings["Threads"]);

                if (currentProcessDownload <= countSetDownloading)
                {
                    if (RowItem == null) return;
                    TableItem item = RowItem.FirstOrDefault(it => it.StatusItem == TableItem.StatusType.Sended && !it.ItemInProcess);

                    if (item != null)
                    {
                        item.ItemInProcess = true;
                        Interlocked.Increment(ref currentProcessDownload);

                        string selectedFile = item.FileName.FullName;
                        var worker = new Worker(Settings["keyAPI"], Settings["secret"], selectedFile, Parametrs) {KrakenURL = item.KrakenURL};
                        var tasksDownload = new Task(worker.LoadImage);

                        lock (Locker)
                        {
                            if (_isProgramClosing) return;
                            item.StatusItem = TableItem.StatusType.Downloading;
                            _bService.UpdateImageData(item);
                        }
                        ChangingRow?.Invoke(this, item);
                        tasksDownload.Start();

                        tasksDownload.ContinueWith(t =>
                            {
                                lock (Locker)
                                {
                                    if (_isProgramClosing) return;
                                    if (worker.ErrorMessage == null)
                                    {
                                        item.StatusItem = TableItem.StatusType.Downloaded;
                                        item.SizeAfter = (uint) (new FileInfo(item.FileName.FullName + ".back")).Length;
                                        RewriteFile(item.FileName);
                                    }
                                    else
                                    {
                                        item.Description = worker.ErrorMessage;
                                        item.StatusItem = TableItem.StatusType.Sended;
                                    }


                                    item.ItemInProcess = false;

                                    _bService.UpdateImageData(item);
                                    Interlocked.Decrement(ref currentProcessDownload);
                                    ChangingRow?.Invoke(this, item);
                                }
                            });
                    }
                }
                if (currentProcessUnloading < countSetUploading)
                {
                    TableItem item = RowItem.FirstOrDefault(it => it.StatusItem == TableItem.StatusType.NotSent && !it.ItemInProcess);
                    if (item != null)
                    {
                        item.ItemInProcess = true;
                        Interlocked.Increment(ref currentProcessUnloading);

                        string selectedFile = item.FileName.FullName;
                        var worker = new Worker(Settings["keyAPI"], Settings["secret"], selectedFile, Parametrs);


                        var tasksUpload = new Task(worker.SendImage);
                        lock (Locker)
                        {
                            if (_isProgramClosing) return;
                            item.StatusItem = TableItem.StatusType.Sending;
                            _bService.UpdateImageData(item);
                        }
                        ChangingRow?.Invoke(this, item);
                        tasksUpload.Start();

                        tasksUpload.ContinueWith((t) =>
                            {
                                lock (Locker)
                                {
                                    if (_isProgramClosing) return;

                                    if (worker.KrakenURL != null)
                                    {
                                        item.KrakenURL = worker.KrakenURL;
                                        item.StatusItem = TableItem.StatusType.Sended;
                                    }
                                    else
                                    {
                                        item.Description = worker.ErrorMessage;
                                        item.StatusItem = TableItem.StatusType.NotSent;
                                    }

                                    item.ItemInProcess = false;
                                    _bService.UpdateImageData(item);
                                    Interlocked.Decrement(ref currentProcessUnloading);
                                    ChangingRow? .
                                    Invoke(this, item);
                                }
                            });
                    }
                }

                Thread.Sleep(5);
                Application.DoEvents();
                InitializationSettings();
            }
        }


        /// <summary>
        /// rewrite optimized file
        /// </summary>
        /// <param name="fileName"></param>
        private void RewriteFile(FileInfo fileName)
        {
            var backFile = new FileInfo(fileName.FullName + ".back");
            string originalFileName = fileName.FullName;

            try
            {
                fileName.Delete();
                backFile.MoveTo(originalFileName);
            }
            catch (Exception ex)
            {
                Messaging?.Invoke(this, "Can't overwrite optimized file!  " + ex.Message);
            }
        }

        public void InitializationSettings()
        {
            Settings = _bService.SettingsReader();
        }

        /// <summary>
        /// save settings
        /// </summary>
        /// <param name="settings"></param>
        public void SaveSettings(Dictionary<string, string> settings)
        {
            foreach (var item in settings)
            {
                Settings[item.Key] = item.Value;
                _bService.SetConfigurationSettings(item.Key, item.Value);
            }
            if (!_krakenIsStarting)
                Task.Run(() => GetStartedWithKraken());
        }


        /// <summary>
        ///  add new image files to table by draging
        /// </summary>
        /// <param name="filename"></param>
        public void AddNewByDraging(string filename)
        {
            if (!HaveThisFileName(filename))
            {
                var item = new TableItem(filename);
                var row = new List<TableItem>();
                item.KrakenURL = "";

                row.Add(item);
                RowItem.Add(item);
                _bService.SaveNewData(item);
                AddingRows?.Invoke(this, row);
            }
            else
            {
                Messaging?.Invoke(this, "One or more file(s) already in use. Remove first it(s) if need");
            }

            if (!_krakenIsStarting)
                Task.Run(() => GetStartedWithKraken());
        }

        private bool HaveThisFileName(string filename)
        {
            return RowItem.Any(item => item.FileName.FullName == filename);
        }
    }
}