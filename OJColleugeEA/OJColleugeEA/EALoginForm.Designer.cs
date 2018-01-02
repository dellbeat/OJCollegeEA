namespace OJColleugeEA
{
    partial class EALoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EALoginForm));
            this.CodeView = new System.Windows.Forms.PictureBox();
            this.LoginIn = new System.Windows.Forms.Button();
            this.LoginGroup = new System.Windows.Forms.GroupBox();
            this.LogOut = new System.Windows.Forms.Button();
            this.ReInput = new System.Windows.Forms.Button();
            this.SecertCode = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.QueryGroup = new System.Windows.Forms.GroupBox();
            this.QueryClassTable = new System.Windows.Forms.Button();
            this.TermIndex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TermYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.GradeBox = new System.Windows.Forms.GroupBox();
            this.QueryGrade = new System.Windows.Forms.Button();
            this.TermOfGrade = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.YearOfGrade = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CTSave = new System.Windows.Forms.Button();
            this.ReadCT = new System.Windows.Forms.Button();
            this.OneKeyComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CodeView)).BeginInit();
            this.LoginGroup.SuspendLayout();
            this.QueryGroup.SuspendLayout();
            this.GradeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeView
            // 
            this.CodeView.Location = new System.Drawing.Point(99, 111);
            this.CodeView.Name = "CodeView";
            this.CodeView.Size = new System.Drawing.Size(72, 27);
            this.CodeView.TabIndex = 0;
            this.CodeView.TabStop = false;
            this.CodeView.Click += new System.EventHandler(this.CodeView_Click);
            // 
            // LoginIn
            // 
            this.LoginIn.Location = new System.Drawing.Point(6, 150);
            this.LoginIn.Name = "LoginIn";
            this.LoginIn.Size = new System.Drawing.Size(75, 23);
            this.LoginIn.TabIndex = 3;
            this.LoginIn.Text = "登陆";
            this.LoginIn.UseVisualStyleBackColor = true;
            this.LoginIn.Click += new System.EventHandler(this.LoginIn_Click);
            // 
            // LoginGroup
            // 
            this.LoginGroup.Controls.Add(this.LogOut);
            this.LoginGroup.Controls.Add(this.ReInput);
            this.LoginGroup.Controls.Add(this.SecertCode);
            this.LoginGroup.Controls.Add(this.Password);
            this.LoginGroup.Controls.Add(this.label2);
            this.LoginGroup.Controls.Add(this.Account);
            this.LoginGroup.Controls.Add(this.LoginIn);
            this.LoginGroup.Controls.Add(this.label1);
            this.LoginGroup.Controls.Add(this.CodeView);
            this.LoginGroup.Controls.Add(this.label3);
            this.LoginGroup.Location = new System.Drawing.Point(12, 12);
            this.LoginGroup.Name = "LoginGroup";
            this.LoginGroup.Size = new System.Drawing.Size(181, 189);
            this.LoginGroup.TabIndex = 5;
            this.LoginGroup.TabStop = false;
            this.LoginGroup.Text = "登陆区";
            // 
            // LogOut
            // 
            this.LogOut.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogOut.Location = new System.Drawing.Point(36, 55);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(114, 50);
            this.LogOut.TabIndex = 8;
            this.LogOut.Text = "退出登录";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Visible = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ReInput
            // 
            this.ReInput.Location = new System.Drawing.Point(96, 150);
            this.ReInput.Name = "ReInput";
            this.ReInput.Size = new System.Drawing.Size(75, 23);
            this.ReInput.TabIndex = 4;
            this.ReInput.Text = "重填";
            this.ReInput.UseVisualStyleBackColor = true;
            this.ReInput.Click += new System.EventHandler(this.ReInput_Click);
            // 
            // SecertCode
            // 
            this.SecertCode.Location = new System.Drawing.Point(71, 84);
            this.SecertCode.Name = "SecertCode";
            this.SecertCode.Size = new System.Drawing.Size(100, 21);
            this.SecertCode.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(71, 49);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(100, 21);
            this.Password.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码：";
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(71, 17);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(100, 21);
            this.Account.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "帐号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(3, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "验证码：";
            // 
            // QueryGroup
            // 
            this.QueryGroup.Controls.Add(this.QueryClassTable);
            this.QueryGroup.Controls.Add(this.TermIndex);
            this.QueryGroup.Controls.Add(this.label5);
            this.QueryGroup.Controls.Add(this.TermYear);
            this.QueryGroup.Controls.Add(this.label4);
            this.QueryGroup.Enabled = false;
            this.QueryGroup.Location = new System.Drawing.Point(263, 12);
            this.QueryGroup.Name = "QueryGroup";
            this.QueryGroup.Size = new System.Drawing.Size(184, 153);
            this.QueryGroup.TabIndex = 6;
            this.QueryGroup.TabStop = false;
            this.QueryGroup.Text = "课表查询区";
            // 
            // QueryClassTable
            // 
            this.QueryClassTable.Location = new System.Drawing.Point(58, 106);
            this.QueryClassTable.Name = "QueryClassTable";
            this.QueryClassTable.Size = new System.Drawing.Size(75, 23);
            this.QueryClassTable.TabIndex = 9;
            this.QueryClassTable.Text = "查询";
            this.QueryClassTable.UseVisualStyleBackColor = true;
            this.QueryClassTable.Click += new System.EventHandler(this.QueryClassTable_Click);
            // 
            // TermIndex
            // 
            this.TermIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TermIndex.FormattingEnabled = true;
            this.TermIndex.Items.AddRange(new object[] {
            "第一学期",
            "第二学期"});
            this.TermIndex.Location = new System.Drawing.Point(68, 58);
            this.TermIndex.Name = "TermIndex";
            this.TermIndex.Size = new System.Drawing.Size(106, 20);
            this.TermIndex.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "学期：";
            // 
            // TermYear
            // 
            this.TermYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TermYear.FormattingEnabled = true;
            this.TermYear.Location = new System.Drawing.Point(68, 18);
            this.TermYear.Name = "TermYear";
            this.TermYear.Size = new System.Drawing.Size(106, 20);
            this.TermYear.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "学年：";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 7;
            // 
            // GradeBox
            // 
            this.GradeBox.Controls.Add(this.QueryGrade);
            this.GradeBox.Controls.Add(this.TermOfGrade);
            this.GradeBox.Controls.Add(this.label7);
            this.GradeBox.Controls.Add(this.YearOfGrade);
            this.GradeBox.Controls.Add(this.label8);
            this.GradeBox.Enabled = false;
            this.GradeBox.Location = new System.Drawing.Point(263, 171);
            this.GradeBox.Name = "GradeBox";
            this.GradeBox.Size = new System.Drawing.Size(184, 153);
            this.GradeBox.TabIndex = 10;
            this.GradeBox.TabStop = false;
            this.GradeBox.Text = "成绩查询区";
            // 
            // QueryGrade
            // 
            this.QueryGrade.Location = new System.Drawing.Point(58, 106);
            this.QueryGrade.Name = "QueryGrade";
            this.QueryGrade.Size = new System.Drawing.Size(75, 23);
            this.QueryGrade.TabIndex = 9;
            this.QueryGrade.Text = "查询";
            this.QueryGrade.UseVisualStyleBackColor = true;
            this.QueryGrade.Click += new System.EventHandler(this.QueryGrade_Click);
            // 
            // TermOfGrade
            // 
            this.TermOfGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TermOfGrade.FormattingEnabled = true;
            this.TermOfGrade.Items.AddRange(new object[] {
            "第一学期",
            "第二学期"});
            this.TermOfGrade.Location = new System.Drawing.Point(68, 58);
            this.TermOfGrade.Name = "TermOfGrade";
            this.TermOfGrade.Size = new System.Drawing.Size(106, 20);
            this.TermOfGrade.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "学期：";
            // 
            // YearOfGrade
            // 
            this.YearOfGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.YearOfGrade.FormattingEnabled = true;
            this.YearOfGrade.Location = new System.Drawing.Point(68, 18);
            this.YearOfGrade.Name = "YearOfGrade";
            this.YearOfGrade.Size = new System.Drawing.Size(106, 20);
            this.YearOfGrade.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 21);
            this.label8.TabIndex = 5;
            this.label8.Text = "学年：";
            // 
            // CTSave
            // 
            this.CTSave.Enabled = false;
            this.CTSave.Location = new System.Drawing.Point(18, 207);
            this.CTSave.Name = "CTSave";
            this.CTSave.Size = new System.Drawing.Size(75, 23);
            this.CTSave.TabIndex = 11;
            this.CTSave.Text = "保存课表";
            this.CTSave.UseVisualStyleBackColor = true;
            this.CTSave.Click += new System.EventHandler(this.CTSave_Click);
            // 
            // ReadCT
            // 
            this.ReadCT.Location = new System.Drawing.Point(108, 207);
            this.ReadCT.Name = "ReadCT";
            this.ReadCT.Size = new System.Drawing.Size(75, 23);
            this.ReadCT.TabIndex = 12;
            this.ReadCT.Text = "读取课表";
            this.ReadCT.UseVisualStyleBackColor = true;
            this.ReadCT.Click += new System.EventHandler(this.ReadCT_Click);
            // 
            // OneKeyComment
            // 
            this.OneKeyComment.Enabled = false;
            this.OneKeyComment.Location = new System.Drawing.Point(108, 251);
            this.OneKeyComment.Name = "OneKeyComment";
            this.OneKeyComment.Size = new System.Drawing.Size(75, 23);
            this.OneKeyComment.TabIndex = 13;
            this.OneKeyComment.Text = "一键评教";
            this.OneKeyComment.UseVisualStyleBackColor = true;
            this.OneKeyComment.Click += new System.EventHandler(this.OneKeyComment_Click);
            // 
            // EALoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(459, 333);
            this.Controls.Add(this.OneKeyComment);
            this.Controls.Add(this.ReadCT);
            this.Controls.Add(this.CTSave);
            this.Controls.Add(this.GradeBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.QueryGroup);
            this.Controls.Add(this.LoginGroup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EALoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "教务系统课程查询工具（By Dellbeat）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EALoginForm_FormClosing);
            this.Load += new System.EventHandler(this.EALoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CodeView)).EndInit();
            this.LoginGroup.ResumeLayout(false);
            this.LoginGroup.PerformLayout();
            this.QueryGroup.ResumeLayout(false);
            this.QueryGroup.PerformLayout();
            this.GradeBox.ResumeLayout(false);
            this.GradeBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CodeView;
        private System.Windows.Forms.Button LoginIn;
        private System.Windows.Forms.GroupBox LoginGroup;
        private System.Windows.Forms.TextBox Account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SecertCode;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ReInput;
        private System.Windows.Forms.GroupBox QueryGroup;
        private System.Windows.Forms.Button QueryClassTable;
        private System.Windows.Forms.ComboBox TermIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TermYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.GroupBox GradeBox;
        private System.Windows.Forms.Button QueryGrade;
        private System.Windows.Forms.ComboBox TermOfGrade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox YearOfGrade;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button CTSave;
        private System.Windows.Forms.Button ReadCT;
        private System.Windows.Forms.Button OneKeyComment;
    }
}

