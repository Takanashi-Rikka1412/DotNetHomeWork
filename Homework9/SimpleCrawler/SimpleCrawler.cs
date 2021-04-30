using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework9
{
    public class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private string current;
        public static Action<string> MessageAction { get; set; }
        public static Action ButtonAction { get; set; }


        /*
        static void Main(string[] args)
        {
            SimpleCrawler myCrawler = new SimpleCrawler();
            string startUrl = "http://www.mooc.whu.edu.cn";//"http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
        }
        */
        public static void StartCrawl(string url)
        {
            string urlRef = @"^(?<startByHttp>https?://)";
            MatchCollection matches = new Regex(urlRef).Matches(url);
            if (matches.Count == 0)
                url = "http://" + url;
            string startUrl = url;
            SimpleCrawler myCrawler = new SimpleCrawler();
            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();
        }
        private void Crawl()
        {
            MessageAction("开始爬行了....\r\n");
            while (true)
            {
                current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null || count > 10) break;
                MessageAction("爬行" + current + "页面!\r\n");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(html);//解析,并加入新的链接
                MessageAction("爬行结束\r\n");
            }
            MessageAction("终止爬行...\r\n");
            ButtonAction();
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                MessageAction(ex.Message + "\r\n");
                return "";
            }
        }
        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[\s]*=[\s]*[""'](?<start>[^""'#>/.]|./|../|/)[^""'#>]+.(htm|html|aspx|jsp)[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                    .Trim('"', '\"', '#', '>', ' ');

                int i;
                switch (match.Groups["start"].Value)
                {
                    case "./":
                        strRef = strRef.Substring(1);
                        strRef = current + strRef; break;
                    case "../":
                        strRef = strRef.Substring(2);
                        string upper = "";
                        for (i = current.Length - 1; i > 0; i--)
                        {
                            if (current[i] == '/')
                                break;
                        }
                        upper = current.Substring(0, i);
                        strRef = upper + strRef;
                        break;
                    case "/":
                        string root = current;
                        string rootRef = @"^(?<startByHttp>https?://)";
                        MatchCollection matches1 = new Regex(rootRef).Matches(root);
                        string startByHttpStr = "";
                        if (matches1.Count > 0)
                        {
                            startByHttpStr = matches1[0].Groups["startByHttp"].Value;
                            root = root.Substring(matches1[0].Groups["startByHttp"].Length);
                        }
                        for (i = 0; i < root.Length; i++)
                        {
                            if (root[i] == '/')
                                break;
                        }
                        root = root.Substring(0, i);
                        strRef = startByHttpStr + root + strRef;
                        break;
                    default:
                        string strRef2 = @"^(https?://)?[^/.]*(.[^/.]*)*/";
                        MatchCollection matches2 = new Regex(strRef2).Matches(strRef);
                        if (matches2.Count == 0)
                            strRef = current + "/" + strRef;
                        break;
                }

                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
