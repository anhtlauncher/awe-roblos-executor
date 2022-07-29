using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyExploits;
using FluxAPI;

namespace AWE
{
    public partial class mics : Form
    {
        EasyExploits.Module easyExploits = new EasyExploits.Module();
        FluxAPI.API API = new FluxAPI.API();
        public mics()
        {
            InitializeComponent();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            easyExploits.killRoblox();
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            API.SetFPSCap();
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            API.SetFPSCap(60);
        }
    }
}
