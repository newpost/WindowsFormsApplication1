namespace changeDataBasePwd
{
    partial class Main_Form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.btn_modifyConnStr = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_chooseFolder = new System.Windows.Forms.Button();
            this.btn_viewConfig = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_connName = new System.Windows.Forms.TextBox();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(195, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查看网站Web.Config中的密码";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_modifyConnStr
            // 
            this.btn_modifyConnStr.Location = new System.Drawing.Point(540, 363);
            this.btn_modifyConnStr.Name = "btn_modifyConnStr";
            this.btn_modifyConnStr.Size = new System.Drawing.Size(183, 23);
            this.btn_modifyConnStr.TabIndex = 2;
            this.btn_modifyConnStr.Text = "修改选中文件的数据库连接密码";
            this.btn_modifyConnStr.UseVisualStyleBackColor = true;
            this.btn_modifyConnStr.Click += new System.EventHandler(this.btn_modifyConnStr_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 4;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(161, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 16);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "全选";
            this.checkBox1.ThreeState = true;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(94, 526);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(750, 13);
            this.progressBar1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 526);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "执行进度";
            // 
            // btn_chooseFolder
            // 
            this.btn_chooseFolder.Location = new System.Drawing.Point(29, 11);
            this.btn_chooseFolder.Name = "btn_chooseFolder";
            this.btn_chooseFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_chooseFolder.TabIndex = 8;
            this.btn_chooseFolder.Text = "选择文件夹";
            this.btn_chooseFolder.UseVisualStyleBackColor = true;
            this.btn_chooseFolder.Click += new System.EventHandler(this.btn_chooseFolder_Click);
            // 
            // btn_viewConfig
            // 
            this.btn_viewConfig.Location = new System.Drawing.Point(31, 45);
            this.btn_viewConfig.Name = "btn_viewConfig";
            this.btn_viewConfig.Size = new System.Drawing.Size(104, 23);
            this.btn_viewConfig.TabIndex = 9;
            this.btn_viewConfig.Text = "查找web.config";
            this.btn_viewConfig.UseVisualStyleBackColor = true;
            this.btn_viewConfig.Click += new System.EventHandler(this.btn_viewConfig_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "选择要搜索的文件夹";
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(110, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "没有选择文件夹";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "搜索到：0个";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(29, 74);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(823, 243);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView1_ItemCheck);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.textBox1.Location = new System.Drawing.Point(29, 404);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(815, 99);
            this.textBox1.TabIndex = 12;
            this.textBox1.WordWrap = false;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 368);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "连接名";
            // 
            // tb_connName
            // 
            this.tb_connName.Location = new System.Drawing.Point(76, 365);
            this.tb_connName.Name = "tb_connName";
            this.tb_connName.Size = new System.Drawing.Size(100, 21);
            this.tb_connName.TabIndex = 14;
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(247, 365);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(100, 21);
            this.tb_userName.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(200, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "用户名";
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(411, 365);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(100, 21);
            this.tb_pwd.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "密码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(236, 328);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(371, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "谨慎操作:在选中的文件里面寻找相同的连接名修改相应的用户名密码";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 551);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_connName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_viewConfig);
            this.Controls.Add(this.btn_chooseFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_modifyConnStr);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main_Form";
            this.Text = "修改数据库连接程序";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_modifyConnStr;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_chooseFolder;
        private System.Windows.Forms.Button btn_viewConfig;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_connName;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

