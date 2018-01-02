using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web;

namespace OJColleugeEA
{
    public class GetClass
    {

        private string output { get; set; }
        private string sqlpara { get; set; }
        public bool ParaStatus { get; set; }
        //private string 

        public GetClass()
        {
            GetList();
        }

        private void GetList()
        {
            string url = LoginInfo.SetUrl(LoginInfo.GetClassNode);
            LoginInfo.PublicClassList.Clear();

            Send_Get get = new Send_Get(url);
            output = get.Get_Output();

            Regex TrRegex = new Regex("<tr.*?>.+?</tr>", RegexOptions.Singleline);//确定具体课程的行
            Regex InputRegex = new Regex("<input name=\".+?\" id=\".+?\" type=\"hidden\" value=\".+?\" />", RegexOptions.Singleline);//确定隐藏名称和值
            Regex ClassNameRegex = new Regex("<a href=.+?>.+?</a>", RegexOptions.Singleline);//确定课程名称，有教材信息下标取1，反之取0
            Regex NumRegex=new Regex("<td>\\d*?</td><td>\\d*?</td>",RegexOptions.Singleline);//获取课程人数和剩余人数
            Regex TDRegex = new Regex("\\d+", RegexOptions.Singleline);//分离人数
            Regex ParaRegex = new Regex("\".+?\"", RegexOptions.Singleline);
            Regex ARegex = new Regex("<a .+?>", RegexOptions.Singleline);

            MatchCollection TrMatch = TrRegex.Matches(output);

            for (int i = 1; i <= TrMatch.Count - 8; i++)
            {
                LoginInfo.OpenClassNode node = new LoginInfo.OpenClassNode();
                string MatchOutput = TrMatch[i].Value;
                MatchCollection ParaMatch = ParaRegex.Matches(InputRegex.Match(MatchOutput).Value);
                node.HiddenName = ParaMatch[0].Value.Replace("\"", "");
                node.HiddenValue = ParaMatch[3].Value.Replace("\"", "");
                MatchCollection ClassMatch = ClassNameRegex.Matches(MatchOutput);
                if(ClassMatch.Count>=3)//获取课程名称
                {
                    node.NeedBook = true;
                    node.ClassName = ClassMatch[1].Value.Replace(ARegex.Match(ClassMatch[1].Value).Value, "").Replace("</a>", "");
                    node.Teacher = ClassMatch[2].Value.Replace(ARegex.Match(ClassMatch[2].Value).Value, "").Replace("</a>", "");
                }
                else
                {
                    node.NeedBook = false;
                    node.ClassName = ClassMatch[0].Value.Replace(ARegex.Match(ClassMatch[0].Value).Value, "").Replace("</a>", "");
                    node.Teacher = ClassMatch[1].Value.Replace(ARegex.Match(ClassMatch[1].Value).Value, "").Replace("</a>", "");
                }
                node.Count = Convert.ToInt32(TDRegex.Matches(NumRegex.Match(MatchOutput).Value)[1].Value);
                node.Selected = false;
                LoginInfo.PublicClassList.Add(node);
            }
        }

        public void GetPara(string classname)
        {
            Regex input = new Regex("input type=\"hidden\" name=\".*?\" value=\".*?\"",RegexOptions.Singleline);
            Regex ParaRegex = new Regex("\".*?\"", RegexOptions.Singleline);

            MatchCollection InputMatch = input.Matches(output);

            foreach(Match i in InputMatch)
            {
                MatchCollection match = ParaRegex.Matches(i.Value);
                sqlpara += match[1].Value.Replace("\"", "") + "=" + HttpUtility.UrlEncode(match[2].Value.Replace("\"", "")) + "&";
            }

            sqlpara += "ddl_kcxz=&ddl_ywyl=" + HttpUtility.UrlEncode("有", System.Text.Encoding.GetEncoding("gb2312")) + "&ddl_kcgs=" + HttpUtility.UrlEncode("公共选修课", System.Text.Encoding.GetEncoding("gb2312")) + "&ddl_xqbs=2&ddl_sksj=&TextBox1=&";

            for (int i = 0; i < LoginInfo.PublicClassList.Count;i++ )
            {
                if (LoginInfo.PublicClassList[i].ClassName.IndexOf(classname)==-1)
                {
                    sqlpara += HttpUtility.UrlEncode(LoginInfo.PublicClassList[i].HiddenName) + "=" + HttpUtility.UrlEncode(LoginInfo.PublicClassList[i].HiddenValue, System.Text.Encoding.GetEncoding("gb2312")) + "&";
                }
                else
                {
                    sqlpara += HttpUtility.UrlEncode(LoginInfo.PublicClassList[i].HiddenName.Replace("jcnr", "xk"), System.Text.Encoding.GetEncoding("gb2312")) + "=on&" + HttpUtility.UrlEncode(LoginInfo.PublicClassList[i].HiddenName, System.Text.Encoding.GetEncoding("gb2312")) + "=" + HttpUtility.UrlEncode(LoginInfo.PublicClassList[i].HiddenValue, System.Text.Encoding.GetEncoding("gb2312")) + "&";
                }
            }

            sqlpara += HttpUtility.UrlEncode("dpkcmcGrid:txtChoosePage", System.Text.Encoding.GetEncoding("gb2312")) + "=1&" + HttpUtility.UrlEncode("dpkcmcGrid:txtPageSize", System.Text.Encoding.GetEncoding("gb2312")) + "=15&Button1=" + HttpUtility.UrlEncode("  提交  ", System.Text.Encoding.GetEncoding("gb2312"));
        }

        public string GetClasss(string classname)
        {
            GetPara(classname);

            string url = LoginInfo.SetUrl(LoginInfo.GetClassNode);

            byte[] array = System.Text.Encoding.GetEncoding("gb2312").GetBytes(sqlpara);

            Send_Post post = new Send_Post(url, url, array);

            Regex Alert = new Regex("alert\\('.+?'\\)", RegexOptions.Multiline);
            string output = Alert.Match(post.GetOutPut()).Value.Replace("alert('", "").Replace("')", "");

            return output;
        }
    }
}
