using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OJColleugeEA
{
    public class GetGrade
    {
        protected string WebCode
        {
            get;
            set;
        }

        protected bool IsSucceed
        {
            get;
            set;
        }

        protected string Url
        {
            get; 
            set;
        }

        protected string YearOfGrade
        {
            get;
            set;
        }

        protected string TermOfGrade
        {
            get;
            set;
        }

        protected bool IsEmpty
        {
            get;
            set;
        }

        public GetGrade(string Year,string Term)
        {
            LoginInfo.GradeList.Clear();
            WebCode = "";
            Url = LoginInfo.SetUrl(LoginInfo.GradeCode);
            YearOfGrade = Year;//\d{4}-\d{4}
            TermOfGrade = Term;
            IsSucceed = true;
            IsEmpty = true;

            Send_Get Get = new Send_Get(Url);

            if(Get.Get_Status()==false)
            {
                IsSucceed = false;
                return;
            }

            WebCode = Get.Get_Output();

            Send_GetGrade_Req();
        }

        private void Send_GetGrade_Req()
        {
            string PostValue;
            Regex input = new Regex("input type=\"hidden\" name=\".*?\" value=\".*?\"");
            Regex inputname = new Regex("name=\".*?\"");
            Regex inputvalue = new Regex("value=\".*?\"");
            Regex Time=new Regex("\\d{4}");

            Match yearmatch = Time.Match(YearOfGrade);

            MatchCollection inputmatch = input.Matches(WebCode);
            PostValue = inputname.Match(inputmatch[0].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=xnd&" + inputname.Match(inputmatch[1].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=&" + inputname.Match(inputmatch[2].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=" + inputvalue.Match(inputmatch[2].Value).ToString().Replace("name=\"", "").Replace("\"", "").Replace("+", "%2b") + "&hidLanguage=&ddlXN=";
            PostValue += yearmatch.Value + "-" + Convert.ToString(Convert.ToInt32(yearmatch.Value) + 1) + "&ddlXQ=" + TermOfGrade + "&ddl_kcxz=&btn_xq=%D1%A7%C6%DA%B3%C9%BC%A8";
            PostValue = PostValue.Replace("value=", "");
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostValue);

            Send_Post Post = new Send_Post(Url, Url, bytes);

            if(Post.GetStatus()==false)
            {
                IsSucceed = false;
                return;
            }

            WebCode = Post.GetOutPut();

            RegexGrade();
        }

        private void RegexGrade()
        {
            Regex table = new Regex("<table class=\"datelist\".+?</table>",RegexOptions.Singleline);
            Regex SingleClass = new Regex("<tr.+?</tr>",RegexOptions.Singleline);
            Regex SingleInformation = new Regex("<td>.+?</td>", RegexOptions.Singleline);//3678

            string tabledata = table.Match(WebCode).Value;
            MatchCollection Classes = SingleClass.Matches(tabledata);
            for (int i = 1; i < Classes.Count; i++)
            {
                IsEmpty = false;
                MatchCollection Inf=SingleInformation.Matches(Classes[i].Value);
                LoginInfo.GradeNode node = new LoginInfo.GradeNode();
                node.ClassName = Inf[3].Value.Replace("<td>", "").Replace("</td>", "").Trim();
                node.ClassCredit = Inf[6].Value.Replace("<td>", "").Replace("</td>", "").Trim();
                node.ClassPoint = Inf[7].Value.Replace("<td>", "").Replace("</td>", "").Trim();
                if (node.ClassPoint.IndexOf("&nbsp") != -1)
                {
                    node.ClassPoint = "无";
                }
                node.ClassGrade = Inf[8].Value.Replace("<td>", "").Replace("</td>", "").Trim();
                LoginInfo.GradeList.Add(node);
            }
        }

        public bool Get_Status()
        {
            return IsSucceed;
        }

        public bool Get_EmptyStatus()
        {
            return IsEmpty;
        }
    }
}
