using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ImageOptimizer
{
    public partial class Optimize : Form
    {
        private readonly Manager _manager;

        public Optimize()
        {
            InitializeComponent();
            buttonDeleteRow.Enabled = false;

            AllowDrop = true;
            DragEnter += Form1_DragEnter;
            DragDrop += Form1_DragDrop;

            _manager = new Manager();

            listBoxInfo.Items.Add("Hello. Let's starting!");

            _manager.AddingRows += AddRowsToGrid; // subscribe to add rows
            _manager.ChangingRow += ChangeRow; // subscribe to change sell context in rows
            _manager.Messaging += ShowMessage; // subscribe to messages from manager
            _manager.InitializationOldData(); // initializing past data
        }

        //change row context
        private void ChangeRow(object sender, TableItem e)
        {
            DataGridViewRow row = dataGridView1.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells[0].Value.ToString().Equals(e.FileName.FullName));
            if (row != null)
            {
                row.Cells[2].Value = e.SizeAfter.ToString(CultureInfo.InvariantCulture);
                row.Cells[3].Value = e.StatusItem.ToString();
                if (e.Description != null)
                {
                    row.Cells[4].Value = e.Description;
                }
            }
        }

        //add message to info listbox
        private void ShowMessage(object sender, string e)
        {
            Action action = () => listBoxInfo.Items.Add(e);
            Invoke(action);
        }

        //add rows to table
        private void AddRowsToGrid(object sender, List<TableItem> e)
        {
            foreach (TableItem element in e)
            {
                dataGridView1.Rows.Add(element.FileName, element.SizeBefore, element.SizeAfter, element.StatusItem, "");
            }
        }

        //drag image file
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
                bool isImageFile = false;
                foreach (string file in files)
                {
                    if (file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".gif") || file.ToLower().EndsWith(".jpeg") ||
                        file.ToLower().EndsWith(".png") || file.ToLower().EndsWith(".svg"))
                    {
                        isImageFile = true;
                    }
                }
                e.Effect = isImageFile ? DragDropEffects.Copy : DragDropEffects.None;
            }
        }

        //drop image file
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                _manager.AddNewByDraging(file);
            }
        }

        private void DataGridView1_Click(object sender, EventArgs e)
        {
            buttonDeleteRow.Enabled = true;
        }

        //delete row from table
        private void ButtonDeleteRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to delete this line?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (dataGridView1.RowCount > 0)
                {
                    int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                    string filePath = Convert.ToString(selectedRow.Cells[0].Value);


                    dataGridView1.Rows.RemoveAt(selectedrowindex);
                    _manager.DeleteRow(filePath);
                }
                buttonDeleteRow.Enabled = false;
            }
        }

        //set parameter 
        private void toolStripLabelParam_Click(object sender, EventArgs e)
        {
            var newForm = new Parameters {FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false};
            newForm.ShowDialog(this);
        }

        //close program
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want exit this program?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _manager.CloseOptimization();
                Close();
            }
        }

        //set settings for kraken.io (keys)
        private void toolStripLabelSettings_Click(object sender, EventArgs e)
        {
            var newForm = new Settings {FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false};
            newForm.ShowDialog(this);
        }
    }
}