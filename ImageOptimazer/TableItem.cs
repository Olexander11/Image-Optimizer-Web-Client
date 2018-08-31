using System;
using System.IO;

namespace ImageOptimizer
{
    internal class TableItem
    {
        public enum StatusType : short
        {
            NotSent = 1,
            Sending,
            Sended,
            Downloaded,
            Downloading,
            Unspecified,
            AlreadyUsed
        }

        public TableItem()
        {
            StatusItem = StatusType.Unspecified;
            SizeBefore = SizeAfter = 0;
            ItemInProcess = false;
            DateTimeItem = DateTime.Now;
            KrakenURL = "";
        }

        public TableItem(string file)
        {
            FileName = new FileInfo(file);
            StatusItem = StatusType.NotSent;
            SizeBefore = (uint) FileName.Length;
            SizeAfter = 0;
            ItemInProcess = false;
            DateTimeItem = DateTime.Now;
            KrakenURL = "";
        }

        public uint Id { get; set; }
        public FileInfo FileName { get; set; }
        public uint SizeBefore { get; set; }
        public uint SizeAfter { get; set; }
        public StatusType StatusItem { get; set; }

        public bool ItemInProcess { get; set; }
        public DateTime DateTimeItem { get; set; }
        public string KrakenURL { get; set; }
        public string Description { get; set; }
    }
}