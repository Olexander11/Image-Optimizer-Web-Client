using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageOptimizer
{
    public partial class Settings : Form
    {
        private readonly Manager _managerSet;

        private readonly Dictionary<string, string> _oldsettings;
        private readonly Dictionary<string, string> _settingsChanges;

        public Settings()
        {
            InitializeComponent();
            _managerSet = new Manager();

            _managerSet.InitializationSettings();
            _oldsettings = _managerSet.Settings;
            _settingsChanges = new Dictionary<string, string>();
            textBoxKey.Text = _oldsettings["keyAPI"];
            textBoxSecret.Text = _oldsettings["secret"];
            nThreads.Value = Decimal.Parse(_oldsettings["Threads"]);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool saveChanges = _oldsettings.ContainsKey("Threads") && nThreads.Value != Decimal.Parse(_oldsettings["Threads"]) ||
                               _oldsettings.ContainsKey("keyAPI") && textBoxKey.Text != _oldsettings["keyAPI"] ||
                               _oldsettings.ContainsKey("secret") && textBoxSecret.Text != _oldsettings["secret"];

            if (saveChanges)
            {
                _settingsChanges["Threads"] = "" + (int) nThreads.Value;
                _settingsChanges["keyAPI"] = textBoxKey.Text;
                _settingsChanges["secret"] = textBoxSecret.Text;
                _managerSet.SaveSettings(_settingsChanges);
            }

            DialogResult = DialogResult.OK;
        }

        private void labelSetThreads_Click(object sender, EventArgs e)
        {

        }
    }
}