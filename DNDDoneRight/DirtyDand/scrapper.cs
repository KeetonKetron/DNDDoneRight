using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Scraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.IndexOf("bin"));

            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Run(() => Get5EToolsInfo(path, "https://5e.tools/spells.html", "Spells")));
            Console.WriteLine("starting 5E spells");

            tasks.Add(Task.Run(() => Get5EToolsInfo(path, "https://5e.tools/backgrounds.html", "Backgrounds")));
            Console.WriteLine("starting 5E backgrounds");

            //tasks.Add(Task.Run(() => Get5EToolsInfo(path, "https://5e.tools/feats.html", "Feats")));
            Console.WriteLine("starting 5E feats");

            tasks.Add(Task.Run(() => GetWikiDotSpells(path)));
            Console.WriteLine("starting wikidot");

            await Task.WhenAll(tasks);
            Console.WriteLine("done");

        }
        static void GetWikiDotSpells(string path)
        {
            List<string> spellsURL = new List<string>();
            List<string> spellsHTML = new List<string>();


            var url = "http://dnd5e.wikidot.com/spells";

            WebClient client = new WebClient();

            string html = client.DownloadString(url);

            url = "http://dnd5e.wikidot.com/spell";

            do
            {
                html = html.Remove(0, html.IndexOf("/spell:"));
                spellsURL.Add(url + html.Substring(html.IndexOf("/spell:") + 6, html.IndexOf(">") - 7));
                html = html.Remove(0, html.IndexOf("\">"));

            } while (html.IndexOf("/spell:") != -1);

            foreach (string s in spellsURL)
                spellsHTML.Add(client.DownloadString(s));


            List<string> spellInfo = new List<string>();
            foreach (string spell in spellsHTML)
            {
                string[] result;
                string temp;
                temp = spell.Remove(0, spell.IndexOf("r\"><span>") + 9);
                spellInfo.Add(temp.Substring(0, temp.IndexOf("<")));
                temp = temp.Remove(0, temp.IndexOf("p>"));
                temp = temp.Substring(temp.IndexOf("p>") + 2, temp.IndexOf("<div class=\"content-separator\" style=\"display: none:\"></div>") - temp.IndexOf("p>") - 2);
                temp = RemoveParagraphBullShit(temp);
                result = temp.Split("\n");
                foreach (string line in result)
                    if (line != string.Empty)
                        if (line == "+&nbsp;Show&nbsp;HB&nbsp;Suggestion" || line == "-&nbsp;Hide&nbsp;HB&nbsp;Note" || line == "-&nbsp;Hide&nbsp;HB&nbsp;Suggestion")
                            continue;
                        else if (line.Contains("cantrip"))
                        {
                            spellInfo.Add("0");
                            spellInfo.Add(line.Substring(0, line.IndexOf("cantrip") - 1));
                        }
                        else if (line.Contains("-level"))
                        {
                            spellInfo.Add(line.Substring(0, 1));
                            spellInfo.Add(line.Substring(line.IndexOf(" ") + 1, line.Length - line.IndexOf(" ") - 1));
                        }
                        else
                            spellInfo.Add(line);
                spellInfo.Add("~");
            }

            string[] lines = spellInfo.ToArray();
            File.WriteAllLines(path + "SpellsWD.txt", lines);

            //int level, enum school, string castingTime, int range, bool v, bool s, bool m, string material, string suration, 
        }
        static void Get5EToolsInfo(string path, string url, string name)
        {
            List<string> info = new List<string>();

            IWebDriver driver = new ChromeDriver(@"D:\dev\");
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0,1,0);
            driver.Url = url;

            driver.FindElement(By.CssSelector("button[class='btn btn-default ']")).Click();//opens filer
            driver.FindElement(By.CssSelector("button[class='btn btn-default btn-xs fltr__h-btn--all w-100']")).Click();//selects all content
            driver.FindElement(By.CssSelector("button[class='btn btn-xs btn-primary']")).Click();//confirm

            ReadOnlyCollection<IWebElement> elements = driver.FindElements(By.CssSelector("div[class='lst__row flex-col ']")); //finds each spell element

            info.Add(driver.FindElement(By.CssSelector("span[class='stats-name copyable']")).Text);//gets the name
            ReadOnlyCollection<IWebElement> elementInfo = driver.FindElements(By.CssSelector("td[colspan='6']"));//gets all other info
            foreach (IWebElement e in elementInfo)
              info.Add(e.Text);//adds ainfo to list
            info.Add("~");


            foreach (IWebElement e in elements)
            {
                e.Click();
                info.Add(driver.FindElement(By.CssSelector("span[class='stats-name copyable']")).Text);//gets the name
                elementInfo = driver.FindElements(By.CssSelector("td[colspan='6']"));//gets all other info
                foreach (IWebElement i in elementInfo)
                    info.Add(i.Text);//adds ainfo to list
                info.Add("~");
                
            }

            string[] lines = info.ToArray();
            File.WriteAllLines(path + name + "5E.txt", lines);
            driver.Close();
        }

        public static string RemoveParagraphBullShit(string bs)
        {
            string temp = bs;
            while (bs.Contains("–&nbsp;"))
            {
                temp = bs.Substring(0, bs.IndexOf("–&nbsp;")) + "- ";
                temp += bs.Substring(bs.IndexOf("–&nbsp;") + 7, bs.Length - bs.IndexOf("–&nbsp;") - 7);
                bs = temp;
            }
            while (bs.Contains(";&nbsp;"))
            {
                temp = bs.Substring(0, bs.IndexOf(";&nbsp;")) + "; ";
                temp += bs.Substring(bs.IndexOf(";&nbsp;") + 7, bs.Length - bs.IndexOf(";&nbsp;") - 7);
                bs = temp;
            }
            while (bs.Contains("&quot;"))
            {
                temp = bs.Substring(0, bs.IndexOf("&quot;")) + "\"";
                temp += bs.Substring(bs.IndexOf("&quot;") + 6, bs.Length - bs.IndexOf("&quot;") - 6);
                bs = temp;
            }
            while (bs.Contains("&#8212;"))
            {
                temp = bs.Substring(0, bs.IndexOf("&#8212;")) + "—";
                temp += bs.Substring(bs.IndexOf("&#8212;") + 7, bs.Length - bs.IndexOf("&#8212;") - 7);
                bs = temp;
            }
            while (bs.Contains("<"))
            {
                temp = bs.Substring(0, bs.IndexOf("<"));
                temp += bs.Substring(bs.IndexOf(">") + 1, bs.Length - bs.IndexOf(">") - 1);
                bs = temp;
            }
            return bs;
        }

        
    }
}
