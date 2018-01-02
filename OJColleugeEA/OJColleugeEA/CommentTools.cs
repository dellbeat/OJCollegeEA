using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace OJColleugeEA
{
    public class CommentTools
    {
        public string PageStr { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public List<string> NameStr { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public List<string> LinkStr { get; set; }
        /// <summary>
        /// 评教状态
        /// </summary>
        public List<bool> IsComment { get; set; }

        Regex TableRegex = new Regex("<table class=\"datelist\".+?</table>", RegexOptions.Singleline);
        Regex ClassRegex = new Regex("<td>.+?</td>\r\n", RegexOptions.Multiline);
        Regex NameRegex = new Regex("<td>.+?</td>", RegexOptions.Singleline);
        Regex LinkRegex=new Regex("window.open\\('.+?'",RegexOptions.Singleline);
        Regex ValueRegex = new Regex("name=\".+?\" value=\"100\"", RegexOptions.Multiline);
        Regex NameClassRegex = new Regex("\".+?\"", RegexOptions.Singleline);

        public CommentTools()
        {
            NameStr = new List<string>();
            LinkStr = new List<string>();
            IsComment = new List<bool>();
            GetPageStr();
        }

        private void GetPageStr()
        {
            Send_Get Get = new Send_Get(LoginInfo.SetUrl(LoginInfo.CommentCode));
            if(Get.Get_Status()==true)
            {
                PageStr = Get.Get_Output();
                if(PageStr.IndexOf("已经评价过")!=-1)
                {
                    MessageBox.Show("已经完成评价任务，无需评教！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (PageStr.IndexOf("已关闭") != -1)
                {
                    MessageBox.Show("评教系统已关闭，请与相关部门联系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                PageStr = "网络错误，请稍后重试！";
                return;
            }

            string TableStr = TableRegex.Match(PageStr).Value;
            MatchCollection ClassMatch = ClassRegex.Matches(TableStr);

            foreach(Match i in ClassMatch)
            {
                if(i.Value.IndexOf("onclick")==-1)
                {
                    continue;
                }

                NameStr.Add(NameRegex.Match(i.Value).Value.Replace("<td>", "").Replace("</td>",""));//课程名称
                LinkStr.Add(LinkRegex.Match(i.Value).Value.Replace("window.open('", "").Replace("'", ""));//链接
                if(i.Value.IndexOf("已评价")==-1)
                {
                    IsComment.Add(false);
                }
                else
                {
                    IsComment.Add(true);
                }
            }
        }

        public bool Comment(string url)
        {
            Send_Get Get = new Send_Get(url);
            string Page = "";

            if(Get.Get_Status())
            {
                Page = Get.Get_Output();
            }
            else
            {
                Page = "网络错误，请稍后再试！";
                return false;
            }

            MatchCollection Matchs = ValueRegex.Matches(Page);//获取所有分数为100分的标签
            List<string> NameList = new List<string>();
            foreach(Match i in Matchs)
            {
                NameList.Add(NameClassRegex.Match(i.Value).Value.Replace("\"", ""));
            }

            Regex input = new Regex("<input type=\"hidden\" name=\"__VIEWSTATE\" value=\"(.*?)\" />");
            Regex inputname = new Regex("name=\".*?\"");
            Regex inputvalue = new Regex("value=\".*?\"");

            string ViewState = input.Match(Page).Value;
            string postvalue = inputname.Match(ViewState).Value.Replace("name=\"", "").Replace("\"", "") + "=" + HttpUtility.UrlEncode(inputvalue.Match(ViewState).Value.Replace("value=\"", "").Replace("\"", ""));

            foreach (string i in NameList)
            {
                postvalue += "&" + HttpUtility.UrlEncode(i) + "=100";
            }

            postvalue += "&txt_pjxx=&Button1=+%CC%E1+%BD%BB+";
            byte[] arrays = System.Text.Encoding.ASCII.GetBytes(postvalue);

            Send_Post Post = new Send_Post(url, url, arrays);

            if(Post.GetOutPut().IndexOf("提交成功")!=-1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Submit()
        {
            if (PageStr.IndexOf("已经评价过") != -1)
            {
                MessageBox.Show("已经完成评价任务，无需评教！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            for (int i = 0; i < LinkStr.Count; i++)
            {
                if (IsComment[i] == true)
                {
                    continue;
                }

                string url = "http://ojjx.wzu.edu.cn/" + LinkStr[i];

                if (Comment(url))
                {
                    IsComment[i] = true;
                }
                else
                {
                    IsComment[i] = false;
                }
            }

            Regex input = new Regex("input type=\"hidden\" name=\".*?\" value=\".*?\"");
            Regex inputname = new Regex("name=\".*?\"");
            Regex inputvalue = new Regex("value=\".*?\"");

            MatchCollection PageMatch = input.Matches(PageStr);
            string poststr = "";

            foreach(Match i in PageMatch)
            {
                string name=HttpUtility.UrlEncode(inputname.Match(i.Value).Value.Replace("name=\"", "").Replace("\"", ""));
                string value=HttpUtility.UrlEncode(inputvalue.Match(i.Value).Value.Replace("value=\"","").Replace("\"",""));
                poststr += name + "=" + value + "&";
            }

            poststr += "btn_tj=+%CC%E1+%BD%BB+";

            byte[] array=System.Text.Encoding.ASCII.GetBytes(poststr);

            Send_Post Post = new Send_Post(LoginInfo.SetUrl(LoginInfo.CommentCode), LoginInfo.SetUrl(LoginInfo.CommentCode), array);
            
            if(Post.GetOutPut().IndexOf("完成评价")!=-1)
            {
                MessageBox.Show("一键评教完成！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("一键评教出现问题，请自行登陆教务系统确认是否完成评教！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
