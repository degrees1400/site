using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Degrees1400
{
    public class GoogleAnalytics
    {
        private HttpRequestBase _request;

        public GoogleAnalytics(HttpRequestBase request)
        {
            _request = request;
        }

        public void TrackPage(string pageName)
        {

            NameValueCollection nvc = new NameValueCollection();

            nvc["v"] = "1";
            nvc["tid"] = "UA-49323129-1";
            nvc["cid"] = "555";
            nvc["t"] = "pageview";
            nvc["ua"] = _request.UserAgent;
            nvc["uip"] = _request.UserHostAddress;
            nvc["dh"] = "shop.quarterly.co";
            nvc["dp"] = "/products/" + pageName; // + (_request.QueryString.Count > 0 ? "?" + _request.QueryString.ToString() : "");
            nvc["dt"] = pageName;


            HttpWebRequest request = WebRequest.Create("http://www.google-analytics.com/collect") as HttpWebRequest;
            request.Method = "POST";
            request.Accept = _request.Headers["Accept"] ?? "";
            request.UserAgent = _request.UserAgent ?? "";
            request.Referer = _request.UrlReferrer == null ? "" : _request.UrlReferrer.ToString();
            request.Headers["Accept-Language"] = _request.Headers["Accept-Language"] ?? "";
            request.ContentType = "application/x-www-form-urlencoded";

            using (StreamWriter writer = new StreamWriter(request.GetRequestStream(), _request.ContentEncoding))
            {
                var sb = new StringBuilder();
                foreach(string key in nvc.Keys)
                {
                    sb.AppendFormat("{0}={1}&",
                        key, HttpUtility.UrlEncode(nvc[key]));
                }
                sb.Length -= 1;

                writer.Write(sb.ToString());
            }

            using (WebResponse response = request.GetResponse())
            {

            }
            

        }
    }

}