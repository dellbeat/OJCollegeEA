using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OJColleugeEA
{
    public class Send_Get
    {
        protected string GetUrl
        {
            get;
            set;
        }

        protected string Output
        {
            get;
            set;
        }

        protected bool Status
        {
            get;
            set;
        }

        public Send_Get(string url)
        {
            GetUrl = url;
            Output = "";

            Get_Request();
        }

        private void Get_Request()
        {
            #region 构造请求头
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(GetUrl);
            request.Method = "GET";
            SetHeader.SetHeaderValue(request.Headers, "Host", "ojjx.wzu.edu.cn");
            SetHeader.SetHeaderValue(request.Headers, "Connection", "keep-alive");
            request.Headers["Upgrade-Insecure-Requests"] = "1";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            request.Headers["DNT"] = "1";
            request.Referer = "http://ojjx.wzu.edu.cn/xs_main.aspx?xh=" + LoginInfo.UserAccount;
            request.Headers["Accept-Encoding"] = "gzip, deflate";
            request.Headers["Accept-Language"] = "zh-CN,zh;q=0.8";
            request.CookieContainer = LoginInfo.EACookie;
            #endregion

            #region 返回并接收数据
            try
            {
                HttpWebResponse res = (HttpWebResponse)request.GetResponse();
                StreamReader ReaderOfStream = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
                Output = ReaderOfStream.ReadToEnd();
                Status = true;
            }
            catch(Exception e)
            {
                Status = false;
                LoginInfo.FailedReason = "GET请求出现异常，请检查网络是否中断或者丢包。";
                LoginInfo.FailedLog = e.Message;
            }
            #endregion
        }

        public string Get_Output()
        {
            return Output;
        }

        public bool Get_Status()
        {
            return Status;
        }
    }
}
