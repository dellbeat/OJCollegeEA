using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.IO;

namespace OJColleugeEA
{
    public class GetCookies
    {
        protected string status
        {
            get;
            set;
        }

        public GetCookies()
        {
            string url = "http://ojjx.wzu.edu.cn/default2.aspx";
            HttpWebRequest myhttpwebrequest = (HttpWebRequest)WebRequest.Create(url);
            myhttpwebrequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            myhttpwebrequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36";
            myhttpwebrequest.ContentType = "application/x-www-form-urlencoded";
            myhttpwebrequest.CookieContainer = new CookieContainer();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)myhttpwebrequest.GetResponse();
                status = Convert.ToString(response.StatusCode);
                LoginInfo.EACookie = myhttpwebrequest.CookieContainer;
                response.Close();
            }
            catch
            {
                status = "TIMED_OUT";
                LoginInfo.EACookie = null;
            }
            

        }

        public string Getstatus()
        {
            return status;
        }
    }
}
