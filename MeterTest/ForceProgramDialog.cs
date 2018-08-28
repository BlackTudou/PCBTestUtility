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
    public partial class ForceProgramDialog : Form
    {
        public ForceProgramDialog()
        {
            InitializeComponent();
        }

        private void ForceProgramForm_Load(object sender, EventArgs e)
        {
            this.cmbChip.SelectedIndex = 2;
        }
    }
}
