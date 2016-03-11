using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace changeDataBasePwd
{
    public partial class Form1 : Form
    {
        private string folderName = string.Empty;
        private bool fileOpened = false;

        private string[] files;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("路径",823);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                if (!fileOpened)
                {
                    this.label3.Text = "选择目录：" + folderName;
                    fileOpened = true;
                }
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 查找web.config文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            files = null;
            if (string.IsNullOrEmpty(folderName))
            {
                MessageBox.Show("没有选择文件夹");
                button5.Enabled = true;
                return;
            }
            var _updateLabel = new del_updateLabel(updateLable);
            Thread t = new Thread(() =>
            {
                files = Directory.GetFiles(folderName, "Web.config", SearchOption.AllDirectories);
                this.BeginInvoke(_updateLabel, "搜索到：" + files.Length + "个");

            });
            t.Start();

        }

        private delegate void del_updateLabel(string txt);

        private void updateLable(string txt)
        {
            files.ToList().ForEach(x => 
            { 
                ListViewItem lvi = new ListViewItem(x);
                listView1.Items.Add(lvi);
            });
            
            
            
            this.label4.Text = txt;
            button5.Enabled = true;
        }
    }
}
