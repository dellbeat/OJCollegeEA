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
using System.Text.RegularExpressions;

namespace OJColleugeEA
{
    public partial class DecodeForm : Form
    {
        string FilePath = "";
        ClassTableForm table = null;
        public DecodeForm()
        {
            InitializeComponent();
        }

        private void VieFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "TXT文件|*.txt";

            if(file.ShowDialog()==DialogResult.OK)
            {
                FilePath = file.FileName;
            }
            else
            {
                return;
            }
        }

        private void DeCT_Click(object sender, EventArgs e)
        {
            string c = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "MD5");

            if(FilePath=="")
            {
                MessageBox.Show("未选择文件，请选择后再试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(password.Text=="")
            {
                MessageBox.Show("未输入密码，请输入后再试！", "空密码提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            StreamReader sr = new StreamReader(FilePath,Encoding.UTF8);

            string content = sr.ReadToEnd();

            if(content.IndexOf(c)==-1)
            {
                MessageBox.Show("密码错误！请检查后再试！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sr.Close();
                return;
            }

            sr.Close();

            Base64CryptFun Crypt=new Base64CryptFun();

            string NoPassContent = content.Replace("Password:"+ c + "\r\n", "");

            NoPassContent = Crypt.Decode(NoPassContent);

            Regex Loc = new Regex("<.+?>");
            Regex ClassName = new Regex("ClassName:.+", RegexOptions.Multiline);
            Regex ClassTime = new Regex("ClassTime:.+", RegexOptions.Multiline);
            Regex Teacher = new Regex("Teacher:.+", RegexOptions.Multiline);
            Regex Location = new Regex("Location:.+", RegexOptions.Multiline);
            Regex Num = new Regex("\\d{1,2}", RegexOptions.Multiline);
            Regex SelectedYear = new Regex("SelectedYear:.+", RegexOptions.Multiline);
            Regex SelectedTerm = new Regex("SelectedTerm:.+", RegexOptions.Multiline);

            MatchCollection ClassMatch = ClassName.Matches(NoPassContent);
            MatchCollection TimeMatch = ClassTime.Matches(NoPassContent);
            MatchCollection TeaMatch = Teacher.Matches(NoPassContent);
            MatchCollection LocationMatch = Location.Matches(NoPassContent);
            MatchCollection LocMatch = Loc.Matches(NoPassContent);

            LoginInfo.ClassList.Clear();

            for (int i = 0; i < ClassMatch.Count; i++)
            {
                LoginInfo.ClassNode node = new LoginInfo.ClassNode();

                node.ClassName = ClassMatch[i].Value.Replace("\r", "").Replace("ClassName:", "").Replace("\n", "");
                node.ClassTime = TimeMatch[i].Value.Replace("\r", "").Replace("ClassTime:", "").Replace("\n", "");
                node.Location = LocationMatch[i].Value.Replace("\r", "").Replace("Location:", "").Replace("\n", "");
                node.Teacher = TeaMatch[i].Value.Replace("\r", "").Replace("Teacher:", "").Replace("\n", "");

                LoginInfo.ClassList.Add(node);
            }

            //MessageBox.Show(Convert.ToString(LoginInfo.ClassList.Count));

            for (int i = 0; i < LocMatch.Count; i++)
            {
                if(Num.IsMatch(LocMatch[i].Value)==true)
                {
                    LoginInfo.ClassTable[i / 7, i % 7] = Num.Match(LocMatch[i].Value).Value;
                }
                else
                {
                    LoginInfo.ClassTable[i / 7, i % 7] = null;
                }
            }

            string Year = SelectedYear.Match(NoPassContent).Value.Replace("SelectedYear:", "").Replace("\r\n", "");
            string Trem = SelectedTerm.Match(NoPassContent).Value.Replace("SelectedTerm:", "").Replace("\r\n", "");

            LoginInfo.SelectedYear = Year;
            LoginInfo.SelectedTerm = Trem;
            LoginInfo.QueryFormOnline = false;

            if (table == null || table.IsDisposed)
            {
                table = new ClassTableForm();
                table.Show();
            }
            else
            {
                table.Activate();
            }
        }
    }
}
