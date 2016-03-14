using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace changeDataBasePwd
{
    public partial class Main_Form : Form
    {
        private string folderName = string.Empty;

        private string[] files;
        private string selectedFilePath = string.Empty;

        private List<string> checkedFilePaths = new List<string>();
        public Main_Form()
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
                        del_updateUI _showMessage = new del_updateUI(showMessage);
                        this.BeginInvoke(_showMessage, "webconfig文件中未发现连接字符串。");
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

                MessageBoxEx.Show(this, ex.ToString());
            }
        }

        private void showMessage(string txt)
        {
            MessageBoxEx.Show(this, txt);
        }

        private void updateTextBox(string txt)
        {
            this.textBox1.Text += txt+ Environment.NewLine;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("路径", 823);
        }

        private void btn_chooseFolder_Click(object sender, EventArgs e)
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
        private void btn_viewConfig_Click(object sender, EventArgs e)
        {
            btn_viewConfig.Enabled = false;
            checkedFilePaths.Clear();
            files = null;
            if (string.IsNullOrEmpty(folderName))
            {

                MessageBoxEx.Show(this, "没有选择文件夹");
                btn_viewConfig.Enabled = true;
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
            btn_viewConfig.Enabled = true;
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
                checkedFilePaths.Remove(this.listView1.Items[e.Index].SubItems[0].Text);//item check事件在导致checkbox全选按钮状态发生变化时,这个事件触发两次,因此每次之前先移除已经存在的项
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
        private void btn_modifyConnStr_Click(object sender, EventArgs e)
        {

            if (checkedFilePaths.Count == 0)
            {
                MessageBoxEx.Show(this, "请选择webconfig文件");
                return;
            }
            else if (tb_connName.Text.Trim() == "" || tb_userName.Text.Trim() == "" || tb_pwd.Text.Trim() == "")
            {
                MessageBoxEx.Show(this, "请填写数据库连接信息");
                return;
            }
            else if ((MessageBox.Show("是否要修改配置文件,此操作有风险,谨慎操作", "提示",
    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
    MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes))
            {
                btn_modifyConnStr.Enabled = false;
                Thread t = new Thread(() =>
                {
                    var i = 1;
                    foreach (var tempPath in checkedFilePaths)
                    {

                        File.Copy(tempPath, Path.Combine(Path.GetDirectoryName(tempPath), Path.GetFileNameWithoutExtension(tempPath) + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(tempPath)));

                        var res =  ModifyConnectStringInfo(tempPath, tb_connName.Text, tb_userName.Text, tb_pwd.Text);

                        del_ModifyConnStringUIRefresh del = new del_ModifyConnStringUIRefresh(ModifyConnStringUIRefresh);
                        this.BeginInvoke(del, tempPath, i++, checkedFilePaths.Count,res);

                    }
                });
                t.Start();
            }

        }

        private delegate void del_ModifyConnStringUIRefresh(string str, int current, int total, ModifyFlag res);
        private void ModifyConnStringUIRefresh(string str, int current, int total,ModifyFlag res)
        {           
            if(res == ModifyFlag.NoFoundConnStr)
            {
                textBox1.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + str + "没有找到修改的连接字符串"+Environment.NewLine;
            }
            else if (res == ModifyFlag.Exception)
            {
                textBox1.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + str + "修改发生异常" + Environment.NewLine;
            }
            else
            {
                textBox1.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + str + "修改成功" + Environment.NewLine;
            }
            if (current == total)
            {
                btn_modifyConnStr.Enabled = true;
                textBox1.Text += DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + "**************本次执行结束***********" + Environment.NewLine;
                MessageBoxEx.Show(this, "执行完成,请在文本框中查看具体日志");
            }
        }
        public enum ModifyFlag { NoFoundConnStr, Success, Exception };
        /// <summary>
        /// 修改连接字符串
        /// </summary>
        /// <param name="filePath"></param>
        private ModifyFlag ModifyConnectStringInfo(string filePath, string connName, string userName, string password)
        {
            ModifyFlag enum_result = ModifyFlag.NoFoundConnStr;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            var root = xmlDoc.DocumentElement;
            if (root["connectionStrings"] == null)
            {
                return enum_result = ModifyFlag.NoFoundConnStr;
            }
            foreach (XmlNode node in root["connectionStrings"].ChildNodes)
            {
                if (node.Attributes != null)
                {
                    if (connName == node.Attributes.GetNamedItem("name").Value)
                    {
                        var key = node.Attributes.GetNamedItem("name").Value;
                        var val = node.Attributes.GetNamedItem("connectionString").Value;

                        Regex regConn = new Regex("(data source=.*?;password=)(?:.*?)(;user id=)(?:.*?)(\")");
                        string replacement = "$1" + password + "$2" + userName + "$3";
                        node.Attributes.GetNamedItem("connectionString").Value = regConn.Replace(val, replacement);
                        xmlDoc.Save(filePath);
                        return enum_result = ModifyFlag.Success;
                    }
                    else
                    {
                        enum_result = ModifyFlag.NoFoundConnStr;
                    }
                }

            }
            return enum_result;
        }

        /// <summary>
        /// 全选(全部取消)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
