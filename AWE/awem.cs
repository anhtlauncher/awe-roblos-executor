using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;
using EasyExploits;
using FluxAPI;
using WeAreDevs_API;

namespace AWE
{
    public partial class awem : Form
    {
        EasyExploits.Module easyExploits = new EasyExploits.Module();
        FluxAPI.API API = new FluxAPI.API();
        KrnlApi krnlApi = new KrnlApi();
        ExploitAPI exploitAPI = new ExploitAPI();

        public awem()
        {
            InitializeComponent();

        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void siticoneImageButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(executortext.Text);
                }
            }
        }

        private void siticoneImageButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                executortext.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void AddTabButton_Click(object sender, EventArgs e)
        {
            TabPage newTab = new TabPage();
            FastColoredTextBoxNS.FastColoredTextBox textBox = new FastColoredTextBoxNS.FastColoredTextBox();
            newTab.Name = "Script" + (visualStudioTabControl1.TabCount + 1);
            newTab.Text = "New Tab  ";
            newTab.Parent = visualStudioTabControl1;
            textBox.Dock = DockStyle.Fill;
            textBox.Name = "executortext";
            textBox.Parent = newTab;
            visualStudioTabControl1.SelectTab(newTab);
            AddTabButton.Left = AddTabButton.Left + 75;
            RemoveTabButton.Left = RemoveTabButton.Left + 77;
            if (visualStudioTabControl1.TabCount == 7)
            {
                AddTabButton.Hide();
            }
            if (visualStudioTabControl1.TabCount > 1)
            {
                RemoveTabButton.Show();
            }
        }

        private void RemoveTabButton_Click(object sender, EventArgs e)
        {
            if (visualStudioTabControl1.TabCount > 1)
            {
                Control tabPageToRemove = visualStudioTabControl1.Controls["Script" + (visualStudioTabControl1.TabCount)];
                visualStudioTabControl1.SelectTab("Script" + (visualStudioTabControl1.TabCount - 1));
                visualStudioTabControl1.Controls.Remove(tabPageToRemove);
                AddTabButton.Left = AddTabButton.Left - 75;
                RemoveTabButton.Left = RemoveTabButton.Left - 77;
                if (visualStudioTabControl1.TabCount == 7)
                {
                    AddTabButton.Hide();
                }
                else
                {
                    AddTabButton.Show();
                }
                if (visualStudioTabControl1.TabCount == 1)
                {
                    RemoveTabButton.Hide();
                }
            }
        }

        private void siticoneImageButton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (visualStudioTabControl1.TabPages.Count > 0)
                {
                    FastColoredTextBoxNS.FastColoredTextBox textBox = this.visualStudioTabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true).FirstOrDefault<Control>() as FastColoredTextBoxNS.FastColoredTextBox;
                    executortext.Clear();
                }
            }
            catch { }
        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            mics mics = new mics();
            mics.Show();
        }

        private void siticoneImageButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (visualStudioTabControl1.TabPages.Count > 0 && EasyExploitsRadio.Checked == true)
                {
                    FastColoredTextBoxNS.FastColoredTextBox textBox = this.visualStudioTabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true).FirstOrDefault<Control>() as FastColoredTextBoxNS.FastColoredTextBox;
                    easyExploits.ExecuteScript(executortext.Text);
                }
                else if (visualStudioTabControl1.TabPages.Count > 0 && KrnlRadiobutton.Checked == true)
                {
                    FastColoredTextBoxNS.FastColoredTextBox textBox = this.visualStudioTabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true).FirstOrDefault<Control>() as FastColoredTextBoxNS.FastColoredTextBox;
                    krnlApi.Execute(executortext.Text);
                }
                else if (visualStudioTabControl1.TabPages.Count > 0 && Wrdradiobutton.Checked == true)
                {
                    FastColoredTextBoxNS.FastColoredTextBox textBox = this.visualStudioTabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true).FirstOrDefault<Control>() as FastColoredTextBoxNS.FastColoredTextBox;
                    exploitAPI.SendLuaScript(executortext.Text);
                }
                //fluxus
                {
                    FastColoredTextBoxNS.FastColoredTextBox textBox = this.visualStudioTabControl1.SelectedTab.Controls.Find("fastColoredTextBox1", true).FirstOrDefault<Control>() as FastColoredTextBoxNS.FastColoredTextBox;
                    API.Execute(executortext.Text);
                }
            }
            catch { }
        }

        private void siticoneImageButton5_Click(object sender, EventArgs e)
        {
            if (EasyExploitsRadio.Checked == true)
            {
                easyExploits.LaunchExploit();//ez exploit
            }

            else if (KrnlRadiobutton.Checked == true)
            {
                
                krnlApi.Inject();//krnl
            }
            else if (Wrdradiobutton.Checked == true)
            {
                exploitAPI.LaunchExploit();//wrd
            }
            //fluxus


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();//clear items in the script list
            Functions.PopulateListBox(listBox1, "./Scripts", "*.txt");
            Functions.PopulateListBox(listBox1, "./Scripts", "*.lua");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            executortext.Text = File.ReadAllText($"./Scripts/{listBox1.SelectedItem}"); // lists scripts in a folder called scripts in your current dir.
        }
    }
}
