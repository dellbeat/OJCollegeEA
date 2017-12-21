﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJColleugeEA
{
    public partial class CommentForm : Form
    {
        CommentTools Tool = null;
        public CommentForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Tool = new CommentTools();
            int index = 0;
            CommentList.Rows.Clear();
            for (int i = 0; i < Tool.IsComment.Count; i++)
            {
                index = CommentList.Rows.Add();
                CommentList.Rows[i].Cells[0].Value = Tool.NameStr[i];
                CommentList.Rows[i].Cells[1].Value = Tool.IsComment[i] == true ? "已评价" : "未评价";
            }
        }

        private void GetInfo_Click(object sender, EventArgs e)
        {
            Init();
        }

        private async void CommentIt_Click(object sender, EventArgs e)
        {
            await SumbmitTask();
        }

        private Task SumbmitTask()
        {
            return Task.Run(() =>
                {
                    Tool.Submit();
                });
        }
    }
}