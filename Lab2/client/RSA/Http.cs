using System;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;

public class Http
{
    public CookieContainer myCookies = new CookieContainer();   
    
    public WebProxy proxyUsing = null;

    public Http(string[] proxy)
    {
        proxyUsing = new WebProxy(proxy[0], int.Parse(proxy[1]));
    }
    public Http()
    {
       
    }
    public void AddCookie(string cookiename, string cookievalue, string domain)
    {
        this.myCookies.Add(new Cookie(cookiename, cookievalue, "/", domain));
    }
    public string HttpGETrequest(string url, WebHeaderCollection WBC = null, string contentType = "application/x-www-form-urlencoded")
    {
        int errorCounter = 0;
        start:

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      
        request.Method = "GET";
        if (WBC != null) { request.Headers = WBC; }
        request.Proxy = proxyUsing;
        request.CookieContainer = myCookies;
        request.AllowAutoRedirect = true;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";
        try
        {

            HttpWebResponse resp = ((HttpWebResponse)request.GetResponse());

            return new StreamReader(resp.GetResponseStream()).ReadToEnd();

        }
        catch (WebException ex)
        {
            string gg = ex.Data.ToString();
            errorCounter++;
            if (errorCounter > 3)
            {
                return null;
            }
            else
            {
                Thread.Sleep(2000);
                goto start;
            }

        }
    }
    public string HttpPOSTrequest(string url, string data, WebHeaderCollection WBC = null, string contentType = "application/x-www-form-urlencoded; charset=UTF-8")
    {
        int errorCount = 0;
        start:


        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
   
        if (WBC != null) { request.Headers = WBC; }
        request.Method = "POST";
        request.ContentType = contentType;
        request.ContentLength = data.Length;
        request.AllowAutoRedirect = false;
        request.Proxy = proxyUsing;
        request.UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";


        request.CookieContainer = myCookies;
        try
        {
            using (var stream = new StreamWriter(request.GetRequestStream()))
            {
                stream.Write(data);
            }


        
            string redirect;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if ((redirect = response.Headers["Location"]) != null && redirect != "")
            {
                response.Close();
                return HttpGETrequest(redirect);
            }
            else
            {
                return new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
        }
        catch (WebException)
        {
            errorCount++;
            if (errorCount > 4)
            {
                return null;
            }
            else
            {
                Thread.Sleep(1000);
                goto start;
            }


        }
    }

  
}

