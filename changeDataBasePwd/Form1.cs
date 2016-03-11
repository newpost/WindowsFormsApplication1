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
using System.Xml;
namespace changeDataBasePwd
{
    public partial class Form1 : Form
    {
        private string folderName = string.Empty;

        private string[] files;
        private string selectedFilePath = string.Empty;

        private List<string> checkedFilePaths = new List<string>();
        public Form1()
        {
            
            InitializeComponent();
            
        }

        /// <summary>
        /// 查看webconfig的字符串连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBoxEx.Show(this, "请选择webconfig文件");
                    return;
                }
                this.textBox1.Text = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(selectedFilePath);
                
                var del_updateTextBox = new del_updateUI(updateTextBox);
                Thread t = new Thread(() =>
                {
                    var connectString = doc.SelectSingleNode("/configuration/connectionStrings");
                    if (connectString == null)
                    {
                        MessageBoxEx.Show(this, "webconfig文件中未发现连接字符串。");
                    }
                    else
                    {
                        string str = connectString.OuterXml;
                        this.BeginInvoke(del_updateTextBox, str);
                    }
                });
                t.Start();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void updateTextBox(string txt)
        {
            this.textBox1.Text = txt;
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

                this.label3.Text = "选择目录：" + folderName;

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

                MessageBoxEx.Show(this,"没有选择文件夹");
                button5.Enabled = true;
                return;
            }
            var _updateLabel = new del_updateUI(updateGrid_Label);
            Thread t = new Thread(() =>
            {
                files = Directory.GetFiles(folderName, "Web.config", SearchOption.AllDirectories);
                this.BeginInvoke(_updateLabel, "搜索到：" + files.Length + "个");

            });
            t.Start();

        }

        private delegate void del_updateUI(string txt);

        private void updateGrid_Label(string txt)
        {
            listView1.Items.Clear();
            files.ToList().ForEach(x => 
            {
                
                ListViewItem lvi = new ListViewItem(x);
                listView1.Items.Add(lvi);
            });
            
            
            
            this.label4.Text = txt;
            button5.Enabled = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                selectedFilePath = item.SubItems[0].Text;
            }
            else
            {
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var totalItemCount = listView1.Items.Count;
            var checkedItemsCount = listView1.Items.OfType<ListViewItem>().Where(x => x.Checked == true).Count();

            if (e.CurrentValue == CheckState.Unchecked)
            {
                checkedFilePaths.Add(this.listView1.Items[e.Index].SubItems[0].Text);
                checkedItemsCount++;
            }
            else if ((e.CurrentValue == CheckState.Checked))
            {
                checkedFilePaths.Remove(this.listView1.Items[e.Index].SubItems[0].Text);
                checkedItemsCount--;
                
            }
            
            if (checkedItemsCount == 0)
            {
                checkBox1.CheckState = CheckState.Unchecked;
            }
            else if (totalItemCount == checkedItemsCount)
            {
                checkBox1.CheckState = CheckState.Checked;
            }
            else
            {
                checkBox1.CheckState = CheckState.Indeterminate;
            }
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 修改webconfig
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb.CheckState == CheckState.Checked)
            {

                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    item.Checked = false;
                }
            }
        }

    }
}
