using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeterTest
{
    public partial class SerialSettingsDialog : Form
    {
        public SerialSettingsDialog()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

        }

        private void SerialSettingsDialog_Load(object sender, EventArgs e)
        {
            this.cmbPortNumber.SelectedItem = "COM1";
            this.cmbBaud.SelectedItem = "9600";
            this.cmbDataBit.SelectedItem = "8";
            this.cmbCheckBit.SelectedItem = "NONE";
            this.cmbStopBit.SelectedItem = "1";
        }
    }
}
