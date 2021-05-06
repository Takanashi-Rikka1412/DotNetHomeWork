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
using System.Diagnostics;

namespace Homework10
{
    public class SimpleCrawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        private const int maxCount = 30;
        private int fileCount = 0;
        private Queue<string> currentUrl = new Queue<string>();
        private Queue<string> currentHtml = new Queue<string>();
        private Queue<string> currentUrl2 = new Queue<string>();
        private static Stopwatch stopWatch = new Stopwatch();
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
            stopWatch.Start();
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
                Task<string>[] taskDownLoad = new Task<string>[maxCount];
                Task[] taskParse = new Task[maxCount];
                string[] current = new string[maxCount];
                string[] html = new string[maxCount];

                int i = 0;
                int j = 0;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current[i] = url;

                    currentUrl.Enqueue(url);

                    MessageAction("爬行" + url + "页面!\r\n");
                    taskDownLoad[i] = Task.Run(() => DownLoad(currentUrl.Dequeue()));

                    count++;
                    i++;
                    if (i >= maxCount)
                        break;
                }
                MessageAction("以上页面爬取结束\r\n");
                if (count >= maxCount || current[0] == null)
                {
                    Task.WaitAll(taskDownLoad.Take(i).ToArray());
                    break;
                }
                //Task.WaitAll(taskDownLoad);
                MessageAction("开始解析新链接\r\n");

                for (j = 0; j < i; j++)
                {
                    html[j] = taskDownLoad[j].Result;
                    urls[current[j]] = true;
                    currentHtml.Enqueue(html[j]);
                    currentUrl2.Enqueue(current[j]);
                    //MessageAction("遍历" + current[j]+"\r\n");
                    //Parse(currentHtml.Dequeue(), currentUrl2.Dequeue());
                    taskParse[j] = Task.Run(() => Parse(currentHtml.Dequeue(), currentUrl2.Dequeue()));//解析,并加入新的链接
                    //MessageAction("遍历" + current[j] + "结束\r\n");
                }
                Task.WaitAll(taskParse.Take(j).ToArray());
            }
            
            MessageAction("******************************\r\n" +
                $"请求下载网页数：{count}  成功下载网页数：{fileCount}\r\n");
            MessageAction("终止爬行...\r\n");
            stopWatch.Stop();
            MessageAction("消耗时间：" + stopWatch.ElapsedMilliseconds + "\r\n");
            ButtonAction();
            stopWatch.Reset();
        }

        public string DownLoad(string url)
        {
            try
            {
                MessageAction("开始下载" + url + "页面\r\n");
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName;
                fileName = "页面" + fileCount;
                fileCount++;

                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;

            }
            catch (Exception ex)
            {
                MessageAction("错误：" + ex.Message + "\r\n");
                return "";
            }
        }
        private void Parse(string html, string current)
        {
            MessageAction("开始解析" + current + "页面\r\n");
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
                if (urls[strRef] == null)
                    urls[strRef] = false;

            }
        }
    }
}
