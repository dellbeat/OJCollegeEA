using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace OJColleugeEA
{
    public partial class EALoginForm : Form
    {
        public EALoginForm()
        {
            InitializeComponent();
            LoginInfo.ClassTableCode = LoginInfo.SetNodeValue("xskbcx", "N121603", "学生个人课表(重要)");
            LoginInfo.GradeCode = LoginInfo.SetNodeValue("xscjcx", "N121605", "成绩查询");
        }

        ClassTableForm TableForm = null;
        int IsLogin = 0;

        #region 登陆至教务系统
        /// <summary>
        /// 登陆至教务系统
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <param name="secertcode"></param>
        private void LoginToEA(string account,string password,string secertcode)
        {
            Login loginfc = new Login(account, password, secertcode);
            LoginInfo.UserAccount = account;

            if(loginfc.GetLoginStatus()=="OK")
            {
                LoginInfo.GetUserName();
                LoginInfo.InitYearOfTerm();
                LoginInfo.InitGradeRange();
                Action<string> InitTermItems = (x) => { TermYear.Items.Add(x); };
                for (int i = 0; i < LoginInfo.YearsOfTerm.Count;i++ )
                {
                    TermYear.BeginInvoke(InitTermItems, LoginInfo.YearsOfTerm[i]);
                }
                Action<string> InitGradeItems = (x) => { YearOfGrade.Items.Add(x); };
                for (int i = 0; i < LoginInfo.YearsOfGrade.Count; i++)
                {
                    YearOfGrade.BeginInvoke(InitGradeItems, LoginInfo.YearsOfGrade[i]);
                }
                    IsLogin = 1;
            }
            else if(loginfc.GetLoginStatus()=="InvalidCode")
            {
                MessageBox.Show("验证码输入错误，请检查后重新输入！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(loginfc.GetLoginStatus()=="InvalidPassword")
            {
                MessageBox.Show("密码输入错误，请确认密码后重新输入！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (loginfc.GetLoginStatus() == "InvalidAccount")
            {
                MessageBox.Show("帐号不存在或者未按规定参加教学活动，请检查帐号是否输入正确或联系教务处！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("因未知错误而导致登陆失败，请检查网络后重启程序再试！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(loginfc.GetLoginStatus()!="OK")
            {
                RequestCode();
                IsLogin = 0;
                return;
            }

        }
        #endregion

        #region 窗体加载时请求验证码
        private void FormLoadInit()
        {
            GetCookies newcookie = new GetCookies();
            if (newcookie.Getstatus() != "OK")
            {
                MessageBox.Show("无法请求Cookies，程序即将退出，请检查网络状态后重新启动程序再试！", "初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            GetViewCode newviewcode = new GetViewCode();
            if(newviewcode.GetStatus()!="OK")
            {
                MessageBox.Show("无法加载验证码图片，程序即将退出，请检查网络状态后重新启动程序再试！", "初始化失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            CodeView.Image = newviewcode.GetPic();           
        }

        #region 异步化请求验证码函数
        private Task FormInitTask()
        {
            return Task.Run(() =>
            {

                FormLoadInit();
            });
        }
        #endregion

        #endregion

        #region 请求验证码
        private void RequestCode()
        {
            GetCookies CodeCookie = new GetCookies();
            if(CodeCookie.Getstatus()!="OK")
            {
                   MessageBox.Show("Cookie请求失败，请检查网络状态后再试！", "请求失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   return;
            }
            GetViewCode CodePic = new GetViewCode();
            if(CodePic.GetStatus()!="OK")
            {
                  MessageBox.Show("验证码请求失败，请检查网络状态后再试！", "请求失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
            }
            CodeView.Image = CodePic.GetPic();
        }

        private Task RequestCodeTask()
        {
            return Task.Run(() =>
                {
                    RequestCode();
                });
        }
        #endregion

        #region 登陆请求异步化
        private void Login()
        {
            LoginToEA(Account.Text, Password.Text, SecertCode.Text);
        }

        private Task LoginTask()
        {
            return Task.Run(() =>
                {
                    Login();
                });
        }

        private async void CallLoginFC()
        {
            if (Account.Text == "" || Password.Text == "" || SecertCode.Text == "")
            {
                MessageBox.Show("有未填写的内容，请填写完毕后再进行登陆", "信息不全提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoginIn.Enabled = false;
            ReInput.Enabled = false;
            LoginIn.Text = "登陆中...";
            await LoginTask();
            LoginIn.Enabled = true;
            ReInput.Enabled = true;
            LoginIn.Text = "登陆";
            if(IsLogin==0)
            {
                return;
            }
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            Account.Text = "";
            Password.Text = "";
            SecertCode.Text = "";
            Account.Visible = false;
            Password.Visible = false;
            SecertCode.Visible = false;
            CodeView.Visible = false;
            LoginIn.Visible = false;
            ReInput.Visible = false;
            QueryGroup.Enabled = true;
            LogOut.Visible = true;
            GradeBox.Enabled = true;
            MessageBox.Show(LoginInfo.UserName + "同学，欢迎你！", "欢迎使用本软件", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void QueryTable()
        {
            if (TermYear.Text == null || TermIndex.Text == null)
            {
                MessageBox.Show("有未选择部分，请选择后再试！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoginInfo.SelectedYear = TermYear.Text;
            LoginInfo.SelectedTerm = TermIndex.Text;

            string Year, Index;
            Regex YearString = new Regex("\\d{4}-\\d{4}");
            Year = YearString.Match(TermYear.Text).Value;
            if (TermIndex.Text == "第一学期")
            {
                Index = "1";
            }
            else
            {
                Index = "2";
            }

            GetClassTable GetTable = new GetClassTable(Year, Index);
            if(GetTable.Get_Status()==false)
            {
                MessageBox.Show("查询过程中遇到错误，可能的原因为："+LoginInfo.FailedReason+"请尝试解决问题后再试！\r\n错误日志："+LoginInfo.FailedLog,"查询失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (GetTable.IsPageSame() == false)
            {
                MessageBox.Show("当前选择的学期暂无课程，请选择其他学期查询！", "无课提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (TableForm == null || TableForm.IsDisposed)
            {
                TableForm = new ClassTableForm();
                TableForm.Show();
            }
            else
            {
                MessageBox.Show("请关闭当前课表窗口后再进行其它查询，谢谢！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TableForm.Activate();
            }
        }

        private Task CallQuery()
        {
            return Task.Run(() =>
                {
                    QueryTable();
                });
        }

        private async void CodeView_Click(object sender, EventArgs e)
        {
            await RequestCodeTask();
        }

        private async void EALoginForm_Load(object sender, EventArgs e)
        {
            await FormInitTask();
        }

        private void LoginIn_Click(object sender, EventArgs e)
        {
            CallLoginFC();
        }

        private void ReInput_Click(object sender, EventArgs e)
        {
            Account.Text = "";
            Password.Text = "";
            SecertCode.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToShortTimeString() + ":" + DateTime.Now.Millisecond;
        }

        private void QueryClassTable_Click(object sender, EventArgs e)
        {
            QueryTable();
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            LoginInfo.EACookie = null;
            LoginInfo.LoginSucceed = false;
            LoginInfo.GradeList.Clear();
            TableForm = null;
            TermYear.Items.Clear();
            TermIndex.Text = null;
            LoginInfo.YearsOfTerm.Clear();
            LoginInfo.YearsOfGrade.Clear();
            YearOfGrade.Items.Clear();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            Account.Text = "";
            Password.Text = "";
            SecertCode.Text = "";
            Account.Visible = true;
            Password.Visible = true;
            SecertCode.Visible = true;
            CodeView.Visible = true;
            LoginIn.Visible = true;
            ReInput.Visible = true;
            QueryGroup.Enabled = false;
            LogOut.Visible = false;
            GradeBox.Enabled = false;
            TermOfGrade.Text = null;
            YearOfGrade.Text = null;
            TermYear.Items.Clear();
            MessageBox.Show("退出登录成功，欢迎下次使用，再见！", "退出成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RequestCode();
        }

        private void EALoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string YouAreLogin = "";
            if(LoginInfo.LoginSucceed==true)
            {
                YouAreLogin = "您处于登录状态，";
            }
            DialogResult result = MessageBox.Show(YouAreLogin+"确定关闭软件吗？", "关闭提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(result==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void QueryGrade_Click(object sender, EventArgs e)
        {
            if (TermOfGrade.Text == null || YearOfGrade.Text == null)
            {
                MessageBox.Show("有未选择部分，请选择后再试！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoginInfo.SelectedYear = YearOfGrade.Text;
            LoginInfo.SelectedTerm = TermOfGrade.Text;

            string Year, Index;
            Regex YearString = new Regex("\\d{4}-\\d{4}");
            Year = YearString.Match(YearOfGrade.Text).Value;
            if (TermOfGrade.Text == "第一学期")
            {
                Index = "1";
            }
            else
            {
                Index = "2";
            }

            GetGrade Grade = new GetGrade(Year, Index);
            if(Grade.Get_Status()==false)
            {
                MessageBox.Show("查询过程中遇到错误，可能的原因为：" + LoginInfo.FailedReason + "请尝试解决问题后再试！\r\n错误日志：" + LoginInfo.FailedLog, "查询失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(Grade.Get_EmptyStatus()==true)
            {
                MessageBox.Show("当前选择的学期暂无成绩信息，请选择其他学期查询！", "查询提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string output = "";

            for (int i = 0; i < LoginInfo.GradeList.Count; i++)
            {
                output += "课程名称：" + LoginInfo.GradeList[i].ClassName + "；绩点：" + LoginInfo.GradeList[i].ClassPoint + "；学分：" + LoginInfo.GradeList[i].ClassCredit + "；成绩：" + LoginInfo.GradeList[i].ClassGrade + "\r\n";
            }

            DialogResult result = MessageBox.Show(output+"点击“是”将成绩结果复制到剪切板并退出对话框，点击“否”则直接退出对话框。", "成绩查询结果", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if(result==DialogResult.Yes)
            {
                Clipboard.SetDataObject(output);
            }
        }

        //protected struct PerSon
        //{
        //    string name;
        //    string sex;
        //    bool IsSingle;
        //    public bool IsChatInGroup;
        //    public bool IsWantToPorn;
        //}

        //PerSon man = new PerSon();

        //private void JudgeMan()
        //{
        //    if (man.IsChatInGroup == true && man.IsWantToPorn == true)
        //    {
        //        MessageBox.Show("不去学习约NMB", "GUN", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        
    }
}
