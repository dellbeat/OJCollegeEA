using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Web;

namespace OJColleugeEA
{
    public class Login
    {
        protected string UserAccount
        {
            get;
            set;
        }

        protected string UserPassword
        {
            get;
            set;
        }

        protected string SecertCode
        {
            get;
            set;
        }

        protected string Output
        {
            get;
            set;
        }

        protected string LoginUrl
        {
            get;
            set;
        }

        protected string LoginStatus//OK为登陆成功，InvalidCode为验证码错误，InvalidPassword为密码错误，InvalidAccount为帐号不存在或者被限制，UnknownError为未知错误
        {
            get;
            set;
        }

        protected string UserName
        {
            get;
            set;
        }

        public Login(string account,string password,string code)
        {
            UserAccount = account;
            UserPassword = password;
            SecertCode = code;
            LoginUrl = "http://ojjx.wzu.edu.cn/default2.aspx";
            Output="";
            LoginToEA();
        }

        private void LoginToEA()
        {
            Regex reg = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.*?)\" />");
            string PostString = "";
            string ViewStateCode = "";
            Send_Post Post;

            #region 登陆主页获取网页内容
            HttpWebRequest GetStateCode = (HttpWebRequest)HttpWebRequest.Create(LoginUrl);//连接主页
            WebResponse result = GetStateCode.GetResponse();//获取响应
            Stream receviceStream = result.GetResponseStream();//创建IO流
            StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("gb2312"));//创建流读取器
            string strHTML = readerOfStream.ReadToEnd();//获取网页内容
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();//关闭流
            #endregion

            #region 匹配ViewState
            Match whatstate = reg.Match(strHTML);//创建匹配VIEWSTATE的正则表达式
            ViewStateCode = whatstate.Groups[1].Value;//匹配结果
            ViewStateCode = HttpUtility.UrlEncode(ViewStateCode);//URL编码
            PostString = "__VIEWSTATE=" + ViewStateCode + "&txtUserName=" + UserAccount + "&Textbox1=&TextBox2=" + UserPassword + "&txtSecretCode=" + SecertCode + "&RadioButtonList1=%D1%A7%C9%FA" + "&Button1=&lbLanguage=&hidPdrs=&hidsc=";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostString);
            #endregion

            Post = new Send_Post(LoginUrl, LoginUrl, bytes);
            Output = Post.GetOutPut();

            if(Output.IndexOf("验证码")==-1)
            {
                LoginStatus = "OK";
                LoginInfo.LoginSucceed = true;
            }
            else//OK为登陆成功，InvalidCode为验证码错误，InvalidPassword为密码错误，InvalidAccount为帐号不存在或者被限制，UnknownError为未知错误
            {
                if (Output.IndexOf("验证码不正确") != -1)
                {
                    LoginStatus = "InvalidCode";
                }
                else if (Output.IndexOf("密码错误") != -1)
                {
                    LoginStatus = "InvalidPassword";
                }
                else if (Output.IndexOf("用户名不存在") != -1)
                {
                    LoginStatus = "InvalidAccount";
                }
                else
                {
                    LoginStatus = "UnknownError";
                }
                LoginInfo.LoginSucceed = false;
            }

        }

        public string GetOutPut()
        {
            return Output;
        }

        public string GetLoginStatus()
        {
            return LoginStatus;
        }
    }
}
