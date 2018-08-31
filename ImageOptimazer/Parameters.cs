using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageOptimizer
{
    public partial class Parameters : Form
    {
        private readonly Manager _managerParam;

        private readonly Dictionary<string, string> _paramChanges;
        private bool _hadChanges;

        public Parameters()
        {
            InitializeComponent();
            _paramChanges = new Dictionary<string, string>();
            _managerParam = new Manager();
        }

        private void checkBoxLoosy_Click(object sender, EventArgs e)
        {
            _hadChanges = true;
            _paramChanges.Add("Lossy", checkBoxLoosy.Checked.ToString());
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (_hadChanges)
            {
                _managerParam.Parametrs = _paramChanges;
            }
            DialogResult = DialogResult.OK;
        }
    }
}