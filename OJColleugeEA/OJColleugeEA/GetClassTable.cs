using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OJColleugeEA
{
    public class GetClassTable
    {
        //**********************************************
        //<table.+?</table> 匹配表格
        //第\d{1,2}节.+?</tr> 匹配单节课
        //<td.+?>.+?</td> 匹配单课
        //\d{4}.\d{2}.\d{2}.+?<.+?>.[^<]+ 某些课程出现的额外时间和教室信息
        //[\u4e00-\u9fa5]-[^<]+ 课程教室
        //**********************************************


        protected string WebCode
        {
            get;
            set;
        }

        protected string TermYear
        {
            get;
            set;
        }

        protected string TermIndex
        {
            get;
            set;
        }

        protected string CT_Url
        {
            get;
            set;
        }

        protected bool IsSame
        {
            get;
            set;
        }

        protected bool IsSucceed
        {
            get;
            set;
        }

        public GetClassTable(string year,string index)
        {
            WebCode = "";
            IsSucceed = true;
            IsSame = true;
            LoginInfo.ClassList.Clear();
            LoginInfo.MaxIndex = -1;
            TermYear = year;//形式暂定为\d{4}-\d{4}
            TermIndex = index;//暂定为单个数字
            CT_Url = LoginInfo.SetUrl(LoginInfo.ClassTableCode);
            Array.Clear(LoginInfo.ClassTable, 0, LoginInfo.ClassTable.Length);
            Send_Get Get = new Send_Get(CT_Url);
            if(Get.Get_Status()==false)
            {
                IsSucceed = false;
                return;
            }
            WebCode = Get.Get_Output();

            GetKeyTable();
        }

        private void GetKeyTable()
        {
            string PostValue = "";
            Regex input = new Regex("input type=\"hidden\" name=\".*?\" value=\".*?\"");
            Regex inputname = new Regex("name=\".*?\"");
            Regex inputvalue = new Regex("value=\".*?\"");
            Regex SelectYear = new Regex("<option selected=\"selected\" value=\"\\d+-\\d+\">");
            Regex SelectTerm = new Regex("<option selected=\"selected\" value=\"\\d\">");
            Regex Years = new Regex("\\d{4}");

            Match YearMatch = SelectYear.Match(WebCode);
            Match TermMatch = SelectTerm.Match(WebCode);
            string Year = YearMatch.Value;
            string Term = TermMatch.Value;



            if (Year.IndexOf(TermYear) != -1 && Term.IndexOf(TermIndex) != -1)
            {
                RegexClassTable();
                return;
            }

            MatchCollection inputmatch = input.Matches(WebCode);
            Match yearmatch = Years.Match(TermYear);
            PostValue = inputname.Match(inputmatch[0].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=xnd&" + inputname.Match(inputmatch[1].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=&" + inputname.Match(inputmatch[2].Value).ToString().Replace("name=\"", "").Replace("\"", "") + "=" + inputvalue.Match(inputmatch[2].Value).ToString().Replace("name=\"", "").Replace("\"", "").Replace("+", "%2b") + "&xnd=";
            PostValue += yearmatch.Value + "-" + Convert.ToString(Convert.ToInt32(yearmatch.Value) + 1) + "&xqd=" + TermIndex;
            PostValue = PostValue.Replace("value=", "");
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(PostValue);

            Send_Post Post = new Send_Post(CT_Url, CT_Url, bytes);
            if(Post.GetStatus()==false)
            {
                IsSucceed = false;
                return;
            }
            WebCode = Post.GetOutPut();

            if (WebCode.IndexOf("您本学期课所选学分小于") != -1)
            {
                IsSame = false;
                return;
            }

            RegexClassTable();
        }

        private void RegexClassTable()
        {
            Regex ClassTable = new Regex("<table.+?</table>",RegexOptions.Singleline);//匹配表格
            Regex SingleLine = new Regex("第\\d{1,2}节.+?</tr>", RegexOptions.Singleline);//第\d{1,2}节.+?</tr> 匹配单节课
            Regex SingleClass = new Regex("<td.+?>.+?</td>", RegexOptions.Singleline);//<td.+?>.+?</td> 匹配单课
            Regex ExtraTime = new Regex("\\d{4}.\\d{2}.\\d{2}.+?<.+?>.[^<]+", RegexOptions.Singleline);//\d{4}.\d{2}.\d{2}.+?<.+?>.[^<]+ 某些课程出现的额外时间和教室信息
            Regex ClassRoom = new Regex("[\u4e00-\u9fa5]-[^<]+", RegexOptions.Singleline);//[\u4e00-\u9fa5]-[^<]+ 课程教室
            Regex TDHead = new Regex("align=\"Center\" rowspan.+?>", RegexOptions.Singleline);//TD信息头
            Regex Info = new Regex(".+?<.+?>", RegexOptions.Singleline);//获取单行信息
            Regex InfoLabel = new Regex("<.+?>", RegexOptions.Singleline);//单行信息标签
            Regex huge = new Regex("{.+?}", RegexOptions.Singleline);//获取周数

            Regex nums = new Regex("\\d,\\d{1,2},\\d{1,2}");//三节课的课程
            Regex num = new Regex("\\d,\\d");//两节课的课程
            Regex ClassPerWeek = new Regex("\\d节/周");//N节一周


            Match CLASSTable = ClassTable.Match(WebCode);//获取表格
            MatchCollection SingleLINE = SingleLine.Matches(CLASSTable.Value);//获取所有单行
            for (int i = 0; i < SingleLINE.Count; i++)//行数
            {
                MatchCollection SingleCLASS = SingleClass.Matches(SingleLINE[i].Value);//列数
                for (int j = 0; j < SingleCLASS.Count; j++)
                {
                    if(SingleCLASS[j].Value.IndexOf("&nbsp")!=-1)//空格
                    {
                        continue;
                    }

                    LoginInfo.ClassNode node = new LoginInfo.ClassNode();
                    if(ClassRoom.IsMatch(SingleCLASS[j].Value)==false)
                    {
                        node.Location = "课表内无教室信息";
                    }
                    else
                    {
                        node.Location = ClassRoom.Match(SingleCLASS[j].Value).Value;
                    }

                    MatchCollection ClassInfo = Info.Matches(SingleCLASS[j].Value);
                    string[] classstring = new string[ClassInfo.Count];
                    int index = 0;
                    for (int Ccnt = 0; Ccnt < ClassInfo.Count; Ccnt++)
                    {
                        string infos = ClassInfo[Ccnt].ToString().Replace(InfoLabel.Match(ClassInfo[Ccnt].Value).Value, "");//去除标签，获得信息
                        if (infos != "")
                        {
                            classstring[index++] = infos;
                        }
                        else
                        {
                            Ccnt++;
                        }
                    }
                    node.ClassName = classstring[0].Replace("<br>", "");
                    node.ClassTime = classstring[1];
                    node.Teacher = classstring[2];

                    if(classstring.Length>4)
                    {
                        for (int hugei = 4; hugei < classstring.Length; hugei++)
                        {
                            try
                            {
                                if (huge.IsMatch(classstring[hugei]))
                                {
                                    node.ClassTime += " " + huge.Match(classstring[hugei]).Value;
                                    break;
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }

                    LoginInfo.ClassList.Add(node);
                    LoginInfo.MaxIndex++;

                    int CntOfClass = 0;
                    if(nums.IsMatch(node.ClassTime)!=false)
                    {
                        CntOfClass = 3;
                    }
                    else if(num.IsMatch(node.ClassTime)!=false)
                    {
                        CntOfClass = 2;
                    }
                    else if(ClassPerWeek.IsMatch(node.ClassTime)!=false)
                    {
                        Regex numbers = new Regex("\\d节/周");
                        Regex number = new Regex("\\d");
                        CntOfClass = Convert.ToInt32(number.Match(numbers.Match(node.ClassTime).Value).Value);
                    }

                    for(int x=0;x<CntOfClass;x++)
                    {
                        LoginInfo.ClassTable[(i + x), j] = Convert.ToString(LoginInfo.MaxIndex);
                    }

                }
            }
        }

        public string Get_OutPut()
        {
            return WebCode;
        }

        public bool IsPageSame()
        {
            return IsSame;
        }

        public bool Get_Status()
        {
            return IsSucceed;
        }
    }
}
