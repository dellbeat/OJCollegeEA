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
    class GetViewCode
    {
        Bitmap pic
        {
            get;
            set;
        }

        string status
        {
            get;
            set;
        }

        public GetViewCode()
        {
            Uri uri = new Uri("http://ojjx.wzu.edu.cn/CheckCode.aspx");
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                request.CookieContainer = LoginInfo.EACookie;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                status = Convert.ToString(response.StatusCode);
                Stream resStream = response.GetResponseStream();//得到验证码数据流
                Bitmap sourcebm = new Bitmap(resStream);//初始化Bitmap图片
                response.Close();
                pic = sourcebm;
            }
            catch
            {
                status = "TIMED_OUT";
            }
        }

        public Bitmap GetPic()
        {
            return pic;
        }

        public string GetStatus()
        {
            return status;
        }
    }
}
