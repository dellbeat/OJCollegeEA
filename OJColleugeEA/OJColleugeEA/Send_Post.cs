using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace OJColleugeEA
{
    public class Send_Post
    {
        protected string PostUrl
        {
            get;
            set;
        }

        protected string ReferUrl
        {
            get;
            set;
        }

        protected byte[] Bytesarray
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

        public Send_Post(string posturl,string referurl,byte[] array)
        {
            PostUrl = posturl;
            ReferUrl = referurl;
            Bytesarray = array;
            Output = "";
            Post_Request();
        }

        protected void Post_Request()
        {
            #region 构造请求头
            HttpWebRequest HttpRequest = (HttpWebRequest)HttpWebRequest.Create(PostUrl);
            HttpRequest.Method = "POST";
            SetHeader.SetHeaderValue(HttpRequest.Headers, "Host", "ojjx.wzu.edu.cn");
            SetHeader.SetHeaderValue(HttpRequest.Headers, "Connection", "keep-alive");
            HttpRequest.Headers["Cache-Control"] = "max-age=0";
            HttpRequest.Headers["Origin"] = "http://ojjx.wzu.edu.cn";
            HttpRequest.Headers["Upgrade-Insecure-Requests"] = "1";
            HttpRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36";
            HttpRequest.ContentType = "application/x-www-form-urlencoded";
            HttpRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
            HttpRequest.Headers["DNT"] = "1";
            HttpRequest.Referer = ReferUrl;
            HttpRequest.Headers["Accept-Encoding"] = "gzip, deflate";
            HttpRequest.Headers["Accept-Language"] = "zh-CN,zh;q=0.8";
            HttpRequest.CookieContainer = LoginInfo.EACookie;
            #endregion

            #region 创建IO流写入POST内容
            Stream stream = HttpRequest.GetRequestStream();
            stream.Write(Bytesarray, 0, Bytesarray.Length);
            stream.Close();
            #endregion

            #region 返回并接收数据
            try
            {
                HttpWebResponse httpResponse = (HttpWebResponse)HttpRequest.GetResponse();
                StreamReader ReadersOfStream = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
                Output = ReadersOfStream.ReadToEnd();
                Status = true;
            }
            catch(Exception e)
            {
                Status = false;
                LoginInfo.FailedReason = "Post请求异常，请检查网络是否中断或者丢包。";
                LoginInfo.FailedLog = e.Message;
            }
            #endregion
        }

        public string GetOutPut()
        {
            return Output;
        }

        public bool GetStatus()
        {
            return Status;
        }
    }
}
