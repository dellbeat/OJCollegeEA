namespace OJColleugeEA
{
    partial class PublicClassForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ClassList = new System.Windows.Forms.DataGridView();
            this.RowIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teacher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Init = new System.Windows.Forms.Button();
            this.SelectClass = new System.Windows.Forms.Button();
            this.Index = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LimitCount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ClassList)).BeginInit();
            this.SuspendLayout();
            // 
            // ClassList
            // 
            this.ClassList.AllowUserToAddRows = false;
            this.ClassList.AllowUserToDeleteRows = false;
            this.ClassList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClassList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowIndex,
            this.Name,
            this.Teacher,
            this.Count});
            this.ClassList.Location = new System.Drawing.Point(12, 12);
            this.ClassList.Name = "ClassList";
            this.ClassList.ReadOnly = true;
            this.ClassList.RowHeadersWidth = 20;
            this.ClassList.RowTemplate.Height = 23;
            this.ClassList.Size = new System.Drawing.Size(391, 150);
            this.ClassList.TabIndex = 0;
            // 
            // RowIndex
            // 
            this.RowIndex.HeaderText = "行数";
            this.RowIndex.Name = "RowIndex";
            this.RowIndex.ReadOnly = true;
            this.RowIndex.Width = 60;
            // 
            // Name
            // 
            this.Name.HeaderText = "课程名称";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Teacher
            // 
            this.Teacher.HeaderText = "教师";
            this.Teacher.Name = "Teacher";
            this.Teacher.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.HeaderText = "剩余课数";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // Init
            // 
            this.Init.Location = new System.Drawing.Point(12, 168);
            this.Init.Name = "Init";
            this.Init.Size = new System.Drawing.Size(75, 23);
            this.Init.TabIndex = 1;
            this.Init.Text = "加载列表";
            this.Init.UseVisualStyleBackColor = true;
            this.Init.Click += new System.EventHandler(this.Init_Click);
            // 
            // SelectClass
            // 
            this.SelectClass.Location = new System.Drawing.Point(328, 170);
            this.SelectClass.Name = "SelectClass";
            this.SelectClass.Size = new System.Drawing.Size(75, 23);
            this.SelectClass.TabIndex = 2;
            this.SelectClass.Text = "开始抢课";
            this.SelectClass.UseVisualStyleBackColor = true;
            this.SelectClass.Click += new System.EventHandler(this.SelectClass_Click);
            // 
            // Index
            // 
            this.Index.Location = new System.Drawing.Point(200, 170);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(100, 21);
            this.Index.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(104, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "抢课序号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(104, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "尝试次数：";
            this.label2.Visible = false;
            // 
            // LimitCount
            // 
            this.LimitCount.Location = new System.Drawing.Point(200, 201);
            this.LimitCount.Name = "LimitCount";
            this.LimitCount.Size = new System.Drawing.Size(100, 21);
            this.LimitCount.TabIndex = 5;
            this.LimitCount.Visible = false;
            // 
            // PublicClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 242);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LimitCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Index);
            this.Controls.Add(this.SelectClass);
            this.Controls.Add(this.Init);
            this.Controls.Add(this.ClassList);
            //this.Name = "PublicClassForm";
            this.Text = "公选课抢课窗口";
            ((System.ComponentModel.ISupportInitialize)(this.ClassList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ClassList;
        private System.Windows.Forms.Button Init;
        private System.Windows.Forms.Button SelectClass;
        private System.Windows.Forms.TextBox Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teacher;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LimitCount;
    }
}