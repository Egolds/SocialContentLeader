using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace VkPostsCollector.DataAccessLayer
{
    public class WebData
    {
        private const string GoogleUserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.163 Safari/537.36";
        private WebProxy myproxy;
        private bool useProxy;

        public WebHeaderCollection AdditionalHeaders { get; set; } = new WebHeaderCollection();
        public bool AllowAutoRedirect { get; set; } = false;


        public WebData(WebProxy proxy = null)
        {
            if (proxy != null)
            {
                myproxy = proxy;
                useProxy = true;
            }
            else useProxy = false;
        }

        public HttpResponse GET(string host)
        {
            return GET(host, null);
        }
        public HttpResponse GET(string host, CookieContainer cc)
        {
            if (cc == null) cc = new CookieContainer();
            HttpWebResponse webResponse = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(host);
                webRequest.Headers = GetHeader();
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                webRequest.UserAgent = GoogleUserAgent;
                if (useProxy) webRequest.Proxy = myproxy;
                else webRequest.Proxy = null;
                webRequest.Method = "GET";
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.AllowAutoRedirect = AllowAutoRedirect;
                webRequest.CookieContainer = cc;
                webRequest.ProtocolVersion = HttpVersion.Version10;
                webRequest.KeepAlive = true;

                webResponse = (HttpWebResponse)webRequest.GetResponse();

                return new HttpResponse(webResponse);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                    cc.Add(webResponse.Cookies);
                }
            }
        }

        public HttpResponse POST(string host, NameValueCollection param)
        {
            return POST(host, null, param);
        }
        public HttpResponse POST(string host, CookieContainer cc, NameValueCollection param)
        {
            HttpWebResponse webResponse = null;
            if (cc == null) cc = new CookieContainer();

            try
            {
                if (param.Count == 0)
                    throw new ArgumentNullException();

                List<string> parametersList = param.AllKeys.Select(key => string.Format("{0}={1}", key, param[key])).ToList();
                string parameters = string.Join("&", parametersList);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(host);
                webRequest.Headers = GetHeader();
                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                webRequest.UserAgent = GoogleUserAgent;
                if (useProxy) webRequest.Proxy = myproxy;
                else webRequest.Proxy = null;
                webRequest.Method = "POST";
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.AllowAutoRedirect = false;
                webRequest.CookieContainer = cc;
                webRequest.ProtocolVersion = HttpVersion.Version10;
                webRequest.KeepAlive = true;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.ContentLength = parameters.Length;
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ServerCertificateValidationCallback = AcceptAllCertifications;

                using (var requestStream = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestStream.Write(parameters);
                }

                webResponse = (HttpWebResponse)webRequest.GetResponse();

                return new HttpResponse(webResponse);

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                    cc.Add(webResponse.Cookies);
                }


            }
        }

        public HttpResponse POST(string host, string param)
        {
            return POST(host, null, param);
        }
        public HttpResponse POST(string host, CookieContainer cc, string param)
        {
            HttpWebResponse webResponse = null;
            if (cc == null) cc = new CookieContainer();

            try
            {
                if (param.Length == 0)
                    throw new ArgumentNullException();

                byte[] parameters = Encoding.ASCII.GetBytes(param);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(host);
                webRequest.Headers = GetHeader();

                webRequest.Headers.Add("", "");

                webRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                webRequest.UserAgent = GoogleUserAgent;
                if (useProxy) webRequest.Proxy = myproxy;
                else webRequest.Proxy = null;
                webRequest.Method = "POST";
                webRequest.ProtocolVersion = HttpVersion.Version11;
                webRequest.AllowAutoRedirect = false;
                webRequest.CookieContainer = cc;
                webRequest.ProtocolVersion = HttpVersion.Version10;
                webRequest.KeepAlive = true;
                webRequest.ContentType = "application/json";
                webRequest.ContentLength = parameters.Length;
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ServerCertificateValidationCallback = AcceptAllCertifications;

                using (var requestStream = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestStream.Write(parameters);
                }

                webResponse = (HttpWebResponse)webRequest.GetResponse();

                return new HttpResponse(webResponse);

            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return null;
            }
            finally
            {
                if (webResponse != null)
                {
                    webResponse.Close();
                    cc.Add(webResponse.Cookies);
                }


            }
        }

        private WebHeaderCollection GetHeader()
        {
            WebHeaderCollection Headers = new WebHeaderCollection();
            Headers = new WebHeaderCollection();
            Headers.Add("Accept-Language", "en-US,en;q=0.8,en-US;q=0.5,en;q=0.3");
            Headers.Add("Accept-Encoding", "gzip, deflate");

            if(AdditionalHeaders.Count > 0)
            {
                foreach(NameValueCollection nvc in AdditionalHeaders)
                {
                    Headers.Add(nvc);
                }
            }

            return Headers;
        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }

    public class HttpResponse
    {
        public HttpResponse(HttpWebResponse webResponse)
        {
            CharacterSet = webResponse.CharacterSet;
            ContentEncoding = webResponse.ContentEncoding;
            ContentLength = webResponse.ContentLength;
            ContentType = webResponse.ContentType;
            Cookies = webResponse.Cookies;
            Headers = webResponse.Headers;
            IsMutuallyAuthenticated = webResponse.IsMutuallyAuthenticated;
            LastModified = webResponse.LastModified;
            Method = webResponse.Method;
            ProtocolVersion = webResponse.ProtocolVersion;
            ResponseUri = webResponse.ResponseUri;
            Server = webResponse.Server;
            StatusCode = webResponse.StatusCode;
            StatusDescription = webResponse.StatusDescription;
            SupportsHeaders = webResponse.SupportsHeaders;
            Instance = webResponse;
            Content = GetBody();
        }

        public string CharacterSet { get; private set; }
        public string ContentEncoding { get; private set; }
        public long ContentLength { get; private set; }
        public string ContentType { get; private set; }
        public CookieCollection Cookies { get; private set; }
        public WebHeaderCollection Headers { get; private set; }
        public bool IsMutuallyAuthenticated { get; private set; }
        public DateTime LastModified { get; private set; }
        public string Method { get; private set; }
        public Version ProtocolVersion { get; private set; }
        public Uri ResponseUri { get; private set; }
        public string Server { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public string StatusDescription { get; private set; }
        public bool SupportsHeaders { get; private set; }
        public HttpWebResponse Instance { get; private set; }
        public string Content { get; private set; }

        private string GetBody()
        {
            if (Instance == null)
                return null;

            StreamReader reader = new StreamReader(Decompress(Instance), Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private Stream Decompress(HttpWebResponse webResponse)
        {
            Stream responseStream = webResponse.GetResponseStream();
            if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
                responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
            else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
                responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

            return responseStream;
        }
    }
}
