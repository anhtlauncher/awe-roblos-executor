using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;
namespace AWE
{
    public partial class AWEh : Form
    {
        KrnlApi krnlApi = new KrnlApi();
        public AWEh()
        {
            InitializeComponent();
            //dude i want to add krnl.Intialize();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            awem AWEh = new awem();
            AWEh.Show();
        }
    }
}
