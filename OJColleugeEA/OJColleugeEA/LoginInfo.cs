using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;

namespace OJColleugeEA
{
    class LoginInfo
    {
        public static string UserAccount;
        public static string UserName;
        public static CookieContainer EACookie;
        public static string[,] ClassTable = new string[12, 7];//课程表表格
        public struct node
        {
            public string linkname;//如xskbcx（学生课表查询）
            public string modecode;//功能模块代码
            public string name;//对应中文菜单名称
        }

        public struct ClassNode
        {
            public string ClassName;
            public string ClassTime;
            public string Teacher;
            public string Location;
        }

        public struct GradeNode
        {
            public string ClassName;
            public string ClassCredit;
            public string ClassPoint;
            public string ClassGrade;
        }

        public static List<GradeNode> GradeList = new List<GradeNode>();
        public static node ClassTableCode = new LoginInfo.node();
        public static node GradeCode = new LoginInfo.node();
        public static List<string> YearsOfTerm = new List<string>();
        public static List<ClassNode> ClassList = new List<ClassNode>();
        public static int MaxIndex = -1;
        public static string SelectedYear;//通用于课表和成绩 下同
        public static string SelectedTerm;
        public static bool LoginSucceed;
        public static string FailedReason;
        public static string FailedLog;
        public static List<string> YearsOfGrade = new List<string>();

        /// <summary>
        /// 设置功能节点的值
        /// </summary>
        /// <param name="link"></param>
        /// <param name="mode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static node SetNodeValue(string link,string mode,string name)
        {
            node nodes=new node();

            nodes.linkname = link;
            nodes.modecode = mode;
            nodes.name = name;

            return nodes;
        }

        /// <summary>
        /// 返回模块功能地址
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static string SetUrl(node nodes)
        {
            string url = "http://ojjx.wzu.edu.cn/";
            string username = HttpUtility.UrlEncode(UserName, System.Text.Encoding.GetEncoding("gb2312"));
            url += nodes.linkname + ".aspx?xh=" + UserAccount + "&xm=" + username + "&gnmkdm=" + nodes.modecode;

            return url;
        }

        /// <summary>
        /// 初始化查询范围
        /// </summary>
        public static void InitYearOfTerm()
        {
            Regex SelectForm = new Regex("<select name=\"xnd\".+?</select>", RegexOptions.Singleline);
            Regex Time = new Regex("\\d{4}-\\d{4}", RegexOptions.Singleline);
            string url = SetUrl(ClassTableCode);
            string webcode = "";

            Send_Get Get = new Send_Get(url);
            webcode = Get.Get_Output();

            MatchCollection TimeCollect = Time.Matches(webcode);
            for (int i = 0; i < TimeCollect.Count; i += 2)
            {
                YearsOfTerm.Add(TimeCollect[i].Value + "学年");
            }
            YearsOfTerm.Sort();

        }

        /// <summary>
        /// 获取用户姓名
        /// </summary>
        public static void GetUserName()
        {
            string webcode = "";
            string url = "http://ojjx.wzu.edu.cn/xs_main.aspx?xh=" + UserAccount;
            Send_Get Get = new Send_Get(url);
            webcode = Get.Get_Output();

            Regex hello = new Regex("<span id=\"xhxm\">[\u4e00-\u9fa5]+</span></em>");//匹配包含姓名的字符串
            Regex names = new Regex("[\u4e00-\u9fa5]+");//匹配字符串内的中文
            Match match = hello.Match(webcode);//第一次匹配
            Match matchname = names.Match(match.ToString());//第二次匹配

            LoginInfo.UserName = matchname.ToString().Replace("同学", "");//匹配出姓名
        }

        /// <summary>
        /// 初始化成绩查询范围
        /// </summary>
        public static void InitGradeRange()
        {
            YearsOfGrade.Clear();
            string webcode = "";
            string url = SetUrl(GradeCode);

            Send_Get Get = new Send_Get(url);

            webcode = Get.Get_Output();

            Regex SelectYear = new Regex("<select name=\"ddlXN\" id=\"ddlXN\">.+?</select>",RegexOptions.Singleline);
            Regex Range = new Regex("\\d{4}-\\d{4}");

            Match Select = SelectYear.Match(webcode);
            MatchCollection RangeNum = Range.Matches(Select.Value);
            for (int i = 0; i < RangeNum.Count; i += 2)
            {
                YearsOfGrade.Add(RangeNum[i].Value+"学年");
            }
            YearsOfGrade.Sort();
        }

        public static GradeNode Get_GradeNode(string ClassName)
        {
            GradeNode node = new GradeNode();
            node.ClassName = "FAILED";

            for (int i = 0; i < GradeList.Count; i++)
            {
                if(GradeList[i].ClassName==ClassName)
                {
                    node = GradeList[i];
                    break;
                }
            }

            return node;

        }
    }
}
