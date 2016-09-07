using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DesignPatterns.Pattern.GangOfFour.Structural
{
    public class Flyweight
    {
    }

    public interface IWebsiteStats
    {
        int Id { get; set; }
        string Host { get; set; }
        int PageViews { get; set; }
        int SiteVisits { get; set; }
        string TopKeywords { get; set; }
        int GetActiveUsers();
    }

    public class WebsiteStats : IWebsiteStats
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int PageViews { get; set; }
        public int SiteVisits { get; set; }
        public string TopKeywords { get; set; }

        public int GetActiveUsers()
        {
            return new Random().Next(100, 10000);
        }
    }

    public class WebsiteStatsFactory
    {
        private static Dictionary<string, IWebsiteStats> dic = new Dictionary<string, IWebsiteStats>();

        public IWebsiteStats this[string host]
        {
            get
            {
                if (!dic.ContainsKey(host))
                {
                    dic[host] = new WebsiteStats();
                }

                return dic[host];
            }
        }
    }

}