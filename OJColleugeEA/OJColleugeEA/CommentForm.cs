using System;
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
            if (Tool.IsComment.Count == 0)
            {
                //this.Close();
            }
            int index = 0;
            CommentList.Rows.Clear();
            for (int i = 0; i < Tool.IsComment.Count; i++)
            {
                index = CommentList.Rows.Add();
                CommentList.Rows[i].Cells[0].Value = Tool.NameStr[i];
                CommentList.Rows[i].Cells[1].Value = Tool.IsComment[i] == true ? "已评价" : "未评价";
            }
        }

        private async void GetInfo_Click(object sender, EventArgs e)
        {
            Status.Text = "正在获取信息中，请耐心等待~";
            await InitTask();
            Status.Text = "信息获取完成~";
        }

        private Task InitTask()
        {
            return Task.Run(() =>
                {
                    Init();
                });
        }

        private async void CommentIt_Click(object sender, EventArgs e)
        {
            if(CommentList.Rows.Count==0)
            {
                MessageBox.Show("没有可以评价的课程，请刷新信息后再试！","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }


            Status.Text = "正在评价中，请耐心等待~";
            await CommentTask();
            Status.Text = "";
            MessageBox.Show("评价完成，请刷新查看结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private Task SumbmitTask()
        {
            return Task.Run(() =>
                {
                    Tool.Submit();
                });
        }

        private Task CommentTask()
        {
            return Task.Run(() =>
                {
                    Tool.CommentClass();
                });
        }

        private async void Submit_Click(object sender, EventArgs e)
        {
            if (Tool.IsComment.Count == 0)
            {
                MessageBox.Show("评价结果已经提交，请勿重复提交！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Status.Text = "正在提交评价中，请耐心等待~";
            await SumbmitTask();
            Status.Text = "";
            MessageBox.Show("提交完成，请刷新查看结果！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
