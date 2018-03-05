namespace OJColleugeEA
{
    partial class CommentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentForm));
            this.CommentList = new System.Windows.Forms.DataGridView();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GetInfo = new System.Windows.Forms.Button();
            this.CommentIt = new System.Windows.Forms.Button();
            this.Submit = new System.Windows.Forms.Button();
            this.Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CommentList)).BeginInit();
            this.SuspendLayout();
            // 
            // CommentList
            // 
            this.CommentList.AllowUserToAddRows = false;
            this.CommentList.AllowUserToDeleteRows = false;
            this.CommentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CommentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassName,
            this.IsComment});
            this.CommentList.Location = new System.Drawing.Point(13, 13);
            this.CommentList.Name = "CommentList";
            this.CommentList.ReadOnly = true;
            this.CommentList.RowTemplate.Height = 23;
            this.CommentList.Size = new System.Drawing.Size(404, 150);
            this.CommentList.TabIndex = 0;
            // 
            // ClassName
            // 
            this.ClassName.HeaderText = "课程名称";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 260;
            // 
            // IsComment
            // 
            this.IsComment.HeaderText = "是否已评价";
            this.IsComment.Name = "IsComment";
            this.IsComment.ReadOnly = true;
            this.IsComment.Width = 95;
            // 
            // GetInfo
            // 
            this.GetInfo.Location = new System.Drawing.Point(48, 183);
            this.GetInfo.Name = "GetInfo";
            this.GetInfo.Size = new System.Drawing.Size(75, 23);
            this.GetInfo.TabIndex = 1;
            this.GetInfo.Text = "获取信息";
            this.GetInfo.UseVisualStyleBackColor = true;
            this.GetInfo.Click += new System.EventHandler(this.GetInfo_Click);
            // 
            // CommentIt
            // 
            this.CommentIt.Location = new System.Drawing.Point(171, 183);
            this.CommentIt.Name = "CommentIt";
            this.CommentIt.Size = new System.Drawing.Size(75, 23);
            this.CommentIt.TabIndex = 2;
            this.CommentIt.Text = "一键评教";
            this.CommentIt.UseVisualStyleBackColor = true;
            this.CommentIt.Click += new System.EventHandler(this.CommentIt_Click);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(294, 183);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(75, 23);
            this.Submit.TabIndex = 3;
            this.Submit.Text = "提交结果";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(13, 280);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(0, 12);
            this.Status.TabIndex = 4;
            // 
            // CommentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(428, 304);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.CommentIt);
            this.Controls.Add(this.GetInfo);
            this.Controls.Add(this.CommentList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CommentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "一键评教窗口";
            ((System.ComponentModel.ISupportInitialize)(this.CommentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CommentList;
        private System.Windows.Forms.Button GetInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsComment;
        private System.Windows.Forms.Button CommentIt;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label Status;
    }
}