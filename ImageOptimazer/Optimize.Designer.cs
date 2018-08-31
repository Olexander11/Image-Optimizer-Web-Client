namespace ImageOptimizer
{
    partial class Optimize
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeBeforeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SizeAfterCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelSettings = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabelParam = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileNameColumn,
            this.SizeBeforeCol,
            this.SizeAfterCol,
            this.StatusCol,
            this.Description});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(27, 63);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(592, 276);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.DataGridView1_Click);
            // 
            // FileNameColumn
            // 
            this.FileNameColumn.HeaderText = "File Name";
            this.FileNameColumn.Name = "FileNameColumn";
            this.FileNameColumn.Width = 150;
            // 
            // SizeBeforeCol
            // 
            this.SizeBeforeCol.HeaderText = "Size before";
            this.SizeBeforeCol.Name = "SizeBeforeCol";
            // 
            // SizeAfterCol
            // 
            this.SizeAfterCol.HeaderText = "Size after";
            this.SizeAfterCol.Name = "SizeAfterCol";
            // 
            // StatusCol
            // 
            this.StatusCol.HeaderText = "Status";
            this.StatusCol.Name = "StatusCol";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelSettings,
            this.toolStripLabelParam,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(655, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelSettings
            // 
            this.toolStripLabelSettings.Name = "toolStripLabelSettings";
            this.toolStripLabelSettings.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabelSettings.Text = "Settings";
            this.toolStripLabelSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripLabelSettings.Click += new System.EventHandler(this.toolStripLabelSettings_Click);
            // 
            // toolStripLabelParam
            // 
            this.toolStripLabelParam.Name = "toolStripLabelParam";
            this.toolStripLabelParam.Size = new System.Drawing.Size(66, 22);
            this.toolStripLabelParam.Text = "Parameters";
            this.toolStripLabelParam.Click += new System.EventHandler(this.toolStripLabelParam_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(36, 22);
            this.toolStripLabel1.Text = "Close";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteRow.Location = new System.Drawing.Point(522, 377);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRow.TabIndex = 3;
            this.buttonDeleteRow.Text = "Delete row";
            this.buttonDeleteRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.ButtonDeleteRow_Click);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.Location = new System.Drawing.Point(27, 360);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(464, 82);
            this.listBoxInfo.TabIndex = 4;
            // 
            // Optimize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 494);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.buttonDeleteRow);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Optimize";
            this.Text = "Optimizer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelSettings;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeBeforeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SizeAfterCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.ToolStripLabel toolStripLabelParam;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ListBox listBoxInfo;
    }
}

