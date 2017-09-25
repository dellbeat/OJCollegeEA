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
    public partial class ClassTableForm : Form
    {
        public ClassTableForm()
        {
            InitializeComponent();
            InitForm();
            
        }

        string[] date = { "一", "二", "三", "四", "五", "六", "日" };
        string[,] ClassTable = new string[12, 7];
        List<LoginInfo.ClassNode> ClassList = new List<LoginInfo.ClassNode>();
        string Year = "";
        string Term = "";

        private void InitData()
        {
            Year = LoginInfo.SelectedYear;
            Term = LoginInfo.SelectedTerm;

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    ClassTable[i, j] = LoginInfo.ClassTable[i, j];
                }
            }

            for (int i = 0; i < LoginInfo.ClassList.Count; i++)
            {
                ClassList.Add(LoginInfo.ClassList[i]);
            }
        }

        private void InitForm()
        {
            InitData();
            this.Text += "(" + Year + Term + "课表)【双击课程名可显示具体信息】";
            for (int i = 0; i < 7; i++) 
            {
                DrawDateLabel(23, 94, 60 + i * 93, 17, "星期" + date[i], "Date" + Convert.ToString(i), Convert.ToSingle(10.5));
            }

            for (int i = 0; i < 12; i++)
            {
                DrawDateLabel(38, 38, 21, 41 + i * 37, Convert.ToString(i + 1), "ClassIndex" + Convert.ToString(i + 1), Convert.ToSingle(15.75));
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 7; j++) 
                {
                    DrawClassLabel(38, 94, 60 + j * 93, 41 + i * 37, ClassTable[i, j]==null?"":ClassList[Convert.ToInt32(ClassTable[i, j])].ClassName, "Class" + Convert.ToString(i*7+j));
                }
            }
        }

        private void DrawDateLabel(int height,int width,int x,int y,string text,string name,float size)
        {
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Height = height;
            label.Width = width;
            label.Font = new Font("微软雅黑", size);
            label.TextAlign = ContentAlignment.MiddleCenter;
            Point points = new Point(x, y);
            label.Location = points;
            this.Controls.Add(label);
        }

        private void DrawClassLabel(int height,int width,int x,int y,string text,string name)
        {
            Label label = new Label();
            label.Name = name;
            if(text!=null)
            {
                label.Text = text;
            }
            else
            {
                label.Text = "";
            }
            label.Height = height;
            label.Width = width;
            label.BackColor = Color.White;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.DoubleClick += PrintClassInfo;
            Point points = new Point(x, y);
            label.Location = points;
            label.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(label);  
        }

        private void PrintClassInfo(object sender,EventArgs e)
        {
            Label label = (Label)sender;
            //MessageBox.Show(label.Name);
            string labelname = label.Name.Replace("Class", "");
            int x = Convert.ToInt32(labelname) / 7;
            int y = Convert.ToInt32(labelname) % 7;
            int index;
            string output = "";

            if (ClassTable[x, y] == null)
            {
                return;
            }
            else
            {
                index = Convert.ToInt32(ClassTable[x, y]);
            }

            output = "课程名称：" + ClassList[index].ClassName + "\r\n课程时间：" + ClassList[index].ClassTime + "\r\n课程教师：" + ClassList[index].Teacher + "\r\n课程地点：" + ClassList[index].Location;

            MessageBox.Show(output, "星期" + date[y] + "第" + Convert.ToString(x + 1) + "节课信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
