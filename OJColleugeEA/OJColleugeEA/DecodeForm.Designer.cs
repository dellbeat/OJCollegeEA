namespace OJColleugeEA
{
    partial class DecodeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecodeForm));
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.VieFile = new System.Windows.Forms.Button();
            this.DeCT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码：";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(71, 19);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(132, 21);
            this.password.TabIndex = 1;
            // 
            // VieFile
            // 
            this.VieFile.Location = new System.Drawing.Point(24, 66);
            this.VieFile.Name = "VieFile";
            this.VieFile.Size = new System.Drawing.Size(75, 23);
            this.VieFile.TabIndex = 2;
            this.VieFile.Text = "文件浏览";
            this.VieFile.UseVisualStyleBackColor = true;
            this.VieFile.Click += new System.EventHandler(this.VieFile_Click);
            // 
            // DeCT
            // 
            this.DeCT.Location = new System.Drawing.Point(128, 66);
            this.DeCT.Name = "DeCT";
            this.DeCT.Size = new System.Drawing.Size(75, 23);
            this.DeCT.TabIndex = 3;
            this.DeCT.Text = "读取";
            this.DeCT.UseVisualStyleBackColor = true;
            this.DeCT.Click += new System.EventHandler(this.DeCT_Click);
            // 
            // DecodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(233, 113);
            this.Controls.Add(this.DeCT);
            this.Controls.Add(this.VieFile);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DecodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "读取课程表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button VieFile;
        private System.Windows.Forms.Button DeCT;
    }
}