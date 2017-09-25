using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace OJColleugeEA
{
    public partial class SaveClassTable : Form
    {
        public SaveClassTable()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(password.Text=="")
            {
                MessageBox.Show("请输入密码后再试！", "密码为空提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(LoginInfo.ClassList.Count==0||LoginInfo.QueryFormOnline==false)
            {
                MessageBox.Show("请查询课表后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date = DateTime.Now;
            string FileName = Convert.ToString(date.Year) + "_" + Convert.ToString(date.Month) + "_" + Convert.ToString(date.Day) + "_" + Convert.ToString(date.Hour) + Convert.ToString(date.Minute) + Convert.ToString(date.Second) + Convert.ToString(date.Millisecond) + ".txt";
            
            //FileStream fs = new FileStream(FileName + ".dat", FileMode.Create);
            StreamWriter sW1 = new StreamWriter(FileName,true,Encoding.UTF8);
            //StreamWriter sw = new StreamWriter(fs);

            string TransPsw = "Password:" + System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5") + "\r\n";//写入加密后密码

            string Output = "";

            for (int i = 0; i < LoginInfo.ClassList.Count; i++)//写入节点信息
            {
                Output += "ClassName:" + LoginInfo.ClassList[i].ClassName + "\r\n";
                Output += "ClassTime:" + LoginInfo.ClassList[i].ClassTime + "\r\n";
                Output += "Teacher:" + LoginInfo.ClassList[i].Teacher + "\r\n";
                Output += "Location:" + LoginInfo.ClassList[i].Location + "\r\n";
                Output += "\r\n";
            }

            Output += "Locations\r\n";

            for (int i = 0; i < 12; i++) 
            {
                for (int j = 0; j < 7; j++) 
                {
                    Output += LoginInfo.ClassTable[i, j] == null ? "<.>" : "<" + Convert.ToString(LoginInfo.ClassTable[i, j]) + ">";
                }
                Output += "\r\n";
            }

            Output += "EndLocation\r\n";

            Output += "SelectedYear:" + LoginInfo.SelectedYear + "\r\n";
            Output += "SelectedTerm:" + LoginInfo.SelectedTerm + "\r\n";
            

            Base64CryptFun Crypt = new Base64CryptFun();
            Output = Crypt.Encode(Output);

            Output = TransPsw + Output;

            sW1.Write(Output);

            sW1.Close();

            MessageBox.Show("课程表导出成功，文件名为：" + FileName + "，使用当前密码可以再次读取！", "导出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

            System.Diagnostics.ProcessStartInfo pi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            pi.Arguments = "/e,/select," + FileName;
            System.Diagnostics.Process.Start(pi);
        }
    }
}
